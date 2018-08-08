/*
using System;
using System.Collections.Generic;
using System.Linq;

using VRage;

using GC.World.Inventory;
using GC.World.Types;

namespace GC.App.BlockTaxonomy {

    public class BlockTypeCategory {

        public readonly String Name;
        public readonly List<BlockType> BlockTypes;
        public readonly ItemCountCollection BaseCost;
        public readonly double EnabledMultiplier;
        public readonly double BigBlockMultiplier;

        public BlockTypeCategory(String name, ItemCount baseCostItemCount, double enabledMultiplier, double bigBlockMultiplier)
		{
			ItemCountCollection baseCost = new ItemCountCollection(baseCostItemCount);

			Exceptions.ThrowIf<ArgumentException>(String.IsNullOrWhiteSpace(name), "name cannot be empty");
			Exceptions.ThrowIf<ArgumentException>(baseCost == null || baseCost.IsEmpty(), "baseCost cannot be empty");
			Exceptions.ThrowIf<ArgumentException>(enabledMultiplier < 1, "enabledMultiplier cannot be < 1");
			Exceptions.ThrowIf<ArgumentException>(bigBlockMultiplier < 1, "bigBlockMultiplier cannot be < 1");

            Name = name;
            BlockTypes = new List<BlockType>();
            BaseCost = baseCost;
            EnabledMultiplier = enabledMultiplier;
            BigBlockMultiplier = bigBlockMultiplier;
        }

//		// TODO - Serialization
//		public BlockTypeCategory(
//            BlockTypeCategoryDefinition definition,
//            double enabledMultiplier, double bigBlockMultiplier
//        ) {
//            String name = definition.Name;
// 			ItemCountCollection baseCost = new ItemCountCollection(definition.BaseCost);
//
//            if (String.IsNullOrWhiteSpace(name))
//                throw new ArgumentException("name cannot be empty");
//            if (definition.BlockTypes == null)
//                throw new ArgumentException("blockTypes cannot be null");
//            if (baseCost == null || baseCost.IsEmpty())
//                throw new ArgumentException("baseCost cannot be empty");
//            if (enabledMultiplier < 1)
//                throw new ArgumentException("enabledMultiplier cannot be < 1");
//            if (bigBlockMultiplier < 1)
//                throw new ArgumentException("bigBlockMultiplier cannot be < 1");
//
//            Name = name;
//            BaseCost = baseCost;
//            EnabledMultiplier = enabledMultiplier;
//            BigBlockMultiplier = bigBlockMultiplier;
//            BlockTypes = definition.BlockTypes.
//                Select(x => new BlockType(x, this)).ToList();
//        }

//        public BlockTypeCategoryDefinition GetDefinition() {
//            return new BlockTypeCategoryDefinition() {
//                Name = Name,
//                BlockTypes = BlockTypes.Select(x => x.GetDefinition()).ToList(),
//                BaseCost = BaseCost.GetDefinition(),
//            };
//        }

		public override String ToString() {
			String result = $"{Name} - Cost: {BaseCost}, EnabledX: {EnabledMultiplier}, BigGridX: {BigBlockMultiplier}"; 

            foreach (var blockType in BlockTypes)
                result += "\r\n  " + blockType.ToString();

            return result;
        }

    }

}
*/