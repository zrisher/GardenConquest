/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SEGarden.Definitions;
using SEGarden.Logging;
using SEGarden.Testing;

using GC.Definitions;


namespace GC.Tests {

    public class SettingsSpec : Specification {

        const String TestSaveFilename = "TestSettings.xml";

        public SettingsSpec() {
            Subject = "Settings";
            Describe(
                "Defaults should be nonempty",
                TestDefaultsNonempty);
            Describe(
                "Defaults should validate without error",
                TestDefaultsValidates);
            Describe(
                "Defaults should save and load without error",
                TestSavesAndLoads);
        }

        private void TestDefaultsNonempty(SpecCase x) {
            var settings = Settings.GetDefaultSettings();

            x.Assert(settings.BlockTypeCategories.Count > 0,
                "settings.BlockTypeCategories.Count > 0");
            x.Assert(settings.ControlPoints.Count > 0,
                "settings.ControlPoints.Count > 0");
            x.Assert(settings.GridTaxonomy != null,
                "settings.GridTaxonomy != null");
            x.Assert(settings.LootCrateTypes.Count > 0,
                "settings.GridTaxonomy != null");
        }

        
        private void TestDefaultsValidates(SpecCase x) {
            var settings = Settings.GetDefaultSettings();
            var toStringStart = settings.ToString();
            var def = settings.GetDefinition();
            var validationErrors = new List<ValidationError>();

            x.Assert(def.ValidateAndLog(), "def.ValidateAndLog == true");
        }

        private void TestSavesAndLoads(SpecCase x) {
            // TODO - requires thread waiting

            //var settings = Settings.GetDefaultSettings();
            //settings.Save(TestSaveFilename);
            //var loaded = Settings.Load(TestSaveFilename);
        }

    }

}
*/
