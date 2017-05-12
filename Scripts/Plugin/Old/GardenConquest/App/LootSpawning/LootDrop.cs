/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VRage;
using VRageMath;

using SEGarden.World;
using SEGarden.World.Inventory;

using GC.Definitions.LootSpawning;

namespace GC.App.LootSpawning {

    public class LootDrop {

        public readonly double Probability;
        public readonly MyFixedPoint Amount;
        public readonly PhysicalItemType Item;

        public LootDrop(double probability, MyFixedPoint amount, PhysicalItemType item) {
            Probability = probability;
            Amount = amount;
            Item = item;

            // TODO
            //item => item.Public && item.AvailableInSurvival && item.Enabled
        }

        public LootDrop(double probability, ItemCount count) {
            Probability = probability;
            Amount = count.Amount;
            Item = count.Item;
        }

        public LootDrop(LootDropDefinition definition) {
            Probability = definition.Probability;
            Amount = (MyFixedPoint)definition.Count;
            Item = new PhysicalItemType(definition.TypeName, definition.SubtypeName);
        }

        public LootDropDefinition GetDefinition() {
            return new LootDropDefinition() {
                Probability = Probability,
                TypeName = Item.TypeName,
                SubtypeName = Item.SubtypeName,
                Count = (double)Amount
            };
        }

        public String ToString() {
            return String.Format(
                "Probability: {0}, Reward: {1} of {2} ", Probability, Amount, Item
            );
        }

    }

}
*/