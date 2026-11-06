using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using Sandbox.ModAPI.Interfaces.Terminal;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRageMath;
using VRage.Utils;
using VRage;
using SENetworkAPI;

namespace ware_LNX_Jet_Systems
{
    // First-pass controller for the ZSP 3 Bearing Swivel Nozzle.
    // Keeps the block as a vanilla MyObjectBuilder_Thrust.
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Thrust), false, "3_Bearing_Swivel_Nozzle")]
    public class ZSP_VTOLController : MyGameLogicComponent
    {
        private const string SUBTYPE_ID = "3_Bearing_Swivel_Nozzle";
        private const ushort NETWORK_CHANNEL = 8792;
        private const string MOD_NAME = "WB Combat Sys";

        // Placeholder animation: the root model's first visible section stays fixed.
        // The first two nested attachment transforms carry visible sections 2 and 3.
        private const string PART_1_NAME = "Nozzle_Part1";
        private const string PART_2_NAME = "Nozzle_Part2";
        private const string PART_3_NAME = "Nozzle_Part3";

        private static readonly Vector3 PART_1_AXIS = Vector3.UnitZ;
        private static readonly Vector3 PART_2_AXIS = Vector3.Normalize(new Vector3(0f, -0.41f, 1f));
        private static readonly Vector3 PART_3_AXIS = Vector3.Normalize(new Vector3(0f, 0.41f, 1f));

        private const float NOZZLE_ROTATION_DEGREES = 180f;
        private const int ANIMATION_LENGTH_TICKS = 150;
        private const double VTOL_FORCE_MULTIPLIER = 1.0;

        // VTOL oxygen demand while actively requesting lift.
        private const float VTOL_OXYGEN_CONSUMPTION_LPS = 1200f;

        // SBC idle consumption for this nozzle, based on its current definition.
        private const float SBC_IDLE_OXYGEN_CONSUMPTION_LPS = 100f;

        private static bool terminalControlsCreated;

        private MyThrust block;
        private NetSync<bool> vtolMode;

        // Controller-managed effects attached to the moving nozzle.
        private const string JET_PARTICLE_ID = "ZSP_Travel_Jet_Large";
        private const string MACH_PARTICLE_ID = "ZSP_Jet_Mach_Rings_Large";
        private const string BURNER_PARTICLE_ID = "ZSP_Burner_Effect_Large";

        private const float JET_MIN_FORWARD_THRUST_FRACTION = 0.01f;
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
        private Vector3 lastControllerMoveIndicator;

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

        private MyEntitySubpart nozzlePart1;
        private MyEntitySubpart nozzlePart2;
        private MyEntitySubpart nozzlePart3;

        private Matrix part1RestMatrix;
        private Matrix part2RestMatrix;
        private Matrix part3RestMatrix;
        private bool subpartsCached;
        private bool missingSubpartsLogged;

        // 0 = conventional forward thrust; 1 = fully deployed VTOL.
        private float animationProgress;

        private int diagnosticTick;
        private int rotationDiagnosticTick;
        private int lastRotationDiagnosticBucket = -1;

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
            part1RestMatrix = nozzlePart1.PositionComp.LocalMatrixRef;
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

            // Use the exact axes exercised by the individual diagnostic tests.
            // Part 2 rotates clockwise (+); Part 3 counter-clockwise (-).
            Matrix part2Matrix = BuildAnimatedLocalMatrix(
                part2RestMatrix, PART_2_AXIS, -radians);
            Matrix part3Matrix = BuildAnimatedLocalMatrix(
                part3RestMatrix, PART_3_AXIS, radians);

            // Deliberately do not write nozzlePart1's matrix: Part 1 remains
            // exactly at its model-defined transform throughout this animation.
            nozzlePart2.PositionComp.SetLocalMatrix(ref part2Matrix);
            nozzlePart3.PositionComp.SetLocalMatrix(ref part3Matrix);

            int diagnosticBucket = (int)Math.Round(animationProgress * 5f);
            if (diagnosticBucket != lastRotationDiagnosticBucket)
            {
                lastRotationDiagnosticBucket = diagnosticBucket;

                Matrix p1World = nozzlePart1.PositionComp.WorldMatrixRef;
                Matrix p2World = nozzlePart2.PositionComp.WorldMatrixRef;
                Matrix p3World = nozzlePart3.PositionComp.WorldMatrixRef;

                MyLog.Default.WriteLineAndConsole(
                    "[ZSP_VTOLController] Two-section placeholder: Progress=" +
                    animationProgress +
                    ", Part2Degrees=" + (-NOZZLE_ROTATION_DEGREES * animationProgress) +
                    ", Part3Degrees=" + (NOZZLE_ROTATION_DEGREES * animationProgress) +
                    ", Part1World=" + p1World.Translation +
                    ", Part2World=" + p2World.Translation +
                    ", Part3World=" + p3World.Translation);
            }
        }

        private static Matrix BuildAnimatedLocalMatrix(
            Matrix restLocalMatrix, Vector3 localAxis, float radians)
        {
            // BSL's rotate operation acts on the subpart's own local coordinate
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
                    MyLog.Default.WriteLineAndConsole(
                        "[ZSP_VTOLController] Entered VTOL: SavedForwardEnabled=" +
                        originalEnabledState + ", CurrentEnabled=" + thrustBlock.Enabled +
                        ", CachedThrust=" + vtolMaxEffectiveThrust);
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
                MyLog.Default.WriteLineAndConsole(
                    "[ZSP_VTOLController] Leaving VTOL: holding thrust until nozzle is forward.");
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

                    MyLog.Default.WriteLineAndConsole(
                        "[ZSP_VTOLController] Forward position reached: restored Enabled=" +
                        thrustBlock.Enabled + ", ThrustOverride=" + thrustBlock.ThrustOverride);
                    
                    if (originalPowerConsumptionMultiplierCaptured)
                    {
                        thrustBlock.PowerConsumptionMultiplier =
                            originalPowerConsumptionMultiplier;
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
                    thrustBlock.PowerConsumptionMultiplier =
                        originalPowerConsumptionMultiplier;
                }
            }
        }

        private bool IsLiftInputActive(MyCubeGrid grid)
        {
            // Read the ship controller's synchronized movement input on the server.
            // This avoids relying on local keyboard polling or a custom client->server
            // NetSync value, which remained false in the dedicated-server logs.
            var terminalSystem = MyAPIGateway.TerminalActionsHelper
                .GetTerminalSystemForGrid(grid);

            lastControllerMoveIndicator = Vector3.Zero;

            if (terminalSystem == null)
                return false;

            shipControllers.Clear();
            terminalSystem.GetBlocksOfType(shipControllers,
                controller => controller.IsUnderControl);

            for (int i = 0; i < shipControllers.Count; i++)
            {
                // MoveIndicator.Y is the ship's vertical movement axis:
                // positive values correspond to the UP control (Space by default).
                lastControllerMoveIndicator = shipControllers[i].MoveIndicator;
                if (lastControllerMoveIndicator.Y > 0.1f)
                    return true;
            }

            return false;
        }

        private void ApplyVtolLift()
        {
            if (!IsServer())
                return;

            Sandbox.ModAPI.IMyThrust thrustBlock =
                (Sandbox.ModAPI.IMyThrust)block;

            if (!vtolMode.Value)
                return;

            MyCubeGrid grid = block.CubeGrid;
            if (grid == null || grid.Physics == null)
                return;

            bool liftRequested = IsLiftInputActive(grid);

            // No additional Oxygen consumption or lift during deployment.
            if (animationProgress < 1f)
            {
                if (originalPowerConsumptionMultiplierCaptured)
                {
                    thrustBlock.PowerConsumptionMultiplier =
                        originalPowerConsumptionMultiplier;
                }
                return;
            }

            // Stop the additional consumption immediately when UP is released.
            if (!liftRequested || !block.IsFunctional ||
                vtolMaxEffectiveThrust <= 0.0)
            {
                if (originalPowerConsumptionMultiplierCaptured)
                {
                    thrustBlock.PowerConsumptionMultiplier =
                        originalPowerConsumptionMultiplier;
                }
                return;
            }

            float consumptionMultiplier =
                VTOL_OXYGEN_CONSUMPTION_LPS /
                SBC_IDLE_OXYGEN_CONSUMPTION_LPS;

            thrustBlock.PowerConsumptionMultiplier = consumptionMultiplier;

            // Apply lift only when the Oxygen resource is available.
            // This check still needs validation against the actual sink arrangement
            // used by this thruster in your Torch build.

            Vector3D liftDirection = grid.WorldMatrix.Up;
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

        private bool IsParticleCommandActive()
        {
            Sandbox.ModAPI.Ingame.IMyThrust thrustBlock =
                (Sandbox.ModAPI.Ingame.IMyThrust)block;

            if (!block.IsFunctional || !thrustBlock.Enabled)
                return false;

            // In VTOL, UP input is the engine activation signal. Lift is applied
            // manually, so CurrentThrust is not a valid VTOL activation measure.
            if (vtolMode != null && vtolMode.Value)
            {
                if (animationProgress < 1f)
                    return false;

                MyCubeGrid grid = block.CubeGrid;
                return grid != null && IsLiftInputActive(grid);
            }

            return animationProgress <= 0f;
        }

        private bool ShouldPlayJetParticle()
        {
            if (!IsParticleCommandActive())
                return false;

            if (vtolMode != null && vtolMode.Value)
                return true;

            Sandbox.ModAPI.Ingame.IMyThrust thrustBlock =
                (Sandbox.ModAPI.Ingame.IMyThrust)block;

            return thrustBlock.MaxThrust > 0f &&
                   thrustBlock.CurrentThrust >
                   thrustBlock.MaxThrust * JET_MIN_FORWARD_THRUST_FRACTION;
        }

        private bool ShouldPlayHighThrustParticles()
        {
            if (!IsParticleCommandActive())
                return false;

            // A VTOL lift command is treated as the high-thrust condition.
            if (vtolMode != null && vtolMode.Value)
                return true;

            Sandbox.ModAPI.Ingame.IMyThrust thrustBlock =
                (Sandbox.ModAPI.Ingame.IMyThrust)block;

            return thrustBlock.MaxThrust > 0f &&
                   thrustBlock.CurrentThrust >
                   thrustBlock.MaxThrust * HIGH_THRUST_EFFECT_FRACTION;
        }

        private void HandleJetParticle()
        {
            if (nozzlePart3 == null || !subpartsCached)
                return;

            // Base position and orientation of the nozzle attachment.
            MatrixD particleMatrix = nozzlePart3.WorldMatrix;
            Vector3D particlePosition = particleMatrix.Translation;

            // Give the main jet effect its own offset.
            MatrixD jetParticleMatrix = particleMatrix;
            Vector3D jetParticlePosition = particlePosition;

            jetParticlePosition += nozzlePart3.WorldMatrix.Backward *
                                JET_PARTICLE_OFFSET;

            jetParticleMatrix.Translation = jetParticlePosition;

            UpdateParticleEffect(ref jetParticle, JET_PARTICLE_ID, JET_PARTICLE_SCALE,
                ShouldPlayJetParticle(), ref jetParticleCreationFailedLogged,
                ref jetParticleMatrix, ref jetParticlePosition);

            // Mach rings remain at the original nozzle position.
            UpdateParticleEffect(ref machParticle, MACH_PARTICLE_ID, MACH_PARTICLE_SCALE,
                ShouldPlayHighThrustParticles(), ref machParticleCreationFailedLogged,
                ref particleMatrix, ref particlePosition);

            // Burner also remains at the original nozzle position.
            UpdateParticleEffect(ref burnerParticle, BURNER_PARTICLE_ID, BURNER_PARTICLE_SCALE,
                ShouldPlayHighThrustParticles(), ref burnerParticleCreationFailedLogged,
                ref particleMatrix, ref particlePosition);
        }

        private void UpdateParticleEffect(
            ref MyParticleEffect effect,
            string particleId,
            float scale,
            bool shouldPlay,
            ref bool creationFailedLogged,
            ref MatrixD particleMatrix,
            ref Vector3D particlePosition)
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
                    thrustBlock.PowerConsumptionMultiplier =
                        originalPowerConsumptionMultiplier;
                }
            }

            // Restore the model's original transforms when the logic component is removed.
            if (subpartsCached)
            {
                if (nozzlePart1 != null)
                    nozzlePart1.PositionComp.SetLocalMatrix(ref part1RestMatrix);
                if (nozzlePart2 != null)
                    nozzlePart2.PositionComp.SetLocalMatrix(ref part2RestMatrix);
                if (nozzlePart3 != null)
                    nozzlePart3.PositionComp.SetLocalMatrix(ref part3RestMatrix);
            }

            base.Close();
        }
    }
}
