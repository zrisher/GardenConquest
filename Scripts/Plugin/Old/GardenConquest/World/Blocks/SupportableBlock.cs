/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sandbox.Definitions; // from Sandbox.Game.dll
using Sandbox.Game.Entities; // from Sandbox.Game.dll
using Sandbox.ModAPI;

using VRage; // from VRage.dll and VRage.Library.dll
using VRage.Game; // from VRage.Game.dll
using VRage.Game.Entity; // from VRage.Game.dll
using VRage.Game.ModAPI; // from VRage.Game.dll
using VRage.Game.ModAPI.Interfaces;
using VRage.ModAPI; // from VRage.Game.dll
using VRage.ObjectBuilders;
using VRage.Utils;

using Ingame = Sandbox.ModAPI.Ingame;
using Ingame2 = VRage.Game.ModAPI.Ingame;

using SEGarden.Logging;
using SEGarden.World.Inventory;

using GC.App.BlockTaxonomy;
using GC.Sessions;


namespace GC.World.Blocks {

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// TODO: Only disable if enabled cost is nonzero
    /// </remarks>
    public class SupportableBlock {

        #region Static Fields

        public const uint DECAY_DAMAGE = 100;

        static readonly Logger Log = new Logger("GC.World.Blocks.SupportableBlock");
        static readonly MyStringHash DecayDamageType = MyStringHash.GetOrCompute("Decay");

        #endregion
        #region Fields

        public readonly IMySlimBlock Slim;
        //public IMyCubeBlock Fat;
        private IMyFunctionalBlock Functional;
        private bool SkipEnableEnforce;

        #endregion
        #region Properties

        public BlockType Type { 
            get; 
            private set; 
        }

        public bool Supported {
            get;
            private set;
        }

        public bool EnableAllowed {
            get;
            private set;
        }

        public ItemCountsAggregate BasicCost {
            get { return Type.BasicCost; }
        }

        public ItemCountsAggregate EnabledCost {
            get { return Type.EnabledCost; }
        }

        public int EnablePriority {
            get { return Type.EnablePriority; }
        }

        public bool Enableable {
            get { return Functional != null; }
        }

        /// <remarks>
        /// Eventually we might want to do more sophisticated checks for 
        /// blocks that do most of their work in a higher state than "ON",
        /// </remarks>
        public bool Enabled {
            get { return Enableable && Functional.Enabled; }
        }

        #endregion
        #region Constructors

        public SupportableBlock(IMySlimBlock slimblock) {
            //Type = BlockType.GetFirstMatching(slimblock);
            //Slim = slimblock;
            //Functional = slimblock.FatBlock as IMyFunctionalBlock;
            // 
            //if (Functional != null) {
            //    Functional.EnabledChanged += EnforceEnableState;
            //    Functional.OnClose += Close;
            //}
        }

        #endregion
        #region Public Support Changes

        public void MarkSupported() {
            Log.Trace("Marking supported " + Slim.ToString(), "MarkSupported");
            Supported = true;
        }

        public void MarkDecaying() {
            Log.Trace("Marking decaying " + Slim.ToString(), "MarkDecaying");
            Supported = false;
            if (Enabled) {
                DisallowEnable();
            }
        }

        public void AllowEnable() {
            Log.Trace("AllowEnabling " + Slim.ToString(), "AllowEnable");
            if (!EnableAllowed) {
                EnableAllowed = true;
                SetEnabled(true);
            }
        }

        public void DisallowEnable() {
            Log.Trace("DisallowingEnable " + Slim.ToString(), "ForceDisable");
            if (EnableAllowed) {
                EnableAllowed = false;
                SetEnabled(false);
            }
        }

        public void Decay() {
            if (!(Slim is IMyDestroyableObject)) {
                Log.Error("Received a slim that wouldn't cast to IMyDestroyable", "Decay");
                return;
            }

            (Slim as IMyDestroyableObject).DoDamage(DECAY_DAMAGE, DecayDamageType, true);
        }

        #endregion
        #region Entity Events

        private void Close(IMyEntity entity) {
            if (Functional == null) {
                Log.Error("Tracked functional lost before close event", "Close");
                return;
            }

            Functional.EnabledChanged -= EnforceEnableState;
            Functional.OnClose -= Close;
        }

        private void EnforceEnableState(IMyTerminalBlock terminalBlock) {
            if (SkipEnableEnforce) {
                SkipEnableEnforce = false;
                return;
            }

            Log.Trace("User changed enabled state of " + Slim.ToString(), "EnforceEnableState");

            //IMyFunctionalBlock functional = terminalBlock as IMyFunctionalBlock;
            //
            //if (functional == null) {
            //    Log.Error("Received enabledChanged with nonfunctional block", "EnabledChanged");
            //    return;
            //}
            //
            //if (functional != Functional) {
            //    Log.Error("Received enabledChanged for the wrong functional block", "EnabledChanged");
            //    return;
            //}

            // Force disable
            if (EnableAllowed || !Supported) {
                SetEnabled(false);
            }
        }

        #endregion
        #region Private Helpers

        private void SetEnabled(bool newState) {
            if (Functional != null && Functional.Enabled != newState) {
                SkipEnableEnforce = true;
                //functional.GetActionWithName("OnOff_Off").Apply(functional);
                Functional.RequestEnable(newState);
            }
        }

        #endregion

    }

}
*/