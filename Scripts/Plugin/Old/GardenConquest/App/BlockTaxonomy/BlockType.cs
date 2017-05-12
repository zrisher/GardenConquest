/*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Sandbox.Definitions; // from Sandbox.Game.dll
using Sandbox.Game.Entities; // from Sandbox.Game.dll
using Sandbox.ModAPI;

using VRage; // from VRage.dll and VRage.Library.dll
using VRage.Game; // from VRage.Game.dll
using VRage.Game.Entity; // from VRage.Game.dll
using VRage.Game.ModAPI; // from VRage.Game.dll
using VRage.ModAPI; // from VRage.Game.dll
using VRage.ObjectBuilders;

using SEGarden.Definitions;
using SEGarden.Logging;
using SEGarden.Extensions;
using SEGarden.World.Inventory;

using GC.Definitions.BlockTaxonomy;


namespace GC.App.BlockTaxonomy {

    /// <summary>
    /// A named group of partial Block SubType names.
    /// Loaded from config and editable at runtime.
    /// </summary>
    [XmlType("BlockType")]
    public class BlockType {

        static readonly Logger Log = new Logger("GC.World.Blocks.BlockType");

        public readonly String Name;
        public readonly MyFixedPoint CostMultiplier;
        public readonly int EnablePriority;
        public readonly List<String> SubtypePartialNames;
        public readonly BlockTypeCategory Category;
        public readonly ItemCountsAggregate BasicCost;
        public readonly ItemCountsAggregate EnabledCost;
        public readonly ItemCountsAggregate BigBlockBasicCost;
        public readonly ItemCountsAggregate BigBlockEnabledCost;

        #region Constructors

        /// <summary>
        /// Construct directly
        /// </summary>
        public BlockType(
            String name, BlockTypeCategory category, 
            double costMultiplier, int enablePriority,
            List<String> subtypePartialNames
        ) {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be null");
            if (costMultiplier < 0)
                throw new ArgumentException("costMultiplier must be > 0");
            if (subtypePartialNames == null || subtypePartialNames.Count == 0)
                throw new ArgumentException("subtypePartialNames cannot be empty");
            if (category == null)
                throw new ArgumentException("category cannot be null");
            if (category.BaseCost == null)
                throw new ArgumentException("category base cost cannot be null");

            Name = name;
            Category = category;
            CostMultiplier = (MyFixedPoint)costMultiplier;
            EnablePriority = enablePriority;
            SubtypePartialNames = subtypePartialNames;
            BasicCost = Category.BaseCost * CostMultiplier;
            EnabledCost = BasicCost * Category.EnabledMultiplier;
            BigBlockBasicCost = BasicCost * Category.BigBlockMultiplier;
            BigBlockEnabledCost = BasicCost * Category.BigBlockMultiplier;
        }

        /// <summary>
        /// Construct from definition
        /// </summary>
        public BlockType(
            BlockTypeDefinition definition, BlockTypeCategory category
        ) {
            String name = definition.Name;
            double costMultiplier = definition.CostMultiplier;
            int enablePriority = definition.EnablePriority;
            List<String> subtypePartialNames = definition.SubtypePartialNames;          

            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be null");
            if (costMultiplier < 0)
                throw new ArgumentException("costMultiplier must be > 0");
            if (subtypePartialNames == null || subtypePartialNames.Count == 0)
                throw new ArgumentException("subtypePartialNames cannot be empty");
            if (category == null)
                throw new ArgumentException("category cannot be null");
            if (category.BaseCost == null)
                throw new ArgumentException("category base cost cannot be null");

            Name = name;
            Category = category;
            CostMultiplier = (MyFixedPoint)costMultiplier;
            EnablePriority = enablePriority;
            SubtypePartialNames = subtypePartialNames;
            BasicCost = Category.BaseCost * CostMultiplier;
            EnabledCost = BasicCost * Category.EnabledMultiplier;
            BigBlockBasicCost = BasicCost * Category.BigBlockMultiplier;
            BigBlockEnabledCost = BasicCost * Category.BigBlockMultiplier;
        }

        #endregion

        /// <summary>
        /// Convert to definition
        /// </summary>
        public BlockTypeDefinition GetDefinition() {
            return new BlockTypeDefinition() {
                Name = Name,
                CostMultiplier = (double)CostMultiplier,
                EnablePriority = EnablePriority,
                SubtypePartialNames = SubtypePartialNames,
            };
        }

        /// <summary>
        /// Determine if the passed block belongs to this group
        /// </summary>
        public bool AppliesToBlock(IMySlimBlock block) {
            Exceptions.ThrowIf<ArgumentNullException>(block == null, "block");

            // IMySlimBlock.ToString() does:
            // FatBlock != null ? FatBlock.ToString() : 
            //   BlockDefinition.DisplayNameText.ToString();
            // which is useful since we're not allowed access to the 
            // BlockDefinition of a SlimBlock
            String blockString = block.ToString();

            //Log.Trace("Does " + blockString + " belong in group [" + 
            // String.Join(", ", SubtypePartialNames) + "] ? ", "AppliesToBlock");

            foreach (String subType in SubtypePartialNames) {
                if (blockString.LooseContains(subType)) {
                    //Log.Trace("It does!", "AppliesToBlock");
                    return true;
                }
            }

            //Log.Trace("It doesn't", "AppliesToBlock");
            return false;
        }

        public String ToString() {
            return String.Format(
                "{0} - CostX: {1}, EnabledPri: {2}, BlockNames: {3}", 
                Name, CostMultiplier, EnablePriority, 
                String.Join(", ", SubtypePartialNames)
            );
        }



    }

}
*/