/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sandbox.Definitions;

using VRage;
using VRage.Game;

using SEGarden;
using SEGarden.Definitions;
using SEGarden.Logging;
using SEGarden.World;
using SEGarden.World.Inventory;

using GC.Definitions;
using GC.App.BlockTaxonomy;
using GC.App.GridTaxonomy;
using GC.App.LootSpawning;

namespace GC {


    public partial class Settings {

        const String Filename = "conquest_settings.xml";

        static readonly Logger Log = new Logger("GC.Settings");

        public static bool TryLoadOrCreate(out Settings settings) {
            try {
                settings = LoadOrCreate();
                return true;
            }
            catch (Exception e) {
                Log.Error("Exception getting settings: " + e, "TryLoadOrCreate");
                settings = null;
                return false;
            }          
        }

        public static Settings LoadOrCreate() {
            if (GardenGateway.Files.Exists(Filename)) {
                return Load();
            }
            else {
                Log.Info("No existing settings file, using defaults", 
                    "LoadOrCreate");
                return GetDefaultSettings();
            }
        }

        public static Settings Load(String filename = Filename) {
            Log.Trace("Loading saved Settings", "Load");

            var loaded = GardenGateway.Files.
                ReadXML<SettingsDefinition>(filename);

            Log.Trace("1", "Load");

            var validationErrors = new List<ValidationError>();
            loaded.Validate(ref validationErrors);

            Log.Trace("2", "Load");

            if (validationErrors.Count > 0) {
                foreach (var error in validationErrors) {
                    Log.Error(
                        "Validation error in " + error.Source +
                        " : " + error.Message, "Load"
                    );
                }
                throw new Exception("Validation of loaded settings failed.");
            }

            Log.Trace("3", "Load");

            return new Settings(loaded);
        }

        public double LargeBlockCostMultiplier;
        public double EnabledBlockCostMultiplier;
        public List<LootCrateType> LootCrateTypes =
            new List<LootCrateType>();
        public List<BlockTypeCategory> BlockTypeCategories = 
            new List<BlockTypeCategory>();
        public List<ControlPoint> ControlPoints =
            new List<ControlPoint>();
        public Node GridTaxonomy = new Node("Unclassified");

        /// <summary>
        /// Create new settings object
        /// </summary>
        public Settings() {

        }

        /// <summary>
        /// Create new settings object from a saved definition
        /// </summary>
        public Settings(SettingsDefinition definition) {
            if (definition == null)
                throw new ArgumentException("definition cannot be null");
            if (definition.LargeBlockCostMultiplier < 1)
                throw new ArgumentException("LargeBlockCostMultiplier must be >= 1");
            if (definition.EnabledBlockCostMultiplier < 1)
                throw new ArgumentException("EnabledBlockCostMultiplier must be >= 1");

            EnabledBlockCostMultiplier = definition.EnabledBlockCostMultiplier;
            LargeBlockCostMultiplier = definition.LargeBlockCostMultiplier;
            GridTaxonomy = new Node(definition.GridTaxonomy);
            LootCrateTypes = definition.LootCrateTypes.
                Select(x => new LootCrateType(x)).ToList();
            ControlPoints = definition.ControlPoints.
                Select(x => new ControlPoint(x, LootCrateTypes)).ToList();
            BlockTypeCategories = definition.BlockTypeCategories.
                Select(x => new BlockTypeCategory(
                    x, EnabledBlockCostMultiplier, LargeBlockCostMultiplier
                )).ToList();
        }

        public SettingsDefinition GetDefinition() {
            return new SettingsDefinition() {
                EnabledBlockCostMultiplier = EnabledBlockCostMultiplier,
                LargeBlockCostMultiplier = LargeBlockCostMultiplier,
                GridTaxonomy = GridTaxonomy.GetDefinition(),
                ControlPoints = ControlPoints.
                    Select(x => x.GetDefinition()).ToList(),
                BlockTypeCategories = BlockTypeCategories.
                    Select(x => x.GetDefinition()).ToList(),
                LootCrateTypes = LootCrateTypes.
                    Select(x => x.GetDefinition()).ToList(),
            };
        }

        public override String ToString() {
            String result = "LargeBlockCostX: " + LargeBlockCostMultiplier + "\r\n" +
                "EnabledBlockCostX: " + EnabledBlockCostMultiplier + "\r\n";

            result += "CPs: \r\n";
            foreach (var cp in ControlPoints) {
                result += cp.ToString() + "\r\n";
            }
            result += "BlockTypeCategories: \r\n";
            foreach (var category in BlockTypeCategories) {
                result += category.ToString() + "\r\n";
            }
            result += "GridTaxonomy: \r\n" + GridTaxonomy.ToString();

            return result;
        }

        public void Save(String filename = Filename) {
            // TODO: try?
            Log.Info("Saving Settings", "Save");
            GardenGateway.Files.WriteXML<SettingsDefinition>(
                filename, GetDefinition()
            );
            Log.Trace("Finished saving settings", "Save");
        }

        //public static BlockType GetFirstMatching(IMySlimBlock block) {
        //    VRage.Exceptions.ThrowIf<ArgumentException>(block == null, "block");
        //
        //    foreach (var type in KnownTypes)
        //        if (type.AppliesToBlock(block))
        //            return type;
        //
        //    return Unknown;
        //}
    }

}
*/