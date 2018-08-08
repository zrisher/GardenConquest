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
    /// Does stuff!
    /// </summary>
    /// <remarks>
    /// TODO: 
    /// make sure the inventories we're pulling from belong to the owner of the primary classifier
    /// get consumption working (throws internal SE networking errors...)
    /// enabled -> active, different from ON for drills, tools, others?
    /// active cost for blocks
    /// x frame requirement for running blocks, different FullRunCost = Support + x * Active
    /// reverse force disabled cost for save?
    /// </remarks>
    public class EnforcedGrid : EntityComponent {

        #region Helper Classes

        #endregion

        const int ENABLE_COST_LOOKAHEAD = 5;

        static readonly MySoundPair DecaySound = new MySoundPair("GcDecaySound");

        #region Static Access Helpers

        //protected static ServerSession Server {
        //    get { return ServerSession.Instance; }
        //}

        #endregion
        #region Static Events

        #endregion

        #region Fields

        public IMyCubeGrid Grid;
        GridInventoriesManager InventoryManager;
        private MyEntity3DSoundEmitter SoundEmitter;

        //GridUpkeepManager UpkeepManager;
        bool SupportNeedsUpdate;

        public Dictionary<IMySlimBlock, SupportableBlock> Blocks = new Dictionary<IMySlimBlock, SupportableBlock>();


        #endregion
        #region Properties


        // The properties that we send to client are set instead of dynamically calculated
        // We could calculate these on the fly, but storing and updating them instead
        // allows us to let the client know exactly what the server sees when they're
        // sent in messages. It also allows us to delay updating them until needed.

        // EntityComponent
        public override Dictionary<uint, Action> UpdateActions {
            get {
                var actions = base.UpdateActions;
                actions.Add(60, Update); // TODO tweak resolution
                actions.Add(300, DecayUnsupportedBlocks); // TODO tweak resolution
                return actions;
            }
        }

        public override string ComponentName { get { return "GC.EnforcedGrid"; } }

        // Grid

        /// <summary>
        /// The support cost for all currently supported blocks
        /// </summary>
        public ItemCountsAggregate CurrentBaseCost { get; private set; }

        public ItemCountsAggregate CurrentEnabledCost { get; private set; }

        public ItemCountsAggregate AvailableLicenses {
            get {
                return InventoryManager.Totals;
            }
        }

        public List<SupportableBlock> SupportedBlocks {
            get { return Blocks.Values.Where((x) => x.Supported).ToList();  }
        }

        public List<SupportableBlock> DecayingBlocks {
            get { return Blocks.Values.Where((x) => !x.Supported).ToList(); }
        }

        public List<SupportableBlock> ForceDisabledBlocks {
            get { return Blocks.Values.Where((x) => x.EnableAllowed).ToList(); }
        }

        #endregion
        #region Constructors

        // Byte Deserialization
        //public RevealedEntity(VRage.ByteStream stream) : base(stream) {
        //    // Nearly everything is available from the ingame Entity
        //    IsObserved = stream.getBoolean();
        //    IsRevealBlocked = stream.getBoolean();           
        //    List<long> entitiesViewedByList = stream.getLongList();
        //    foreach (long id in entitiesViewedByList) {
        //        EntitiesViewedBy.Add(id, null);
        //    }
        //    RevealedAt = stream.getDateTime();
        //
        //    MovedSinceIsInAsteroidCheck = true;
        //    Log.ClassName = "GP.Concealment.World.Entities.RevealedEntity";
        //    Log.Trace("Finished RevealedEntity deserialize constructor", "ctr");
        //}

        // Creation from ingame entity
        public EnforcedGrid(IMyEntity entity) : base(entity) {
            //Log.ClassName = "GC.World.Entities.EnforcedGrid";
            //Log.Trace("Start Grid constructor", "ctr");
            //Grid = Entity as IMyCubeGrid;
            //InventoryManager = new GridInventoriesManager(Grid, ServerSession.Instance.LicenseDefinitions.Keys.ToList());
            //CurrentBaseCost = ItemCountsAggregate.Zero;
            //CurrentEnabledCost = ItemCountsAggregate.Zero;
            //SoundEmitter = new MyEntity3DSoundEmitter(Grid as MyEntity);
            //Log.Trace("Grid name is " + Grid.DisplayName, "ctr");
            //Log.Trace("Finished Grid constructor", "ctr");
            //ServerSession.Instance.Grids.Add(this);
        }

        #endregion
        #region Init/Terminate

        public override void Initialize() {
            //Log.Trace("Initializing EnforcedGrid", "Terminate");
            //InventoryManager.Initialize();
            //InventoryManager.ContentsChanged += InventoryChanged;
			//
            //Grid.OnBlockAdded += BlockAdded;
            //Grid.OnBlockRemoved += BlockRemoved;
			//
            //List<IMySlimBlock> allBlocks = new List<IMySlimBlock>();
            //Grid.GetBlocks(allBlocks);
            //foreach (var block in allBlocks) {
            //    BlockAdded(block);
            //}
            //
            //base.Initialize();
        }

        public override void Terminate() {
            //Log.Trace("Terminating EnforcedGrid", "Terminate");
            //InventoryManager.ContentsChanged -= InventoryChanged;
            //InventoryManager.Terminate();

            //Grid.OnBlockAdded -= BlockAdded;
            //Grid.OnBlockRemoved -= BlockRemoved;

            //base.Terminate();
        }

        #endregion
        #region Serialization

        // Byte Serialization
        //public override void AddToByteStream(VRage.ByteStream stream) {
        //    base.AddToByteStream(stream);
        //    UpdateConcealabilityManual();
        //    stream.addBoolean(IsObserved);
        //    stream.addBoolean(IsRevealBlocked);
        //    stream.addLongList(EntitiesViewedBy.Keys.ToList());
        //    stream.addDateTime(RevealedAt);
        //}

        #endregion
        #region Update


        private void Update() {
            //if (SupportNeedsUpdate || !AvailableLicenses.Contains(CurrentBaseCost + CurrentEnabledCost * 5)) {
            //    UpdateSupport();
            //    SupportNeedsUpdate = false;
            //}
			//
            //RemoveSupportCostFromInventory();
        }


        private void RemoveSupportCostFromInventory() {
            Log.Trace("Current Available: " + AvailableLicenses.ToString(), "RemoveSupportCostFromInventory");
            Log.Trace("Current Basic Upkeep: " + CurrentBaseCost.ToString(), "RemoveSupportCostFromInventory");
            Log.Trace("Current Enabled Upkeep: " + CurrentEnabledCost.ToString(), "RemoveSupportCostFromInventory");

            ItemCountsAggregate toRemove = (CurrentBaseCost + CurrentEnabledCost) / 1000; // temporary, for testing     
            Log.Trace("toRemove: " + toRemove.ToString(), "RemoveSupportCostFromInventory");

            InventoryManager.Consume(ref toRemove);

            if (!toRemove.IsEmpty()) {
                Log.Error("Failed to remove from inventory " + toRemove.ToString(), "RemoveSupportCostFromInventory");
            }
        }

        private void DecayUnsupportedBlocks() {
            Log.Trace("Decaying.Count: " + DecayingBlocks.Count, "DecayUnsupportedBlocks");

            if (DecayingBlocks.Count == 0) return;

            foreach (var block in DecayingBlocks) {
                block.Decay();
            }

            SoundEmitter.PlaySound(DecaySound);

            //Log.Trace("Playing sound: ", "Update");
            //Log.Trace("Entity: " + m_soundEmitter.Entity.ToString(), "Update");
            //Log.Trace("IsPlaying: " + m_soundEmitter.IsPlaying.ToString(), "Update");
            //Log.Trace("SourcePosition: " + m_soundEmitter.SourcePosition.ToString(), "Update");
            //Log.Trace("VolumeMultiplier: " + m_soundEmitter.VolumeMultiplier.ToString(), "Update");
            //Log.Trace("SoundId: " + m_soundEmitter.SoundId.ToString(), "Update");
            //Log.Trace("SoundPair: " + m_soundEmitter.SoundPair.ToString(), "Update");
            //Log.Trace("SourceChannels: " + m_soundEmitter.SourceChannels.ToString(), "Update");
            //Log.Trace("Silenced: " + m_soundEmitter.Silenced.ToString(), "Update");
            //Log.Trace("Plays2D: " + m_soundEmitter.Plays2D.ToString(), "Update");
            //Log.Trace("CustomMaxDistance: " + m_soundEmitter.CustomMaxDistance.ToString(), "Update");
            //Log.Trace("CustomVolume: " + m_soundEmitter.CustomVolume.ToString(), "Update");
        }


        private void MarkAllSupported() {

        }

        

    }
}

/*
private void UpdateSupport() {
	UpdateBasicSupport();
	UpdateEnableSupport();
}

private void UpdateBasicSupport() {
	Log.Trace("Starting Update support " + DecayingBlocks.Count, "UpdateSupport");
	Log.Trace("AvailableLicenses: " + AvailableLicenses.ToString(), "UpdateSupport");
	Log.Trace("Beginning CurrentBaseCost: " + CurrentBaseCost.ToString(), "UpdateSupport");
	Log.Trace("Beginning Supported.Count: " + SupportedBlocks.Count, "UpdateSupport");
	Log.Trace("Beginning Decaying.Count: " + DecayingBlocks.Count, "UpdateSupport");

	if (DecayingBlocks.Count == 0 && AvailableLicenses.Contains(CurrentBaseCost) ) {
		return;
	}

	CurrentBaseCost = ItemCountsAggregate.Zero;
	ItemCountsAggregate availableNextUpdate = AvailableLicenses.Copy();
	//DecayingBlocks.AddRange(SupportedBlocks);
	//SupportedBlocks.Clear();

	foreach (var block in Blocks.Values) {
		if (availableNextUpdate.Contains(block.BasicCost)) {
			block.MarkSupported();
			CurrentBaseCost += block.BasicCost;
			availableNextUpdate -= block.BasicCost;
		}
		else {
			block.MarkDecaying();
		}
	}

	Log.Trace("Finishing Update support " + DecayingBlocks.Count, "UpdateSupport");
	Log.Trace("AvailableLicenses: " + AvailableLicenses.ToString(), "UpdateSupport");
	Log.Trace("Final CurrentBaseCost: " + CurrentBaseCost.ToString(), "UpdateSupport");
	Log.Trace("Final Supported.Count: " + SupportedBlocks.Count, "UpdateSupport");
	Log.Trace("Final Decaying.Count: " + DecayingBlocks.Count, "UpdateSupport");
}

private void UpdateEnableSupport() {
	ItemCountsAggregate availableNextUpdate = AvailableLicenses - CurrentBaseCost;

	Log.Trace("Starting UpdateEnabledSupport" + DecayingBlocks.Count, "UpdateEnableSupport");
	Log.Trace("availableNextUpdate: " + availableNextUpdate.ToString(), "UpdateEnableSupport");
	Log.Trace("Beginning CurrentEnabledCost: " + CurrentEnabledCost.ToString(), "UpdateEnableSupport");
	Log.Trace("Beginning ForceDisabledBlocks.Count: " + ForceDisabledBlocks.Count, "UpdateEnableSupport");


	// todo: increment currentenabledcost with block changes like basecost
	if (ForceDisabledBlocks.Count == 0 && availableNextUpdate.Contains(CurrentEnabledCost * ENABLE_COST_LOOKAHEAD)) {
		Log.Trace("No disabled blocks & plenty of licenses, returning early.", "UpdateEnableSupport");
		return;
	}

	CurrentEnabledCost = ItemCountsAggregate.Zero;


	foreach (var block in Blocks.Values.Where((x)=>x.Enableable).OrderBy((x)=>x.EnablePriority)) {
		if (availableNextUpdate.Contains(block.EnabledCost * ENABLE_COST_LOOKAHEAD)) {
			block.AllowEnable();
			if (block.Enabled) {
				CurrentEnabledCost += block.EnabledCost;
				availableNextUpdate -= block.EnabledCost * ENABLE_COST_LOOKAHEAD;
			}                   
		}
		else {
			if (block.Enabled) {
				block.DisallowEnable();
			}   
		}
	}

	Log.Trace("Ending UpdateEnabledSupport" + DecayingBlocks.Count, "UpdateEnableSupport");
	Log.Trace("availableNextUpdate: " + availableNextUpdate.ToString(), "UpdateEnableSupport");
	Log.Trace("Ending CurrentEnabledCost: " + CurrentEnabledCost.ToString(), "UpdateEnableSupport");
	Log.Trace("Ending ForceDisabledBlocks.Count: " + ForceDisabledBlocks.Count, "UpdateEnableSupport");

}

private void UpdateClass() {
	// if grid has changed
	// take a look at all blocks, and given set classes find closest and if it applies
}

private void UpdateClassifiers() {
	// ensure they're on and have current name as name, range is good
}

#endregion
#region Events

private void BlockAdded(IMySlimBlock slimblock) {
	//Log.Trace(slimblock.ToString() + " added to InventoryManager for " + Grid.DisplayName, "blockAdded");

	if (slimblock == null) {
		Log.Error("Received null slimblock", "blockAdded");
		return;
	}

	SupportableBlock block = new SupportableBlock(slimblock);

	Blocks[slimblock] = block;
	Log.Trace(String.Format("Does available {0} contain cost {1}?", AvailableLicenses.ToString(), block.BasicCost.ToString()), "BlockAdded");
	if (AvailableLicenses.Contains(block.BasicCost)) {
		Log.Trace("It does! Marking supported", "BlockAdded");
		block.MarkSupported();
		CurrentBaseCost += block.BasicCost;
	}

	Log.Trace(String.Format("Is the block enabled, and if so are we missing {0} in {1}", (AvailableLicenses - block.BasicCost).ToString(), (block.EnabledCost * 5).ToString()), "BlockAdded");
	if (block.Enabled & !(AvailableLicenses - block.BasicCost).Contains(block.EnabledCost * 5)) {
		Log.Trace("Yep, force disabling.", "BlockAdded");
		block.DisallowEnable();
	}
	else {
		CurrentEnabledCost += block.EnabledCost;
	}
}

private void BlockRemoved(IMySlimBlock slimblock) {
	//Log.Trace(slimblock.ToString() + " removed from InventoryManager for " + Grid.DisplayName, "blockRemoved");

	if (slimblock == null) {
		Log.Error("Received null slimblock", "blockRemoved");
		return;
	}

	SupportableBlock block = Blocks[slimblock];
	if (block.Supported) {
		CurrentBaseCost -= block.BasicCost;
	}
	if (block.Enabled) {
		CurrentEnabledCost -= block.EnabledCost;
	}
	Blocks.Remove(slimblock);
}

private void InventoryChanged(ItemCountsAggregate change) {
	Log.Trace("Grid's inventory was changed.", "InventoryChanged");

	//if (!ExpectingInventoryConsumption) {
		Log.Trace("Marking support needs update", "InventoryChanged");
		SupportNeedsUpdate = true;
	//}
	//else {
	//    Log.Trace("Ignoring because we expected some consumption", "InventoryChanged");
	//    ExpectingInventoryConsumption = false;       
	//}        
}
#endregion
*/
