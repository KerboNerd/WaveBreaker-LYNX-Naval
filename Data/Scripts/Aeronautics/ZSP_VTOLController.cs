using System;
using System.Collections.Generic;
using System.Text;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Game.Entities;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using Sandbox.ModAPI.Interfaces.Terminal;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRageMath;
using VRage.Utils;
using VRage;
using SENetworkAPI;

namespace ware_LNX_Jet_Systems
{
    // Controller for the ZSP 3 Bearing Swivel Nozzle.
    // Keeps the block as a vanilla MyObjectBuilder_Thrust.
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Thrust), false, "3_Bearing_Swivel_Nozzle")]
    public class ZSP_VTOLController : MyGameLogicComponent
    {
        private const string SUBTYPE_ID = "3_Bearing_Swivel_Nozzle";
        private const ushort NETWORK_CHANNEL = 8792;
        private const string MOD_NAME = "WB Combat Sys";

        // Nozzle animation: the root model's first visible section stays fixed.
        // The first two nested attachment transforms carry visible sections 2 and 3.
        private const string PART_1_NAME = "Nozzle_Part1";
        private const string PART_2_NAME = "Nozzle_Part2";
        private const string PART_3_NAME = "Nozzle_Part3";

        private static readonly Vector3 PART_2_AXIS = Vector3.Normalize(new Vector3(0f, -0.41f, 1f));
        private static readonly Vector3 PART_3_AXIS = Vector3.Normalize(new Vector3(0f, 0.41f, 1f));

        private const float NOZZLE_ROTATION_DEGREES = 180f;
        private const int ANIMATION_LENGTH_TICKS = 150;
        private const double VTOL_FORCE_MULTIPLIER = 1.0;

        // Direct resource-sink multiplier used while actively requesting VTOL lift.
        // Tuned against the Oxygen sink's measured demand (approximately 1200).
        private const float VTOL_OXYGEN_CONSUMPTION_MULTIPLIER = 310736.9f;
        private static readonly MyDefinitionId OXYGEN_RESOURCE_ID =
            new MyDefinitionId(typeof(MyObjectBuilder_GasProperties), "Oxygen");

        private static bool terminalControlsCreated;

        private MyThrust block;
        private NetSync<bool> vtolMode;

        // Controller-managed effects attached to the moving nozzle.
        private const string JET_PARTICLE_ID = "ZSP_Travel_Jet_Large";
        private const string MACH_PARTICLE_ID = "ZSP_Jet_Mach_Rings_Large";
        private const string BURNER_PARTICLE_ID = "ZSP_Burner_Effect_Large";

        private const float JET_MIN_FORWARD_THRUST_FRACTION = 0.01f;
        private const float JET_MAX_FORWARD_THRUST_FRACTION = 0.91f;
        private const float HIGH_THRUST_EFFECT_FRACTION = 0.91f;
        private const float JET_PARTICLE_SCALE = 0.60f;
        private const float JET_PARTICLE_OFFSET = 0.26f;
        private const float MACH_PARTICLE_SCALE = 0.65f;
        private const float BURNER_PARTICLE_SCALE = 0.65f;

        private MyParticleEffect jetParticle;
        private MyParticleEffect machParticle;
        private MyParticleEffect burnerParticle;

        private bool jetParticleCreationFailedLogged;
        private bool machParticleCreationFailedLogged;
        private bool burnerParticleCreationFailedLogged;

        private readonly List<Sandbox.ModAPI.Ingame.IMyShipController> shipControllers =
            new List<Sandbox.ModAPI.Ingame.IMyShipController>();

        // Track the user's normal thruster state while fully in forward mode.
        // Never interpret our own temporary VTOL disablement as the user's preference.
        private bool originalEnabledStateCaptured;
        private bool originalEnabledState;
        private float originalThrustOverride;
        private bool originalThrustOverrideCaptured;
        private bool lastVtolMode;
        private bool restoreThrusterWhenForward;
        private double vtolMaxEffectiveThrust;
        private float originalPowerConsumptionMultiplier;
        private bool originalPowerConsumptionMultiplierCaptured;
        private bool oxygenSinkMissingLogged;
        private MyResourceSinkComponent oxygenSink;
        private bool vtolLiftCommandActive;

        private MyEntitySubpart nozzlePart2;
        private MyEntitySubpart nozzlePart3;

        private Matrix part2RestMatrix;
        private Matrix part3RestMatrix;
        private bool subpartsCached;
        private bool missingSubpartsLogged;

        // 0 = conventional forward thrust; 1 = fully deployed VTOL.
        private float animationProgress;

        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.Init(objectBuilder);
            block = Entity as MyThrust;
            NeedsUpdate = MyEntityUpdateEnum.BEFORE_NEXT_FRAME;
        }

        public override void UpdateOnceBeforeFrame()
        {
            base.UpdateOnceBeforeFrame();

            if (!NetworkAPI.IsInitialized)
                NetworkAPI.Init(NETWORK_CHANNEL, MOD_NAME);

            // A server/world restart reinitialises this component in Forward mode,
            // but the block's terminal override can persist from its previous VTOL state.
            // Clear that stale override before the controller captures any forward-mode state.
            if (IsServer() && block != null)
            {
                Sandbox.ModAPI.IMyThrust thrustBlock =
                    (Sandbox.ModAPI.IMyThrust)block;
                thrustBlock.ThrustOverride = 0f;
            }

            vtolMode = new NetSync<bool>(this, TransferType.Both, false, limitToSyncDistance: true);
            CreateTerminalControls();
            NeedsUpdate = MyEntityUpdateEnum.EACH_FRAME;
        }

        public override void UpdateAfterSimulation()
        {
            base.UpdateAfterSimulation();

            if (block == null || vtolMode == null || block.MarkedForClose)
                return;

            CacheNozzleSubparts();
            UpdateThrusterMode();
            UpdateAnimation();
            ApplyVtolLift();
            HandleJetParticle();
        }

        private void CacheNozzleSubparts()
        {
            if (subpartsCached)
                return;

            // Nested model hierarchy:
            // Thruster root (visible section 1) -> Nozzle_Part1 (visible section 2)
            // -> Nozzle_Part2 (visible section 3) -> Nozzle_Part3 (terminal attachment).
            // MyEntitySubpart inherits MyEntity, so each child is retrieved from its parent.
            MyEntitySubpart nozzlePart1;
            bool found1 = block.TryGetSubpart(PART_1_NAME, out nozzlePart1);
            bool found2 = found1 && nozzlePart1.TryGetSubpart(PART_2_NAME, out nozzlePart2);
            bool found3 = found2 && nozzlePart2.TryGetSubpart(PART_3_NAME, out nozzlePart3);

            if (!found1 || !found2 || !found3)
            {
                if (!missingSubpartsLogged)
                {
                    MyLog.Default.WriteLineAndConsole(
                        "[ZSP_VTOLController] Nozzle hierarchy lookup failed. " +
                        "Part1=" + found1 + ", Part2=" + found2 + ", Part3=" + found3 +
                        ". Expected Thruster -> " + PART_1_NAME + " -> " +
                        PART_2_NAME + " -> " + PART_3_NAME);
                    missingSubpartsLogged = true;
                }
                return;
            }

            // Store the original local transforms once. Each frame is calculated from these,
            // preventing cumulative rotation drift.
            part2RestMatrix = nozzlePart2.PositionComp.LocalMatrixRef;
            part3RestMatrix = nozzlePart3.PositionComp.LocalMatrixRef;
            subpartsCached = true;
        }

        private void UpdateAnimation()
        {
            // Placeholder animation:
            // - Nozzle_Part1 is left completely untouched.
            // - Nozzle_Part2 rotates +180 degrees around its tested local axis.
            // - Nozzle_Part3 rotates -180 degrees around its tested local axis.
            // The opposite rotation directions are intended to preserve alignment
            // between the two moving nozzle sections.
            if (!subpartsCached)
                return;

            float targetProgress = vtolMode.Value ? 1f : 0f;
            float progressStep = 1f / ANIMATION_LENGTH_TICKS;

            if (animationProgress < targetProgress)
                animationProgress = Math.Min(targetProgress, animationProgress + progressStep);
            else if (animationProgress > targetProgress)
                animationProgress = Math.Max(targetProgress, animationProgress - progressStep);

            float radians = MathHelper.ToRadians(
                NOZZLE_ROTATION_DEGREES * animationProgress);

            // Part 2 and Part 3 rotate in opposite directions to preserve alignment.
            Matrix part2Matrix = BuildAnimatedLocalMatrix(
                part2RestMatrix, PART_2_AXIS, -radians);
            Matrix part3Matrix = BuildAnimatedLocalMatrix(
                part3RestMatrix, PART_3_AXIS, radians);

            // Deliberately do not write nozzlePart1's matrix: Part 1 remains
            // exactly at its model-defined transform throughout this animation.
            nozzlePart2.PositionComp.SetLocalMatrix(ref part2Matrix);
            nozzlePart3.PositionComp.SetLocalMatrix(ref part3Matrix);
        }

        private static Matrix BuildAnimatedLocalMatrix(
            Matrix restLocalMatrix, Vector3 localAxis, float radians)
        {
            // Rotation is applied in the subpart's own local coordinate
            // frame. Post-multiplication applies that local-axis rotation while
            // retaining the original pivot translation.
            Matrix localRotation = Matrix.CreateFromAxisAngle(localAxis, radians);
            Matrix animatedLocalMatrix = restLocalMatrix * localRotation;
            animatedLocalMatrix.Translation = restLocalMatrix.Translation;
            return animatedLocalMatrix;
        }

        private bool IsServer()
        {
            return MyAPIGateway.Multiplayer != null && MyAPIGateway.Multiplayer.IsServer;
        }

        private void UpdateThrusterMode()
        {
            // Only the server changes the replicated functional-block state and applies physics.
            if (!IsServer())
                return;

            Sandbox.ModAPI.IMyThrust thrustBlock =
                (Sandbox.ModAPI.IMyThrust)block;

            bool requestedVtol = vtolMode.Value;

            if (requestedVtol)
            {
                if (!lastVtolMode)
                {
                    // Capture the live state only when entering from a fully-forward
                    // position. If we are reversing an unfinished transition, retain
                    // the state saved before the previous VTOL deployment.
                    if (!originalEnabledStateCaptured || animationProgress <= 0f)
                    {
                        originalEnabledState = thrustBlock.Enabled;
                        originalEnabledStateCaptured = true;
                        originalThrustOverride = thrustBlock.ThrustOverride;
                        originalThrustOverrideCaptured = true;
                        originalPowerConsumptionMultiplier =
                            thrustBlock.PowerConsumptionMultiplier;
                        originalPowerConsumptionMultiplierCaptured = true;
                    }

                    double currentEffectiveThrust = thrustBlock.MaxEffectiveThrust;
                    double currentNominalThrust = thrustBlock.MaxThrust;
                    vtolMaxEffectiveThrust = currentEffectiveThrust > 0.0
                        ? currentEffectiveThrust
                        : currentNominalThrust;

                    lastVtolMode = true;
                }

                // Keep the thruster enabled in VTOL, but clamp its vanilla
                // propulsion contribution to a negligible 1 N override.
                // Manual VTOL lift is applied separately by ApplyVtolLift().
                if (originalEnabledState)
                {
                    thrustBlock.Enabled = true;
                    thrustBlock.ThrustOverride = 1f;
                }

                return;
            }

            if (lastVtolMode)
            {
                lastVtolMode = false;
                restoreThrusterWhenForward = true;
            }

            if (animationProgress <= 0f)
            {
                if (restoreThrusterWhenForward)
                {
                    // Restore once, after the return animation has completed.
                    thrustBlock.Enabled = originalEnabledState;
                    if (originalThrustOverrideCaptured)
                        thrustBlock.ThrustOverride = originalThrustOverride;
                    restoreThrusterWhenForward = false;

                    
                    if (originalPowerConsumptionMultiplierCaptured)
                    {
                        SetPowerConsumptionMultiplier(
                            thrustBlock, originalPowerConsumptionMultiplier);
                    }
                }
                else
                {
                    // We are idle in normal forward mode. Observe the live terminal
                    // state so a block left disabled by an older script can be manually
                    // re-enabled, and so later VTOL cycles preserve the user's choice.
                    originalEnabledState = thrustBlock.Enabled;
                    originalEnabledStateCaptured = true;
                }
            }
            else if (originalEnabledState)
            {
                // Keep the thruster active but effectively neutral until the
                // nozzle is fully forward, then restore its original override.
                thrustBlock.Enabled = true;
                thrustBlock.ThrustOverride = 1f;
                if (originalPowerConsumptionMultiplierCaptured)
                {
                    SetPowerConsumptionMultiplier(
                        thrustBlock, originalPowerConsumptionMultiplier);
                }
            }
        }

        private bool IsLiftInputActive(MyCubeGrid grid)
        {
            // Read the synchronized movement input from controlled ship controllers.
            // This avoids local keyboard polling or a separate client->server input sync.
            var terminalSystem = MyAPIGateway.TerminalActionsHelper
                .GetTerminalSystemForGrid(grid);

            if (terminalSystem == null)
                return false;

            shipControllers.Clear();
            terminalSystem.GetBlocksOfType(shipControllers,
                controller => controller.IsUnderControl);

            for (int i = 0; i < shipControllers.Count; i++)
            {
                // MoveIndicator.Y is the ship's vertical movement axis:
                // positive values correspond to the UP control (Space by default).
                Vector3 moveIndicator = shipControllers[i].MoveIndicator;
                if (moveIndicator.Y > 0.1f)
                    return true;
            }

            return false;
        }

        private void ApplyVtolLift()
        {
            // Evaluate the VTOL command once per simulation update. Particle handling
            // reuses this result instead of rescanning ship controllers and the oxygen sink.
            vtolLiftCommandActive = false;

            if (vtolMode == null || !vtolMode.Value)
                return;

            bool isServer = IsServer();
            Sandbox.ModAPI.IMyThrust thrustBlock =
                (Sandbox.ModAPI.IMyThrust)block;

            MyCubeGrid grid = block.CubeGrid;
            if (grid == null || (isServer && grid.Physics == null))
            {
                if (isServer)
                    RestorePowerConsumptionMultiplier(thrustBlock);
                return;
            }

            // Skip controller discovery until the nozzle is deployed and the
            // thruster can actually respond to a lift request.
            if (animationProgress < 1f || !block.IsFunctional || !thrustBlock.Enabled)
            {
                if (isServer)
                    RestorePowerConsumptionMultiplier(thrustBlock);
                return;
            }

            if (!IsLiftInputActive(grid))
            {
                if (isServer)
                    RestorePowerConsumptionMultiplier(thrustBlock);
                return;
            }

            // The server owns resource demand and physics. Clients still evaluate
            // availability locally so their particle effects follow the same gate.
            if (isServer)
            {
                if (vtolMaxEffectiveThrust <= 0.0)
                {
                    RestorePowerConsumptionMultiplier(thrustBlock);
                    return;
                }

                // Keep elevated demand active while UP is held, even if supply is
                // insufficient; otherwise restoring idle demand could create a
                // feedback loop in the availability check.
                SetPowerConsumptionMultiplier(
                    thrustBlock, VTOL_OXYGEN_CONSUMPTION_MULTIPLIER);
            }

            if (!HasVtolOxygenSupply())
                return;

            vtolLiftCommandActive = true;

            if (!isServer)
                return;

            // Use the thruster block's own Up axis, not the grid's Up axis.
            // Mounting the block upside down therefore reverses the scripted lift.
            Vector3D liftDirection = block.WorldMatrix.Up;
            liftDirection.Normalize();

            double liftForceMagnitude = vtolMaxEffectiveThrust *
                                        VTOL_FORCE_MULTIPLIER *
                                        animationProgress;

            Vector3D liftForce = liftDirection * liftForceMagnitude;

            grid.Physics.AddForce(
                MyPhysicsForceType.APPLY_WORLD_FORCE,
                liftForce,
                grid.Physics.CenterOfMassWorld,
                null);
        }

        private void RestorePowerConsumptionMultiplier(
            Sandbox.ModAPI.IMyThrust thrustBlock)
        {
            if (originalPowerConsumptionMultiplierCaptured)
            {
                SetPowerConsumptionMultiplier(
                    thrustBlock, originalPowerConsumptionMultiplier);
            }
        }

        private static void SetPowerConsumptionMultiplier(
            Sandbox.ModAPI.IMyThrust thrustBlock, float multiplier)
        {
            // Avoid repeatedly notifying the resource sink when the value is unchanged.
            if (thrustBlock.PowerConsumptionMultiplier != multiplier)
                thrustBlock.PowerConsumptionMultiplier = multiplier;
        }

        private bool HasVtolOxygenSupply()
        {
            // Retrieve the sink from the entity component container. In Torch,
            // block.ResourceSink was null even though the component was present.
            if (oxygenSink == null)
                oxygenSink = block.Components.Get<MyResourceSinkComponent>();

            MyResourceSinkComponent sink = oxygenSink;

            if (sink == null)
            {
                if (!oxygenSinkMissingLogged)
                {
                    MyLog.Default.WriteLineAndConsole(
                        "[ZSP_VTOLController] Oxygen gate: no MyResourceSinkComponent found; VTOL lift blocked.");
                    oxygenSinkMissingLogged = true;
                }

                return false;
            }

            float requiredOxygen =
                sink.RequiredInputByType(OXYGEN_RESOURCE_ID);

            return requiredOxygen > 0f &&
                   sink.IsPowerAvailable(OXYGEN_RESOURCE_ID, requiredOxygen);
        }

        private bool IsParticleCommandActive()
        {
            Sandbox.ModAPI.Ingame.IMyThrust thrustBlock =
                (Sandbox.ModAPI.Ingame.IMyThrust)block;

            if (!block.IsFunctional || !thrustBlock.Enabled)
                return false;

            // ApplyVtolLift evaluates this once per frame for both physics and effects.
            if (vtolMode != null && vtolMode.Value)
                return vtolLiftCommandActive;

            return animationProgress <= 0f;
        }

        private bool ShouldPlayJetParticle(bool commandActive)
        {
            if (!commandActive)
                return false;

            // VTOL uses the high-thrust effects, regardless of the vanilla 1 N override.
            if (vtolMode != null && vtolMode.Value)
                return false;

            Sandbox.ModAPI.Ingame.IMyThrust thrustBlock =
                (Sandbox.ModAPI.Ingame.IMyThrust)block;

            if (thrustBlock.MaxThrust <= 0f)
                return false;

            float thrustFraction =
                thrustBlock.CurrentThrust / thrustBlock.MaxThrust;

            return thrustFraction >= JET_MIN_FORWARD_THRUST_FRACTION &&
                thrustFraction < JET_MAX_FORWARD_THRUST_FRACTION;
        }

        private bool ShouldPlayHighThrustParticles(bool commandActive)
        {
            if (!commandActive)
                return false;

            // VTOL lift is applied manually; vanilla CurrentThrust stays near 1 N.
            // Treat an active VTOL command as high thrust instead of checking the
            // normal-flight CurrentThrust / MaxThrust threshold.
            if (vtolMode != null && vtolMode.Value)
                return true;

            Sandbox.ModAPI.Ingame.IMyThrust thrustBlock =
                (Sandbox.ModAPI.Ingame.IMyThrust)block;

            return thrustBlock.MaxThrust > 0f &&
                   thrustBlock.CurrentThrust >=
                   thrustBlock.MaxThrust * HIGH_THRUST_EFFECT_FRACTION;
        }

        private void HandleJetParticle()
        {
            if (nozzlePart3 == null || !subpartsCached)
                return;

            MatrixD particleMatrix = nozzlePart3.WorldMatrix;
            Vector3D particlePosition = particleMatrix.Translation;
            Vector3D particleOffset = particleMatrix.Backward * JET_PARTICLE_OFFSET;

            // Evaluate the common activation state and high-thrust condition once.
            bool commandActive = IsParticleCommandActive();
            bool playJet = ShouldPlayJetParticle(commandActive);
            bool playHighThrust = ShouldPlayHighThrustParticles(commandActive);

            // Travel Jet: offset 0.26f.
            MatrixD jetParticleMatrix = particleMatrix;
            Vector3D jetParticlePosition = particlePosition + particleOffset;
            jetParticleMatrix.Translation = jetParticlePosition;

            UpdateParticleEffect(ref jetParticle, JET_PARTICLE_ID, JET_PARTICLE_SCALE,
                playJet, ref jetParticleCreationFailedLogged,
                jetParticleMatrix, jetParticlePosition);

            // Mach Rings: retain the original nozzle position.
            UpdateParticleEffect(ref machParticle, MACH_PARTICLE_ID, MACH_PARTICLE_SCALE,
                playHighThrust, ref machParticleCreationFailedLogged,
                particleMatrix, particlePosition);

            // Burner: also offset 0.26f, just like the Travel Jet.
            MatrixD burnerParticleMatrix = particleMatrix;
            Vector3D burnerParticlePosition = particlePosition + particleOffset;
            burnerParticleMatrix.Translation = burnerParticlePosition;

            UpdateParticleEffect(ref burnerParticle, BURNER_PARTICLE_ID, BURNER_PARTICLE_SCALE,
                playHighThrust, ref burnerParticleCreationFailedLogged,
                burnerParticleMatrix, burnerParticlePosition);
        }

        private void UpdateParticleEffect(
            ref MyParticleEffect effect,
            string particleId,
            float scale,
            bool shouldPlay,
            ref bool creationFailedLogged,
            MatrixD particleMatrix,
            Vector3D particlePosition)
        {
            if (effect == null)
            {
                if (!shouldPlay)
                    return;

                if (!MyParticlesManager.TryCreateParticleEffect(
                    particleId,
                    ref particleMatrix,
                    ref particlePosition,
                    uint.MaxValue,
                    out effect))
                {
                    if (!creationFailedLogged)
                    {
                        MyLog.Default.WriteLineAndConsole(
                            "[ZSP_VTOLController] Failed to create particle effect: " +
                            particleId);
                        creationFailedLogged = true;
                    }
                }
                else
                {
                    // Apply scale immediately when the particle instance is created.
                    effect.UserScale = scale;
                    effect.UserLifeMultiplier = 0.5f;
                }

                return;
            }

            effect.WorldMatrix = particleMatrix;
            // Apply scale before Update/Play on every frame. This is deliberately
            // unconditional so a stopped/reused effect cannot retain an old scale.
            effect.UserScale = scale;
            effect.Update();

            if (shouldPlay)
            {
                effect.UserLifeMultiplier = 0.5f;
                effect.Play();
            }
            else
            {
                effect.StopEmitting();
                effect.StopLights();
            }
        }

        private bool GetVtolState()
        {
            return vtolMode != null && vtolMode.Value;
        }

        private void SetVtolState(bool enabled)
        {
            if (vtolMode != null)
            {
                vtolMode.Value = enabled;
            }
        }

        private static bool TerminalVisibility(IMyTerminalBlock terminalBlock)
        {
            return terminalBlock != null &&
                   terminalBlock.BlockDefinition.SubtypeId == SUBTYPE_ID &&
                   terminalBlock.GameLogic.GetAs<ZSP_VTOLController>() != null;
        }

        private static bool VtolGetter(IMyTerminalBlock terminalBlock)
        {
            ZSP_VTOLController logic = terminalBlock.GameLogic.GetAs<ZSP_VTOLController>();
            return logic != null && logic.GetVtolState();
        }

        private static void VtolSetter(IMyTerminalBlock terminalBlock, bool newState)
        {
            ZSP_VTOLController logic = terminalBlock.GameLogic.GetAs<ZSP_VTOLController>();
            if (logic != null)
                logic.SetVtolState(newState);
        }

        private static void VtolToggle(IMyTerminalBlock terminalBlock)
        {
            ZSP_VTOLController logic = terminalBlock.GameLogic.GetAs<ZSP_VTOLController>();
            if (logic != null)
                logic.SetVtolState(!logic.GetVtolState());
        }

        private static void VtolHotbarText(IMyTerminalBlock terminalBlock, StringBuilder text)
        {
            text.Clear();
            ZSP_VTOLController logic = terminalBlock.GameLogic.GetAs<ZSP_VTOLController>();
            text.Append(logic != null && logic.GetVtolState() ? "VTOL" : "FORWARD");
        }

        private static void CreateTerminalControls()
        {
            if (terminalControlsCreated || MyAPIGateway.TerminalControls == null)
                return;

            terminalControlsCreated = true;

            var control = MyAPIGateway.TerminalControls.CreateControl<
                IMyTerminalControlOnOffSwitch,
                Sandbox.ModAPI.Ingame.IMyThrust>("ZSP_VTOL_Mode");

            control.Getter = VtolGetter;
            control.Setter = VtolSetter;
            control.Title = MyStringId.GetOrCompute("VTOL Mode");
            control.OnText = MyStringId.GetOrCompute("VTOL");
            control.OffText = MyStringId.GetOrCompute("Forward");
            control.Visible = TerminalVisibility;
            control.SupportsMultipleBlocks = true;
            MyAPIGateway.TerminalControls.AddControl<Sandbox.ModAPI.Ingame.IMyThrust>(control);

            var action = MyAPIGateway.TerminalControls.CreateAction<Sandbox.ModAPI.Ingame.IMyThrust>(
                "ZSP_VTOL_Mode_Toggle");
            action.Action = VtolToggle;
            action.Name = new StringBuilder("VTOL Mode Toggle");
            action.Writer = VtolHotbarText;
            action.Enabled = TerminalVisibility;
            action.ValidForGroups = true;
            MyAPIGateway.TerminalControls.AddAction<Sandbox.ModAPI.Ingame.IMyThrust>(action);
        }

        private void StopAndClearParticle(ref MyParticleEffect effect)
        {
            if (effect == null)
                return;

            effect.Stop(false);
            effect.StopEmitting();
            effect.StopLights();
            effect = null;
        }

        public override void Close()
        {
            StopAndClearParticle(ref jetParticle);
            StopAndClearParticle(ref machParticle);
            StopAndClearParticle(ref burnerParticle);

            // Do not leave the vanilla thruster disabled if the component is removed in VTOL.
            if (IsServer() && originalEnabledStateCaptured &&
                (lastVtolMode || restoreThrusterWhenForward || animationProgress > 0f ||
                 (vtolMode != null && vtolMode.Value)))
            {
                Sandbox.ModAPI.IMyThrust thrustBlock =
                    (Sandbox.ModAPI.IMyThrust)block;
                thrustBlock.Enabled = originalEnabledState;
                if (originalThrustOverrideCaptured)
                    thrustBlock.ThrustOverride = originalThrustOverride;
                
                if (originalPowerConsumptionMultiplierCaptured)
                {
                    SetPowerConsumptionMultiplier(
                        thrustBlock, originalPowerConsumptionMultiplier);
                }
            }

            // Restore the model's original transforms when the logic component is removed.
            if (subpartsCached)
            {
                if (nozzlePart2 != null)
                    nozzlePart2.PositionComp.SetLocalMatrix(ref part2RestMatrix);
                if (nozzlePart3 != null)
                    nozzlePart3.PositionComp.SetLocalMatrix(ref part3RestMatrix);
            }

            base.Close();
        }
    }
}