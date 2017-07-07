/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using VRage;

using SEGarden.Definitions;
using SEGarden.Extensions;

namespace GC.Definitions.BlockTaxonomy {

    [XmlType("BlockTypeCategory")]
    public class BlockTypeCategoryDefinition : DefinitionBase {

        /// <summary>
        /// Display Name and Id
        /// </summary>
        [XmlElement("Name")]
        public String Name = "";

        /// <summary>
        /// The items required per cycle
        /// </summary>
        /// <remarks>
        /// Multiplied by blockType and Enabled factors to determine block cost
        /// </remarks>
        [XmlElement("BaseCost")]
        public ItemCountAggregateDefinition BaseCost =
            new ItemCountAggregateDefinition();

        /// <summary>
        /// The BlockTypes that belong to this Category
        /// </summary>
        [XmlArray("BlockTypes")]
        public List<BlockTypeDefinition> BlockTypes = 
            new List<BlockTypeDefinition>();

        protected override String ValidationName { 
            get { return "BlockTypeCategory"; } 
        }

        public BlockTypeCategoryDefinition() { }

        public BlockTypeCategoryDefinition(ByteStream stream) {
            if (stream == null) throw new ArgumentException("null stream");

            Name = stream.getString();
            BaseCost = new ItemCountAggregateDefinition(stream);
            ushort len = stream.getUShort();
            for (ushort i = 0; i < len; ++i) {
                BlockTypes.Add(new BlockTypeDefinition(stream));
            }
        }

         public void AddToByteSteam(ByteStream stream) {
            if (stream == null) throw new ArgumentException("null stream");

            stream.addString(Name);
            BaseCost.AddToByteSteam(stream);
            stream.addUShort((ushort)BlockTypes.Count);
            foreach (var blockType in BlockTypes) {
                blockType.AddToByteSteam(stream);
            }
         }

        public override void Validate(ref List<ValidationError> errors) {
            ErrorIf(String.IsNullOrWhiteSpace(Name), 
                "Name cannot be empty", ref errors);
            ValidateChild(BaseCost, "BaseCost", ref errors);
            ValidateChildren(BlockTypes, "BlockTypes", ref errors);
        }
    }

}
*/
