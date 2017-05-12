/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VRage;
using VRageMath;

using SEGarden.Definitions;
using SEGarden.Logging;
using SEGarden.Testing;

using GC.Definitions.LootSpawning;

namespace GC.Tests.Definitions.LootSpawning {

    public class LootCrateDefinitionSpec : Specification {

        public LootCrateDefinitionSpec() {
            Subject = "LootCrateDefinition";
            Describe(
                "It should serialize to & from XML", 
                TestXMLSerialization);
            Describe(
                "It should serialize to & from Bytes",
                TestByteSerialization);
        }

        private void TestXMLSerialization(SpecCase x) {
            // TODO, but seems to be working fine
        }

        private void TestByteSerialization(SpecCase x) {

            var stream = new ByteStream(0, true);
            var a = new LootCrateTypeDefinition() {
                Name = "Some Crate",
                LootDrops = new List<LootDropDefinition>(){
                    new LootDropDefinition(){
                        Probability = 1
                    },
                    new LootDropDefinition(){
                        Probability = .47
                    },
                }
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            var a2 = new LootCrateTypeDefinition(stream);
            x.Assert(a2.Name == "Some Crate",
                "Name serializes/deserializes correctly.");
            x.Assert(
                a2.LootDrops[0].Probability == 1 &&
                a2.LootDrops[1].Probability == .47,
                "LootDrops serializes/deserializes correctly.");
        }

    }

}
*/