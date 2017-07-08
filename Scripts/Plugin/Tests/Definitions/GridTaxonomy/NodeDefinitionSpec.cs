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

    public class NodeDefinitionSpec : Specification {

        public NodeDefinitionSpec() {
            Subject = "NodeDefinition";
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
            var a = new NodeDefinition() {
                ClassName = "SomeClass"
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            var a2 = new NodeDefinition(stream);
            x.Assert(a2.ClassName == "SomeClass", 
                "Leaf node serializes/deserializes correctly.");

            stream = new ByteStream(0, true);
            a = new NodeDefinition() {
                Condition = new ConditionDefinition() {
                    Operator = OperatorType.Equals,
                    LeftSide = new ConditionValueDefinition() {
                        StoredType = StoredValueType.TotalBlocksCount
                    },
                    RightSide = new ConditionValueDefinition() {
                        StoredType = StoredValueType.UintValue,
                        UintValue = 47
                    }
                },
                LeftBranch = new NodeDefinition() {
                    ClassName = "LeftBranchClass"
                },
                RightBranch = new NodeDefinition() {
                    ClassName = "RightBranchClass"
                },
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            a2 = new NodeDefinition(stream);
            x.Assert(a2.LeftBranch.ClassName == "LeftBranchClass",
                "Left branch serializes/deserializes correctly.");
            x.Assert(a2.RightBranch.ClassName == "RightBranchClass",
                "Right branch serializes/deserializes correctly.");
            x.Assert(a2.Condition.Operator == OperatorType.Equals,
                "Condition serializes/deserializes correctly.");

        }

    }

}
*/