/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VRage;

using SEGarden.Definitions;
using SEGarden.Logging;
using SEGarden.Testing;

using GC.Definitions.BlockTaxonomy;

namespace GC.Tests.Definitions.BlockTaxonomy {

    public class BlockTypeDefinitionSpec : Specification {

        public BlockTypeDefinitionSpec() {
            Subject = "BlockTypeDefinition";
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
            var a = new BlockTypeDefinition() {
                Name = "Some Block Type",
                CostMultiplier = 47,
                EnablePriority = 5,
                SubtypePartialNames = new List<String> {
                    "a", "b", "c"
                }
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            var a2 = new BlockTypeDefinition(stream);
            x.Assert(a2.Name == "Some Block Type",
                "Name serializes/deserializes correctly.");
            x.Assert(a2.CostMultiplier == 47,
                "CostMultiplier serializes/deserializes correctly.");
            x.Assert(a2.EnablePriority == 5,
                "EnablePriority serializes/deserializes correctly.");
            x.Assert(
                a2.SubtypePartialNames[0] == "a" &&
                a2.SubtypePartialNames[1] == "b" &&
                a2.SubtypePartialNames[2] == "c",
                "SubtypePartialNames serializes/deserializes correctly.");
        }

    }

}
*/