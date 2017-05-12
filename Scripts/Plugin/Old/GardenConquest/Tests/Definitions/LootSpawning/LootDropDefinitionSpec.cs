/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VRage;

using SEGarden.Definitions;
using SEGarden.Logging;
using SEGarden.Testing;

using GC.Definitions.LootSpawning;

namespace GC.Tests.Definitions.LootSpawning {

    public class LootDropDefinitionSpec : Specification {

        public LootDropDefinitionSpec() {
            Subject = "LootDropDefinition";
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
            var a = new LootDropDefinition() {
                Probability = .47,
                TypeName = "type",
                SubtypeName = "subtype",
                Count = 47,
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            var a2 = new LootDropDefinition(stream);
            x.Assert(a2.Probability == .47,
                "Probability serializes/deserializes correctly.");
            x.Assert(a2.TypeName == "type",
                "TypeName serializes/deserializes correctly.");
            x.Assert(a2.SubtypeName == "subtype",
                "SubtypeName serializes/deserializes correctly.");
            x.Assert(a2.Count == 47,
                "Count serializes/deserializes correctly.");
        }

    }

}
*/