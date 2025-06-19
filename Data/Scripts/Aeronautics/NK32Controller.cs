using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using VRageMath;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using SpaceEngineers.Game.ModAPI;
using Sandbox.ModAPI.Interfaces.Terminal;
using System.Text;
using VRage.Utils;
using VRage;
using VRage.Game.ModAPI.Ingame;
using static VRage.Game.Entity.MyEntity;
using Sandbox.Game.Entities.Cube;
using SENetworkAPI;
using System.Net.Http.Headers;
using VRage.Audio;
using Sandbox.Game;
using RichHudFramework.Client;
using Sandbox.Game.Screens.Helpers;
using Sandbox.Game.World;
using System.Net.Sockets;

namespace ware_LNX_Jet_Systems
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Thrust), false, "LXN_NK32_01_Thruster")]
    public class NK32Controller : MyGameLogicComponent
    {
        public static string[] validSubTypes = { "LXN_NK32_01_Thruster" };

        NetSync<bool> afterBurner;
        public static bool warelnx_NK32tInit = false;
        private MyThrust block;

        private string afterburnerParticle = "LXN_Particle_Afterburner_01";
        MatrixD particle_matrix = MatrixD.Identity;
        Vector3D particle_position = Vector3D.Zero;
        MyParticleEffect particle;

        private string afterburnerSound = "LXN_NK32_BurnerThrust";
        private MySoundPair audio;
        private MyEntity3DSoundEmitter engineSound;

        public override void UpdateOnceBeforeFrame()
        {
            ushort comChannel = 8792; // the mod communication channel
            string ModName = "L.Y.N.X - Aeronautics"; // this will show up as the sender for any chat message notifications

            if (!NetworkAPI.IsInitialized)
            {
                NetworkAPI.Init(comChannel, ModName);
            }

            GenerateTerminalControlls();

            NeedsUpdate = MyEntityUpdateEnum.EACH_FRAME;
        }

        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.Init(objectBuilder);
            block = (MyThrust)Entity;

            afterBurner = new NetSync<bool>(this, TransferType.Both, false, limitToSyncDistance: true);

            engineSound = new MyEntity3DSoundEmitter(block);

            NeedsUpdate = MyEntityUpdateEnum.BEFORE_NEXT_FRAME;
        }

        public override void UpdateAfterSimulation()
        {
            ((IMyThrust)block).PowerConsumptionMultiplier = 1;
            float halfThrust = (((IMyThrust)block).MaxThrust / 2f);
            if (afterBurner.Value && ((IMyThrust)block).Enabled && ((IMyThrust)block).CurrentThrust > halfThrust)
            {
                ((IMyThrust)block).PowerConsumptionMultiplier = 4f;
                MyCubeGrid grid = block.CubeGrid;
                Vector3D force = block.WorldMatrix.Backward * block.BlockDefinition.ForceMagnitude * block.CurrentStrength * 0.52;
                grid.Physics.AddForce(MyPhysicsForceType.APPLY_WORLD_FORCE, force, grid.Physics.CenterOfMassWorld, null);
            }

            HandleParticle();
            HandleSound();

            base.UpdateAfterSimulation();
        }

        public void SetState(bool b)
        {
            afterBurner.Value = b;
        }

        public bool GetState()
        {
            return afterBurner.Value;
        }

        static bool AfterburnerGetter(IMyTerminalBlock thruster)
        {
            NK32Controller logic = thruster.GameLogic.GetAs<NK32Controller>();
            return logic.GetState();
        }

        static void AfterburnerSetter(IMyTerminalBlock thruster, bool newState)
        {

            NK32Controller logic = thruster.GameLogic.GetAs<NK32Controller>();
            logic.SetState(newState);
        }

        static bool TerminalVisibility(IMyTerminalBlock thruster)
        {
            NK32Controller logic = thruster.GameLogic.GetAs<NK32Controller>();
            return validSubTypes.Contains(thruster.BlockDefinition.SubtypeId);
        }

        static void AfterburnerHotbar(IMyTerminalBlock thruster, StringBuilder hotbarText)
        {
            hotbarText.Clear();
            NK32Controller logic = thruster.GameLogic.GetAs<NK32Controller>();
            hotbarText.Append(logic.GetState() ? "ON" : "OFF");
        }

        static void AfterburnerToggle(IMyTerminalBlock thruster)
        {
            NK32Controller logic = thruster.GameLogic.GetAs<NK32Controller>();
            logic.SetState(!logic.GetState());
        }

        static void GenerateTerminalControlls()
        {
            if (warelnx_NK32tInit) return;
            warelnx_NK32tInit = true;
            //Afterburner
            var Afterburner = MyAPIGateway.TerminalControls.CreateControl<IMyTerminalControlOnOffSwitch, Sandbox.ModAPI.Ingame.IMyThrust>("AFterburnerOnOffToggle");
            Afterburner.Getter = AfterburnerGetter;
            Afterburner.Setter = AfterburnerSetter;
            Afterburner.Title = MyStringId.GetOrCompute("Afterburner");
            Afterburner.OnText = MyStringId.GetOrCompute("ON");    // Typically "On" but can be any text
            Afterburner.OffText = MyStringId.GetOrCompute("OFF");      // Typically "Off" but can be any text
            Afterburner.Visible = TerminalVisibility;
            Afterburner.SupportsMultipleBlocks = true;
            MyAPIGateway.TerminalControls.AddControl<Sandbox.ModAPI.Ingame.IMyThrust>(Afterburner);

            var AfterburnerAction = MyAPIGateway.TerminalControls.CreateAction<Sandbox.ModAPI.Ingame.IMyThrust>("AFterburnerOnOffToggle");
            AfterburnerAction.Action = AfterburnerToggle;
            AfterburnerAction.Name = new StringBuilder("Afterburner On/Off");
            AfterburnerAction.Writer = AfterburnerHotbar;
            AfterburnerAction.Enabled = TerminalVisibility;
            AfterburnerAction.ValidForGroups = true;
            MyAPIGateway.TerminalControls.AddAction<Sandbox.ModAPI.Ingame.IMyThrust>(AfterburnerAction);
        }

        bool worked = false;
        private void HandleParticle()
        {
            float halfThrust = (((IMyThrust)block).MaxThrust / 2f);
            if (particle == null) //If particle doesnae exist, bring it into existence.
            {
                particle_matrix = block.WorldMatrix;
                particle_position = particle_matrix.Translation;
                if (afterBurner.Value && ((IMyThrust)block).Enabled && ((IMyThrust)block).CurrentThrust > halfThrust)
                    worked = MyParticlesManager.TryCreateParticleEffect(afterburnerParticle, ref particle_matrix, ref particle_position, uint.MaxValue, out particle);
                else
                {
                    if (particle != null)
                    {
                        particle.StopEmitting();
                        particle.StopLights();
                    }
                }
            }
            else //If it does exist, keep it playing.
            {
                if (afterBurner.Value && ((IMyThrust)block).Enabled && ((IMyThrust)block).CurrentThrust > halfThrust)
                {
                    particle.WorldMatrix = block.WorldMatrix;
                    particle.Update();
                    particle.UserLifeMultiplier = .5f;
                    particle.Play();

                }
                else
                {
                    particle.StopEmitting();
                    particle.StopLights();
                }
            }
        }

        private void HandleSound()
        {
            float halfThrust = (((IMyThrust)block).MaxThrust / 2f);
            if (afterBurner.Value && ((IMyThrust)block).Enabled && ((IMyThrust)block).CurrentThrust > halfThrust)
            {
                if (!engineSound.IsPlaying)
                {
                    audio = new MySoundPair(afterburnerSound);
                    engineSound.VolumeMultiplier = 1;
                    engineSound.CustomMaxDistance = 5000;
                    engineSound.PlaySoundWithDistance(audio.SoundId, false);
                }
            }
            else
            {
                engineSound.StopSound(true, true);
            }
        }

        public override void Close()
        {
            try
            {
                if (engineSound != null) {
                    engineSound.StopSound(true);
                    engineSound.Cleanup();
                }
                if (particle != null) //If the particle is still emitting, kill it.
                {
                    particle.Stop(false);
                    particle.StopEmitting();
                    particle.StopLights();
                    particle = null;
                }
            }
            catch (Exception ex)
            {
                AddToLog(ex);
            }
            base.Close();
        }

        private void AddToLog(Exception e)
        {
            MyLog.Default.WriteLineAndConsole($"ERROR {GetType().FullName}: {e.ToString()}");

            if (MyAPIGateway.Session?.Player != null)
                MyAPIGateway.Utilities.ShowNotification($"[ ERROR: {GetType().FullName}: {e.Message} | Send SpaceEngineers.Log to mod author ]", 10000, MyFontEnum.Red);

        }
    }
}
