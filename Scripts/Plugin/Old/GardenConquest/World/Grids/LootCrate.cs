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
using VRage.ModAPI; // from VRage.Game.dll
using VRage.ObjectBuilders;

using SEGarden.Extensions;
using SEGarden.Logging;
using SEGarden.Logic;
using SEGarden.World.Inventory;

using GC.Sessions;
using GC.World.Blocks;


namespace GC.World.Grids {

    /// <summary>
    /// Represents a grid added to the world by a CP to hold loot.
    /// Tells the grid not to save, and removes it if inventory is emptied.
    /// </summary>
    /// <remarks>
    /// The CPs track these to ensure they don't overpopulate. Since there's
    /// no hooks for position changes, they do distance calcs each update.
    /// </remarks>
    public class LootCrate : EntityComponent {

        #region Static

        const String DISPLAY_NAME_SHARED = "GC Loot Crate";

        public static readonly HashSet<LootCrate> All =
            new HashSet<LootCrate>();

        static readonly Logger Log = new Logger("GC.World.Grids.LootCrate");

        public static bool IsLootCrate(IMyEntity entity) {
            return entity is IMyCubeGrid &&
                ((IMyCubeGrid)entity).DisplayName.
                    LooseContains(DISPLAY_NAME_SHARED);
        }

        #endregion
        #region Members

        public override Dictionary<uint, Action> UpdateActions {
            get {
                var actions = base.UpdateActions;
                //actions.Add(60, Update); // TODO tweak resolution
                return actions;
            }
        }

        public override string ComponentName { 
            get { return "GC.World.Grids.LootCrate"; } 
        }

        readonly IMyCubeGrid Grid;
        readonly GridInventoriesManager InventoryManager;

        #endregion

        public LootCrate(IMyEntity entity) : base(entity) {
            Grid = entity as IMyCubeGrid;

            if (Grid == null)
                throw new ArgumentException("Expected a cubegrid.");
            if (!Grid.DisplayName.LooseContains(DISPLAY_NAME_SHARED))
                throw new ArgumentException(String.Format(
                    "Expected \"{0}\" to contain \"{1}\"", 
                    Grid.DisplayName, DISPLAY_NAME_SHARED
                ));

            Grid.Save = false;
            InventoryManager = new GridInventoriesManager(Grid);
        }

        #region Init/Terminate

        public override void Initialize() {
            Log.Trace("Initializing LootCrate", "Terminate");
            InventoryManager.Initialize();
            InventoryManager.ContentsChanged += InventoryChanged;
            All.Add(this);
            base.Initialize();
        }

        public override void Terminate() {
            Log.Trace("Terminating LootCrate", "Terminate");
            InventoryManager.ContentsChanged -= InventoryChanged;
            InventoryManager.Terminate();
            All.Remove(this);
            base.Terminate();
        }

        #endregion
        #region Update

        private void Update() { }

        #endregion
        #region Events

        private void InventoryChanged(ItemCountsAggregate change) {
            if (InventoryManager.Totals.IsEmpty()) {
                Grid.SyncObject.SendCloseRequest();
            }     
        }

        #endregion     

    }
}
*/