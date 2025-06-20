using System;
using System.Text;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using VRage.Game.Components;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRageMath;
using Jakaria.API;

namespace TTWW2Weapons.SubmarineLogic
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_ConveyorSorter), true, new string[]{"TTMK15Square","TTMK15Sloped1x2","TTMK15Sloped"})]
    public class SubmarineWeaponComponent : MyGameLogicComponent
    {
        private MyConveyorSorter conveyorSorter;
        private IMyTerminalBlock terminalBlock;
        private IMyFunctionalBlock functionalBlock;

        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.Init(objectBuilder);
            conveyorSorter = (MyConveyorSorter)Entity;
            terminalBlock = Entity as IMyTerminalBlock;
            functionalBlock = Entity as IMyFunctionalBlock;

            if (terminalBlock != null)
            {
                terminalBlock.AppendingCustomInfo += AppendCustomInfo;
            }
            NeedsUpdate |= MyEntityUpdateEnum.EACH_FRAME | MyEntityUpdateEnum.EACH_10TH_FRAME;
        }

        public override void UpdateAfterSimulation100()
        {
            if (WaterModAPI.IsUnderwater(conveyorSorter.PositionComp.GetPosition()))
            {
                EnableBlock();
            }
            else
            {
                DisableBlock("Disabled: Block is not underwater");
            }
        }

        private void DisableBlock(string reason)
        {
            if (functionalBlock == null || !functionalBlock.Enabled)
                return;

            functionalBlock.Enabled = false;
            terminalBlock.RefreshCustomInfo();
        }

        private void EnableBlock()
        {
            if (functionalBlock == null || functionalBlock.Enabled)
                return;

            functionalBlock.Enabled = true;
            terminalBlock.RefreshCustomInfo();
        }

        private void AppendCustomInfo(IMyTerminalBlock block, StringBuilder info)
        {
            if (functionalBlock != null && !functionalBlock.Enabled)
            {
                info.AppendLine("Status: Disabled");
                info.AppendLine("Reason: Weapon can only be operated underwater");
            }
            else
            {
                info.AppendLine("Status: Enabled");
            }
        }

        public override void Close()
        {
            if (terminalBlock != null)
            {
                terminalBlock.AppendingCustomInfo -= AppendCustomInfo;
            }
            base.Close();
        }
    }
}