/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GC.Definitions.LootSpawning;

namespace GC.App.LootSpawning {

    public class LootCrateCount {

        public LootCrateType CrateType;
        public ushort DesiredCount;

        public LootCrateCount(ushort desiredCount, LootCrateType crateType) {
            CrateType = crateType;
            DesiredCount = desiredCount;
        }

        public LootCrateCount(
            LootCrateCountDefinition definition, List<LootCrateType> types
        ) {
            try {
                CrateType = types.First(x => x.Name == definition.CrateTypeName);
            }
            catch {
                throw new ArgumentException(
                    "Crate type " + definition.CrateTypeName + " not in " +
                    String.Join(", ", types.Select(x => x.Name))
                );
            }

            DesiredCount = definition.DesiredCount;
        }

        public LootCrateCountDefinition GetDefinition() {
            return new LootCrateCountDefinition() {
                CrateTypeName = CrateType.Name,
                DesiredCount = DesiredCount,
            };
        }

        public String ToString() {
            String result = String.Format(
                "{0} of {1}", DesiredCount, CrateType.Name
            );

            return result;
        }


    }

}
*/