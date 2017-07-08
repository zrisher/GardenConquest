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

using GC.Definitions;
using GC.Definitions.BlockTaxonomy;
using GC.Definitions.GridTaxonomy;
using GC.Definitions.LootSpawning;

namespace GC.Tests.Definitions {

    public class SettingsDefinitionSpec : Specification {

        public SettingsDefinitionSpec() {
            Subject = "SettingsDefinition";
            Describe(
                "It should serialize to & from XML", 
                TestXMLSerialization);
            Describe(
                "It should serialize to & from Bytes",
                TestByteSerialization);
        }

        private void TestXMLSerialization(SpecCase x) {
            var settings = Settings.GetDefaultSettings();
            var toStringStart = settings.ToString();
            var def = settings.GetDefinition();
            var serialized = Sandbox.ModAPI.MyAPIGateway.Utilities.
                SerializeToXML<SettingsDefinition>(def);
            var deserialized = Sandbox.ModAPI.MyAPIGateway.Utilities.
                SerializeFromXML<SettingsDefinition>(serialized);
            var reserialized = Sandbox.ModAPI.MyAPIGateway.Utilities.
                SerializeToXML<SettingsDefinition>(deserialized);
            var reloaded = new Settings(deserialized);
            var toStringEnd = reloaded.ToString();
            //Log.Trace("\r\n" + toStringStart, "Test");
            //Log.Trace("\r\n" + toStringEnd, "Test");

            x.Assert(toStringStart == toStringEnd, 
                "toStringStart == toStringEnd");
            x.Assert(serialized == reserialized, 
                "serialized == reserialized");
        }

        private void TestByteSerialization(SpecCase x) {

            var stream = new ByteStream(0, true);
            var a = new SettingsDefinition() {
                EnabledBlockCostMultiplier = 4,
                LargeBlockCostMultiplier = 7,
                GridTaxonomy = new NodeDefinition() {
                    ClassName = "Some class"
                },
                BlockTypeCategories = new List<BlockTypeCategoryDefinition>() {
                    new BlockTypeCategoryDefinition() {
                        Name = "btc 1"
                    },
                    new BlockTypeCategoryDefinition() {
                        Name = "btc 2"
                    }
                },
                ControlPoints = new List<ControlPointDefinition>() {
                    new ControlPointDefinition() {
                        Name = "CP 1"
                    },
                    new ControlPointDefinition() {
                        Name = "CP 2"
                    },
                },
                LootCrateTypes = new List<LootCrateTypeDefinition>() {
                    new LootCrateTypeDefinition() {
                        Name = "Crate 1"
                    },
                    new LootCrateTypeDefinition() {
                        Name = "Crate 2"
                    },
                }
            };
            a.AddToByteSteam(stream);
            stream = new ByteStream(stream.Data, stream.Data.Length);
            var a2 = new SettingsDefinition(stream);
            x.Assert(a2.EnabledBlockCostMultiplier == 4,
                "EnabledBlockCostMultiplier serializes/deserializes correctly.");
            x.Assert(a2.LargeBlockCostMultiplier == 7,
                "LargeBlockCostMultiplier serializes/deserializes correctly.");
            x.Assert(a2.GridTaxonomy.ClassName == "Some class",
                "GridTaxonomy serializes/deserializes correctly.");
            x.Assert(
                a2.BlockTypeCategories[0].Name == "btc 1" &&
                a2.BlockTypeCategories[1].Name == "btc 2",
                "BlockTypeCategories serializes/deserializes correctly.");
            x.Assert(
                a2.ControlPoints[0].Name == "CP 1" &&
                a2.ControlPoints[1].Name == "CP 2",
                "ControlPoints serializes/deserializes correctly.");
            x.Assert(
                a2.LootCrateTypes[0].Name == "Crate 1" &&
                a2.LootCrateTypes[1].Name == "Crate 2",
                "LootCrateTypes serializes/deserializes correctly.");
        }

    }

}
*/