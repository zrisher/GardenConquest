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

    public class LootCrateCountDefinitionSpec : Specification {

        public LootCrateCountDefinitionSpec() {
            Subject = "ControlPointDefinition";
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
            var a = new LootCrateCountDefinition() {
                CrateTypeName = "Some crate name",
                DesiredCount = 47
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            var a2 = new LootCrateCountDefinition(stream);
            x.Assert(a2.CrateTypeName == "Some crate name",
                "LootCrateName serializes/deserializes correctly.");
            x.Assert(a2.DesiredCount == 47,
                "DesiredCount serializes/deserializes correctly.");
        }

    }

}
*/