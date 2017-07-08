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

    public class BlockTypeCategoryDefinitionSpec : Specification {

        public BlockTypeCategoryDefinitionSpec() {
            Subject = "BlockTypeCategoryDefinition";
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
            var a = new BlockTypeCategoryDefinition() {
                Name = "Some Category",
                BaseCost = new ItemCountAggregateDefinition() {
                    Counts = new List<ItemCountDefinition>() {
                        new ItemCountDefinition() {
                            TypeName = "some type",
                            SubtypeName = "some subtype",
                            Count = 47
                        }
                    }
                },
                BlockTypes = new List<BlockTypeDefinition>(){
                    new BlockTypeDefinition() {
                        Name = "Some block type"
                    }
                }
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            var a2 = new BlockTypeCategoryDefinition(stream);
            x.Assert(a2.Name == "Some Category", 
                "Name serializes/deserializes correctly.");
            x.Assert(
                a2.BaseCost.Counts[0].TypeName == "some type" &&
                a2.BaseCost.Counts[0].SubtypeName == "some subtype" &&
                a2.BaseCost.Counts[0].Count == 47,
                "BaseCost serializes/deserializes correctly.");
            x.Assert(
                a2.BlockTypes[0].Name == "Some block type",
                "BlockTypes serializes/deserializes correctly.");
        }

    }

}
*/