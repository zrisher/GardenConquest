/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VRage;

using SEGarden.Definitions;
using SEGarden.Logging;
using SEGarden.Testing;

using GC.Definitions.GridTaxonomy;

namespace GC.Tests.Definitions.GridTaxonomy {

    public class ConditionValueDefinitionSpec : Specification {

        public ConditionValueDefinitionSpec() {
            Subject = "ConditionValueDefinition";
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
            var a = new ConditionValueDefinition() {
                StoredType = StoredValueType.GridType
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            var a2 = new ConditionValueDefinition(stream);
            x.Assert(a2.StoredType == StoredValueType.GridType, 
                "GridType serializes/deserializes correctly.");

            stream = new ByteStream(0, true);
            a = new ConditionValueDefinition() {
                StoredType = StoredValueType.TotalBlocksCount
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            a2 = new ConditionValueDefinition(stream);
            x.Assert(a2.StoredType == StoredValueType.TotalBlocksCount,
                "TotalBlocksCount serializes/deserializes correctly.");

            stream = new ByteStream(0, true);
            a = new ConditionValueDefinition() {
                StoredType = StoredValueType.BlockCategoryCount,
                StringValue = "SomeCategory"
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            a2 = new ConditionValueDefinition(stream);
            x.Assert(
                a2.StoredType == StoredValueType.BlockCategoryCount &&
                a2.StringValue == "SomeCategory",
                "BlockCategoryCount serializes/deserializes correctly.");

            stream = new ByteStream(0, true);
            a = new ConditionValueDefinition() {
                StoredType = StoredValueType.BlockTypeCount,
                StringValue = "SomeBlockType"
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            a2 = new ConditionValueDefinition(stream);
            x.Assert(
                a2.StoredType == StoredValueType.BlockTypeCount &&
                a2.StringValue == "SomeBlockType",
                "BlockCategoryCount serializes/deserializes correctly.");

            stream = new ByteStream(0, true);
            a = new ConditionValueDefinition() {
                StoredType = StoredValueType.GridTypeValue,
                GridTypeValue = GridType.Station
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            a2 = new ConditionValueDefinition(stream);
            x.Assert(
                a2.StoredType == StoredValueType.GridTypeValue &&
                a2.GridTypeValue == GridType.Station,
                "GridTypeValue serializes/deserializes correctly.");

            stream = new ByteStream(0, true);
            a = new ConditionValueDefinition() {
                StoredType = StoredValueType.UintValue,
                UintValue = 47
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            a2 = new ConditionValueDefinition(stream);
            x.Assert(
                a2.StoredType == StoredValueType.UintValue &&
                a2.UintValue == 47,
                "UintValue serializes/deserializes correctly.");
        }

    }

}
*/