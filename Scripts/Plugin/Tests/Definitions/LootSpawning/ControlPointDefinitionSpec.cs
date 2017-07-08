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

    public class ControlPointDefinitionSpec : Specification {

        public ControlPointDefinitionSpec() {
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
            var a = new ControlPointDefinition() {
                Name = "Some CP",
                Position = new Vector3D(1,2,3),
                Radius = 47,
                DesiredCrates = new List<LootCrateCountDefinition>() {
                    new LootCrateCountDefinition(){
                        CrateTypeName = "Some crate",
                        DesiredCount = 4
                    },
                    new LootCrateCountDefinition(){
                        CrateTypeName = "other crate",
                        DesiredCount = 7
                    },
                },
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            var a2 = new ControlPointDefinition(stream);
            x.Assert(a2.Name == "Some CP",
                "Name serializes/deserializes correctly.");
            x.Assert(a2.Position == new Vector3D(1,2,3),
                "Position serializes/deserializes correctly.");
            x.Assert(a2.Radius == 47,
                "Radius serializes/deserializes correctly.");
            x.Assert(
                a2.DesiredCrates[0].CrateTypeName == "Some crate" &&
                a2.DesiredCrates[0].DesiredCount == 4 &&
                a2.DesiredCrates[1].CrateTypeName == "other crate" &&
                a2.DesiredCrates[1].DesiredCount == 7,
                "LootDrops serializes/deserializes correctly.");
        }

    }

}
*/