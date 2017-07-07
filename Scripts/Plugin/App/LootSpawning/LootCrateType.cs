/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GC.Definitions.LootSpawning;

namespace GC.App.LootSpawning {

    public class LootCrateType {

        public readonly String Name = "";
        public readonly List<LootDrop> LootDrops = new List<LootDrop>();

        public LootCrateType(String name, List<LootDrop> lootDrops) {
            Name = name;
            LootDrops = lootDrops;
        }

        public LootCrateType(LootCrateTypeDefinition definition) {
            if (String.IsNullOrWhiteSpace(definition.Name))
                throw new ArgumentException("LootCrateName cannot be blank.");

            Name = definition.Name;

            if (definition.LootDrops != null)
                LootDrops = definition.LootDrops.
                    Select(x => new LootDrop(x)).ToList();
        }

        public LootCrateTypeDefinition GetDefinition() {
            return new LootCrateTypeDefinition() {
                Name = Name,
                LootDrops = LootDrops.Select(x => x.GetDefinition()).ToList(),
            };
        }

        public override String ToString() {
            String result = String.Format(
                "{0}:", Name
            );

            foreach (var drop in LootDrops) {
                result += "\r\n  " + drop.ToString();
            }

            return result;
        }

    }

}
*/