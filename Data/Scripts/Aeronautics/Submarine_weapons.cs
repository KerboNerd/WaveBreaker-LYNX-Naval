using System;
using System.Text;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using VRage.Game.Components;
using VRage.ObjectBuilders;
using VRageMath;
using Jakaria.API;

namespace TTNavalWeapons.SubmarineLogic
{
    [MyEntityComponentDescriptor(
        typeof(MyObjectBuilder_ConveyorSorter),
        true,
        new string[] { "TTMK48Square", "TTMK48Sloped1x2", "TTMK48Sloped", "TTSHIPSONAR", "TTSUBSONAR" })]
    public class SubmarineWeaponComponent : MyGameLogicComponent
    {
        // CONFIG
        private const float MaxDepthMeters = 300f; // too-deep cutoff

        // Refs
        private MyConveyorSorter _sorter;
        private IMyTerminalBlock _terminal;
        private IMyFunctionalBlock _func;

        // State
        private float _depthMeters;
        private bool _isUnderwater;
        private bool _lastEnabled;
        private string _lastReason = "";
        private bool _inited;

        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.Init(objectBuilder);

            _sorter   = Entity as MyConveyorSorter;
            _terminal = Entity as IMyTerminalBlock;
            _func     = Entity as IMyFunctionalBlock;

            if (_terminal != null)
                _terminal.AppendingCustomInfo += AppendCustomInfo;

            // Match method to flag: we implement UpdateAfterSimulation100, so enable EACH_100TH_FRAME.
            NeedsUpdate |= MyEntityUpdateEnum.EACH_100TH_FRAME;

            _inited = true;
        }

        public override void Close()
        {
            if (_terminal != null)
                _terminal.AppendingCustomInfo -= AppendCustomInfo;

            base.Close();
        }

        public override void UpdateAfterSimulation100()
        {
            // Defensive null checks: if anything critical is missing, bail out gracefully
            if (!_inited || _sorter == null || _terminal == null || _func == null || _sorter.PositionComp == null)
                return;

            Vector3D pos = _sorter.PositionComp.GetPosition();

            bool underwater = false;
            float depth = 0f;

            // WaterMod API can be absent or temporarily unavailable; guard it.
            try
            {
                underwater = WaterModAPI.IsUnderwater(pos);
                float? d = WaterModAPI.GetDepth(pos);
                depth = d.HasValue ? d.Value : 0f;  // conventionally positive meters below surface
            }
            catch
            {
                SetEnabled(false, "Disabled: Water API unavailable");
                return;
            }

            _isUnderwater = underwater;
            _depthMeters = depth;

            if (!underwater)
            {
                SetEnabled(false, "Disabled: Not underwater");
                return;
            }

            if (depth > MaxDepthMeters) // too deep
            {
                SetEnabled(false, "Disabled: Weapon is too deep");
                return;
            }

            SetEnabled(true, "Within parameters");
        }

        private void SetEnabled(bool shouldEnable, string reason)
        {
            // Only disable if currently enabled and should be disabled
            if (!shouldEnable && _func.Enabled)
                _func.Enabled = false;

            // Refresh terminal info only when user-visible state changes
            if (_lastEnabled != shouldEnable || _lastReason != reason)
            {
                _lastEnabled = shouldEnable;
                _lastReason = reason;
                _terminal.RefreshCustomInfo();
            }
        }

        private void AppendCustomInfo(IMyTerminalBlock block, StringBuilder info)
        {
            if (_func == null)
            {
                info.AppendLine("Status: Unknown (functional block missing)");
                return;
            }

            info.AppendLine("=== Submarine Weapon Control ===");
            info.AppendLine("Status: " + (_func.Enabled ? "Enabled" : "Disabled"));
            info.AppendLine("Reason: " + (string.IsNullOrEmpty(_lastReason) ? "—" : _lastReason));


            //info.AppendLine("Underwater: " + _isUnderwater);
            //info.AppendLine("Depth: " + Math.Round(_depthMeters, 1) + " m");
            info.AppendLine("Max Allowed Depth: " + MaxDepthMeters + " m");
        }
    }
}
