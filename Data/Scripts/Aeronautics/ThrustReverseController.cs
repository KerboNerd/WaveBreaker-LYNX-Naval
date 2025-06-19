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

namespace ware_LNX_Jet_Systems
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Thrust), true, "LXA_GENX8_Thruster")]
    public class GENX8_Controller : MyGameLogicComponent
    {
        public static bool warelnx_revthrustInit = false;

        public static string[] validSubTypes = { "LXA_GENX8_Thruster" };

        private MyThrust block;
        private bool preState = false;
        private NetSync<bool> state;
        private int ticks = 0;
        private int animationLength = 120;

        //
        private MyEntity SubPart;

        private const string SUBPART_NAME = "thrustReverser"; // dummy name without the "subpart_" prefix

        private bool subpartFirstFind = true;
        private Matrix subpartLocalMatrix; // keeping the matrix here because subparts are being re-created on paint, resetting their orientations
        private Vector3 MinMove = Vector3.Zero;
        private Vector3 CurMove = Vector3.Zero;
        private Vector3 MaxMove = Vector3.Forward / 2;
        //

        public void SetState(bool b)
        {
            state.Value = b;
        }

        public bool GetState()
        {
            return state.Value;
        }

        enum AnimationStatusEnum
        {
            None, Extend, Retract
        }

        private AnimationStatusEnum AnimStaus = AnimationStatusEnum.None;

        static bool ThrustReverseSwitchGetter(IMyTerminalBlock thruster)
        {
            GENX8_Controller logic = thruster.GameLogic.GetAs<GENX8_Controller>();
            return logic.GetState();
        }

        static bool ThrustReverserVisibilityCheck(IMyTerminalBlock thruster)
        {
            GENX8_Controller logic = thruster.GameLogic.GetAs<GENX8_Controller>();
            return validSubTypes.Contains(thruster.BlockDefinition.SubtypeId) && logic.AnimStaus == AnimationStatusEnum.None;
        }

        static void ThrustReverseSwitchSetter(IMyTerminalBlock thruster, bool newState)
        {

            GENX8_Controller logic = thruster.GameLogic.GetAs<GENX8_Controller>();
            logic.SetState(newState);
        }

        static void ThrustReverseSwitchToggle(IMyTerminalBlock thruster)
        {
            GENX8_Controller logic = thruster.GameLogic.GetAs<GENX8_Controller>();
            logic.SetState(!logic.GetState());
        }

        static void ThrustReverseSwitchHotbarText(IMyTerminalBlock thruster, StringBuilder hotbarText)
        {

            hotbarText.Clear();
            GENX8_Controller logic = thruster.GameLogic.GetAs<GENX8_Controller>();
            hotbarText.Append(logic.GetState() ? "ON" : "OFF");
        }

        static void CreateReverseThrustControlls()
        {
            if (warelnx_revthrustInit) return;
            warelnx_revthrustInit = true;
            var ReverseThrustSwitch = MyAPIGateway.TerminalControls.CreateControl<IMyTerminalControlOnOffSwitch, Sandbox.ModAPI.Ingame.IMyThrust>("ReverseThrustOnOff");
            ReverseThrustSwitch.Getter = ThrustReverseSwitchGetter;
            ReverseThrustSwitch.Setter = ThrustReverseSwitchSetter;
            ReverseThrustSwitch.Title = MyStringId.GetOrCompute("Thrust Reverse");
            ReverseThrustSwitch.OnText = MyStringId.GetOrCompute("ON");    // Typically "On" but can be any text
            ReverseThrustSwitch.OffText = MyStringId.GetOrCompute("OFF");      // Typically "Off" but can be any text
            ReverseThrustSwitch.Visible = ThrustReverserVisibilityCheck;
            ReverseThrustSwitch.SupportsMultipleBlocks = true;
            MyAPIGateway.TerminalControls.AddControl<Sandbox.ModAPI.Ingame.IMyThrust>(ReverseThrustSwitch);

            var ReverseThrustSwitchAction = MyAPIGateway.TerminalControls.CreateAction<Sandbox.ModAPI.Ingame.IMyThrust>("ReverseThrustOnOffToggle");
            ReverseThrustSwitchAction.Action = ThrustReverseSwitchToggle;
            ReverseThrustSwitchAction.Name = new StringBuilder("Thrust Reverse On/Off");
            ReverseThrustSwitchAction.Writer = ThrustReverseSwitchHotbarText;
            ReverseThrustSwitchAction.Enabled = ThrustReverserVisibilityCheck;
            ReverseThrustSwitchAction.ValidForGroups = true;
            MyAPIGateway.TerminalControls.AddAction<Sandbox.ModAPI.Ingame.IMyThrust>(ReverseThrustSwitchAction);
        }

        public override void UpdateOnceBeforeFrame()
        {
            base.UpdateOnceBeforeFrame(); CreateReverseThrustControlls();

            ushort comChannel = 8792; // the mod communication channel
            string ModName = "L.Y.N.X - Aeronautics"; // this will show up as the sender for any chat message notifications


            if (!NetworkAPI.IsInitialized)
            {
                NetworkAPI.Init(comChannel, ModName);
            }

            // initialize
            state = new NetSync<bool>(this, TransferType.Both, false);

            NeedsUpdate = MyEntityUpdateEnum.EACH_FRAME;
        }


        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.Init(objectBuilder);
            block = (MyThrust)Entity;

            SubPart = new MyEntity();
            SubPart.Init(new StringBuilder(SUBPART_NAME), ModContext.ModPath + @"\Models\Small\LXA_GENX8_ThrustReverser.mwm", (MyEntity)Entity, null, null);
            //Entity.Render.EnableColorMaskHsv = true;
            Entity.Render.CastShadows = true;
            SubPart.NeedsWorldMatrix = false;
            if (subpartFirstFind) // first time the subpart was found
            {
                subpartFirstFind = false;
                subpartLocalMatrix = SubPart.PositionComp.LocalMatrixRef;
            }

            NeedsUpdate = MyEntityUpdateEnum.BEFORE_NEXT_FRAME;
        }

        public override void Close()
        {
            Entity.Hierarchy.RemoveChild(SubPart);
            base.Close();
        }

        public override void UpdateAfterSimulation()
        {
            base.UpdateAfterSimulation();
            try
            {
                if (!block.IsFunctional) return;

                MyCubeGrid grid = block.CubeGrid;

                if (SubPart == null) return;

                if (state.Value != preState)
                {
                    if (state.Value)
                    {
                        AnimStaus = AnimationStatusEnum.Extend;
                    }
                    else
                    {
                        AnimStaus = AnimationStatusEnum.Retract;
                    }
                }

                if (ticks > animationLength)
                {
                    ticks = 0;
                    AnimStaus = AnimationStatusEnum.None;
                }

                if (AnimStaus != AnimationStatusEnum.None)
                {
                    Vector3 tmp;
                    if (AnimStaus == AnimationStatusEnum.Extend)
                    {
                        float i = (float)1 * (float)ticks / (float)animationLength;
                        CurMove = (MaxMove) * i;
                    }
                    else
                    {
                        float i = (float)1 * (float)ticks / (float)animationLength;
                        CurMove = MaxMove - (MaxMove) * i;
                    }
                    ticks++;
                }


                SubPart.PositionComp.SetLocalMatrix(ref subpartLocalMatrix);

                if (state.Value)
                {
                    float i = (float)1 * (float)ticks / (float)animationLength;
                    Vector3D force = block.WorldMatrix.Forward * block.BlockDefinition.ForceMagnitude * block.CurrentStrength * 1.70;
                    grid.Physics.AddForce(MyPhysicsForceType.APPLY_WORLD_FORCE, force, grid.Physics.CenterOfMassWorld, null);
                }
                subpartLocalMatrix.Translation = CurMove;
                SubPart.PositionComp.SetLocalMatrix(ref subpartLocalMatrix);
                preState = state.Value;
            }
            catch(Exception e) { }
        }

        private void AddToLog(Exception e)
        {
            MyLog.Default.WriteLineAndConsole($"ERROR {GetType().FullName}: {e.ToString()}");

            if (MyAPIGateway.Session?.Player != null)
                MyAPIGateway.Utilities.ShowNotification($"[ ERROR: {GetType().FullName}: {e.Message} | Send SpaceEngineers.Log to mod author ]", 10000, MyFontEnum.Red);

        }
    }
}