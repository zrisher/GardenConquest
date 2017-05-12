/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using VRage;

using SEGarden.Definitions;
using SEGarden.Extensions;

using GC.Definitions.BlockTaxonomy;
using GC.Definitions.GridTaxonomy;
using GC.Definitions.LootSpawning;

namespace GC.Definitions {

    [XmlType("GardenConquestSettings")]
    public class SettingsDefinition : DefinitionBase {

        /// <summary>
        /// Multiply base cost for blocks by this when on a Large Grid
        /// </summary>
        [XmlElement("LargeBlockCostMultiplier")]
        public double LargeBlockCostMultiplier;

        /// <summary>
        /// Multiply base cost for blocks by this when block is enabled
        /// </summary>
        [XmlElement("EnabledBlockCostMultiplier")]
        public double EnabledBlockCostMultiplier;

        /// <summary>
        /// The places where we distribute loot crates
        /// </summary>
        [XmlArray("ControlPoints")]
        public List<ControlPointDefinition> ControlPoints = 
            new List<ControlPointDefinition>();

        /// <summary>
        /// Types of LootCrates
        /// </summary>
        [XmlArray("LootCrateTypes")]
        public List<LootCrateTypeDefinition> LootCrateTypes =
            new List<LootCrateTypeDefinition>();

        /// <summary>
        /// Block types and their costs
        /// </summary>
        [XmlArray("BlockTypeCategories")]
        public List<BlockTypeCategoryDefinition> BlockTypeCategories = 
            new List<BlockTypeCategoryDefinition>();

        /// <summary>
        /// Classes of grid
        /// </summary>
        [XmlElement("GridTaxonomy")]
        public GridTaxonomy.NodeDefinition GridTaxonomy;

        protected override String ValidationName {
            get { return "Settings"; }
        }

        public SettingsDefinition() { }

        public SettingsDefinition(ByteStream stream) {
            if (stream == null) throw new ArgumentException("null stream");

            LargeBlockCostMultiplier = stream.getDouble();
            EnabledBlockCostMultiplier = stream.getDouble();

            ushort len = stream.getUShort();
            for (ushort i = 0; i < len; ++i) {
                LootCrateTypes.Add(new LootCrateTypeDefinition(stream));
            }    

            len = stream.getUShort();
            for (ushort i = 0; i < len; ++i) {
                ControlPoints.Add(new ControlPointDefinition(stream));
            }         

            len = stream.getUShort();
            for (ushort i = 0; i < len; ++i) {
                BlockTypeCategories.Add(new BlockTypeCategoryDefinition(stream));
            }

            GridTaxonomy = new GridTaxonomy.NodeDefinition(stream);
        }

        public void AddToByteSteam(ByteStream stream) {
            if (stream == null) throw new ArgumentException("null stream");

            stream.addDouble(LargeBlockCostMultiplier);
            stream.addDouble(EnabledBlockCostMultiplier);

            stream.addUShort((ushort)LootCrateTypes.Count);
            foreach (var crateType in LootCrateTypes) {
                crateType.AddToByteSteam(stream);
            }

            stream.addUShort((ushort)ControlPoints.Count);
            foreach (var cp in ControlPoints) {
                cp.AddToByteSteam(stream);
            }

            stream.addUShort((ushort)BlockTypeCategories.Count);
            foreach (var category in BlockTypeCategories) {
                category.AddToByteSteam(stream);
            }

            GridTaxonomy.AddToByteSteam(stream);
        }

        public override void Validate(ref List<ValidationError> errors) {
            ErrorIf(LargeBlockCostMultiplier < 1,
                "LargeBlockCostMultiplier must be > 1.", ref errors);
            ErrorIf(EnabledBlockCostMultiplier < 1,
                "EnabledBlockCostMultiplier must be > 1.", ref errors);
            ValidateChildren(ControlPoints, "ControlPoints", ref errors);
            ValidateChildren(BlockTypeCategories, "BlockTypeCategories", ref errors);
            ValidateChild(GridTaxonomy, "GridTaxonomy", ref errors);

            var categoryNames = BlockTypeCategories.Select(x => x.Name);
            var blockTypeNames = BlockTypeCategories.Select(
                x => x.BlockTypes.Select(y => y.Name)
            ).SelectMany(x => x);
            GridTaxonomy.ValidateNodeReferences(
               ref categoryNames, ref blockTypeNames, ref errors
            );

            var lootCrateNames = LootCrateTypes.Select(x => x.Name);
            foreach (var cp in ControlPoints)
                cp.ValidateCrateReferences(ref lootCrateNames, ref errors);
        }

    }

}
*/
