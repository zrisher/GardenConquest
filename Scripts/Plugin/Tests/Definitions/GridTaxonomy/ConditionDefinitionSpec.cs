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

    public class ConditionDefinitionSpec : Specification {

        public ConditionDefinitionSpec() {
            Subject = "ConditionDefinition";
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

            // We already test children
            var stream = new ByteStream(0, true);
            var a = new ConditionDefinition() {
                Operator = OperatorType.Equals,
                LeftSide = new ConditionValueDefinition() {
                    StoredType = StoredValueType.TotalBlocksCount
                },
                RightSide = new ConditionValueDefinition() {
                    StoredType = StoredValueType.UintValue,
                    UintValue = 47
                }
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            var a2 = new ConditionDefinition(stream);
            x.Assert(a2.Operator == OperatorType.Equals, 
                "Operator serializes/deserializes correctly.");
            x.Assert(a2.LeftSide.StoredType == StoredValueType.TotalBlocksCount,
                "LeftSide serializes/deserializes correctly.");
            x.Assert(
                a2.RightSide.StoredType == StoredValueType.UintValue &&
                a2.RightSide.UintValue == 47,
                "RightSide serializes/deserializes correctly.");
        }

    }

}
*/