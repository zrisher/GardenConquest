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

    [XmlType("BlockType")]
    public class BlockTypeDefinition : DefinitionBase {

        /// <summary>
        /// Name used for display and identification
        /// </summary>
        [XmlAttribute("Name")]
        public String Name = "";

        /// <summary>
        /// Multiply the Category's cost by this to find cost for this type
        /// </summary>
        [XmlAttribute("CostMultiplier")]
        public double CostMultiplier;

        /// <summary>
        /// Blocks requisition available licenses to stay enabled in this order
        /// </summary>
        [XmlElement("EnablePriority")]
        public int EnablePriority;

        /// <summary>
        /// Partials to match against block subtypes to see if they belong
        /// </summary>
        [XmlArray("SubtypePartialNames")]
        [XmlArrayItem("PartialName")]
        public List<String> SubtypePartialNames = new List<String>();

        protected override String ValidationName { 
            get { return "BlockType"; } 
        }

        public BlockTypeDefinition() { }

        public BlockTypeDefinition(ByteStream stream) {
            if (stream == null) throw new ArgumentException("null stream");

            Name = stream.getString();
            CostMultiplier = stream.getDouble();
            EnablePriority = (int)stream.getLong();
            SubtypePartialNames = stream.getStringList();
        }

         public void AddToByteSteam(ByteStream stream) {
             if (stream == null) throw new ArgumentException("null stream");

             stream.addString(Name);
             stream.addDouble(CostMultiplier);
             stream.addLong((long)EnablePriority);
             stream.addStringList(SubtypePartialNames);
         }

        public override void Validate(ref List<ValidationError> errors) {
            ErrorIf(String.IsNullOrWhiteSpace(Name), 
                "Name cannot be empty.", ref errors);
            ErrorIf(CostMultiplier < 0, 
                "CostMultiplier cannot be less than zero.", ref errors);
            ErrorIf(SubtypePartialNames == null || SubtypePartialNames.Count == 0, 
                "SubtypePartialNames cannot be empty.", ref errors);
        }

    }

}
*/
