/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VRage;

using SEGarden.World;
using SEGarden.World.Inventory;

using GC.Definitions.BlockTaxonomy;

namespace GC.App.BlockTaxonomy {

    public class BlockTypeCategory {

        public readonly String Name;
        public readonly List<BlockType> BlockTypes;
        public readonly ItemCountsAggregate BaseCost;
        public readonly double EnabledMultiplier;
        public readonly double BigBlockMultiplier;

        #region Constructors

        //public BlockTypeCategory(
        //    String name, ItemCountsAggregate baseCost,
        //    double enabledMultiplier, double bigBlockMultiplier,
        //    List<BlockType> blockTypes = null
        //) {
        //    if (BlockTypes == null) blockTypes = new List<BlockType>();
        //    this.ConstructorHelper(
        //        ref Name, name, 
        //        ref BaseCost, baseCost,
        //        ref EnabledMultiplier, enabledMultiplier,
        //        ref BigBlockMultiplier, bigBlockMultiplier,
        //        ref BlockTypes, blockTypes
        //    );
        //}

        public BlockTypeCategory(
            String name, ItemCount baseCostItemCount,
            double enabledMultiplier, double bigBlockMultiplier
        ) {
            ItemCountsAggregate baseCost = new ItemCountsAggregate(baseCostItemCount);

            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be empty");
            if (baseCost == null || baseCost.IsEmpty())
                throw new ArgumentException("baseCost cannot be empty");
            if (enabledMultiplier < 1)
                throw new ArgumentException("enabledMultiplier cannot be < 1");
            if (bigBlockMultiplier < 1)
                throw new ArgumentException("bigBlockMultiplier cannot be < 1");

            Name = name;
            BlockTypes = new List<BlockType>();
            BaseCost = baseCost;
            EnabledMultiplier = enabledMultiplier;
            BigBlockMultiplier = bigBlockMultiplier;
        }

        public BlockTypeCategory(
            BlockTypeCategoryDefinition definition,
            double enabledMultiplier, double bigBlockMultiplier
        ) {
            String name = definition.Name;
            ItemCountsAggregate baseCost = new ItemCountsAggregate(definition.BaseCost);

            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be empty");
            if (definition.BlockTypes == null)
                throw new ArgumentException("blockTypes cannot be null");
            if (baseCost == null || baseCost.IsEmpty())
                throw new ArgumentException("baseCost cannot be empty");
            if (enabledMultiplier < 1)
                throw new ArgumentException("enabledMultiplier cannot be < 1");
            if (bigBlockMultiplier < 1)
                throw new ArgumentException("bigBlockMultiplier cannot be < 1");

            Name = name;
            BaseCost = baseCost;
            EnabledMultiplier = enabledMultiplier;
            BigBlockMultiplier = bigBlockMultiplier;
            BlockTypes = definition.BlockTypes.
                Select(x => new BlockType(x, this)).ToList();
        }

        #endregion

        public BlockTypeCategoryDefinition GetDefinition() {
            return new BlockTypeCategoryDefinition() {
                Name = Name,
                BlockTypes = BlockTypes.Select(x => x.GetDefinition()).ToList(),
                BaseCost = BaseCost.GetDefinition(),
            };
        }

        public String ToString() {
            String result = String.Format(
                "{0} - Cost: {1}, EnabledX: {2}, BigGridX: {3}", Name, BaseCost.ToString(), EnabledMultiplier, BigBlockMultiplier
            );

            foreach (var blockType in BlockTypes) {
                result += "\r\n  " + blockType.ToString();
            }

            return result;
        }

    }

}
*/
