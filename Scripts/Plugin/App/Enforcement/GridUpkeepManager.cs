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

using SEGarden.Logging;

using GC.World.Blocks;

namespace GC.World.Grids {

    class GridUpkeepManager {
        //List<BlockGroup> BlocksGroupedByType;

        //InventoryItemsCount CurrentUpkeep;
        //InventoryItemsCount FullSupportCost;
        //InventoryItemsCount FullSupportAndEnableCost;

        //bool UpdateSupportNextUpdate;

        readonly Logger Log;
        readonly IMyCubeGrid Grid;
        

        public GridUpkeepManager(EnforcedGrid enforcedGrid, List<MyComponentDefinition> watchedItems) {
            Grid = enforcedGrid.Grid;
            Log = new Logger("GC.World.Entities.Grids.GridUpkeepManager", (() => Grid.EntityId.ToString()));
        }

    }

}
*/

/*
public void Initialize() {
	Grid.OnBlockAdded += BlockAdded;
	Grid.OnBlockRemoved += BlockRemoved;

	List<IMySlimBlock> allBlocks = new List<IMySlimBlock>();
	Grid.GetBlocks(allBlocks);
	foreach (var block in allBlocks) {
		BlockAdded(block);
	}
}

public void Terminate() {
	Grid.OnBlockAdded -= BlockAdded;
	Grid.OnBlockRemoved -= BlockRemoved;

	//foreach (var inventory in Counts.Keys) {
	//    inventory.ContentsChanged -= UpdateInventory;
	//}
}

private void BlockAdded(IMySlimBlock slimblock) {
	//Log.Trace(slimblock.ToString() + " added to InventoryManager for " + Grid.DisplayName, "blockAdded");

	if (slimblock == null) {
		Log.Error("Received null slimblock", "blockAdded");
		return;
	}

	UnsupportedBlocks[slimblock] = new EnableableBlock(slimblock);
	UpdateSupportNextUpdate = true;
}

private void BlockRemoved(IMySlimBlock slimblock) {
	//Log.Trace(slimblock.ToString() + " removed from InventoryManager for " + Grid.DisplayName, "blockRemoved");

	if (slimblock == null) {
		Log.Error("Received null slimblock", "blockRemoved");
		return;
	}

	if (!SupportedBlocks.Remove(slimblock))
		if (!ForcedDisabledBlocks.Remove(slimblock))
			if (!UnsupportedBlocks.Remove(slimblock))
				Log.Error("Block wasn't tracked", "blockRemoved");

	UpdateSupportNextUpdate = true;
}


private void Update() {
	// If (UpdateSupportNextFrame || licensesAvailable < currentUpkeep)
	//   updateSupportedBlocks

	RemoveSupportCostFromInventory();

	DecayUnsupportedBlocks();
}

private void UpdateSupport() {
	CurrentUpkeep = InventoryItemsCount.Zero;
	UpdateBasicSupport();
	UpdateEnabledSupport();
}

/// <summary>
/// Determine which blocks can be supported and which can't
/// Determine current corrected support cost
/// </summary>
private void UpdateBasicSupport() {


	// No support
	if (LicensesAvailable.IsEmpty()) {
		foreach (var group in BlocksGroupedByType) {
			group.MarkAllUnsupported();
		}

		return;
	}

	// Full support
	if (LicensesAvailable.Contains(FullSupportCost)) {
		foreach (var group in BlocksGroupedByType) {
			group.MarkAllSupported();
		}

		CurrentUpkeep += FullSupportCost;
		return;
	}

	// Partial support
	foreach (var group in BlocksGroupedByType) {

		// No support for this group
		if (!LicensesAvailable.Contains(group.Type.BasicCost)) {
			group.MarkAllUnsupported();
			continue;
		}

		// Full support for this group
		if (LicensesAvailable.Contains(group.FullSupportCost)) {
			group.MarkAllSupported();
			CurrentUpkeep += group.FullSupportCost;
			continue;
		}

		// Partial support for this group
		else if (LicensesAvailable.Contains(group.FullSupportCost)) {
			group.MarkAllSupported();
		}

		group.MarkAllUnsupported();
		return;
	}




	// Go through each block in order of EnablePriority
	//   Support every remaining block with a SupportPriority >= this EnablePriority (including this one)
	//   Support it if not supported
	//   Enable it if not enabled
	//   next
	//
	//  
	//   if blockCanBeSwitchedToLowerCostState && lowSupportFor(block)
	//     switch to lower state
	//
	//   if blockSupportCost < availableSupport
	//     addToSupported
	//     currentSupportCost -= blockSupportCost
	//     continue
	//
	//   addToUnsupported

	// 
	// currentSupportCost = 0
	// Go through each block in some priority order
	//
	//   if blockCanBeSwitchedToLowerCostState && lowSupportFor(block)
	//     switch to lower state
	//
	//   if blockSupportCost < availableSupport
	//     addToSupported
	//     currentSupportCost -= blockSupportCost
	//     continue
	//
	//   addToUnsupported
	//    
}

private void RemoveSupportCostFromInventory() {

}

/// <summary>
/// Ensure they're all off
/// Remove a bit of health
/// </summary>
private void DecayUnsupportedBlocks() {

}


private void DebugPrint() {
	Log.Debug("Displaying inventory contents for grid: " + Grid.DisplayName, "DebugInventories");

	foreach (var kvp in Counts) {
		Log.Debug("  contents for block: " + kvp.Key.Entity.ToString(), "DebugInventories");

		foreach (var def in WatchedItems) {
			Log.Debug("    " + def.DisplayNameText + " - " + kvp.Value.Counts[def.Id], "DebugInventories");
		}
	}
}
*/