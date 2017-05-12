/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using VRage;

using SEGarden.Definitions;
using SEGarden.Extensions;

namespace GC.Definitions.GridTaxonomy {

    [XmlType("Node")]
    public class NodeDefinition : DefinitionBase {

        // If this is a leaf
        [XmlAttribute("ClassName")]
        public string ClassName;

        // If this is a tree
        [XmlElement("Condition")]
        public ConditionDefinition Condition;

        [XmlElement("LeftBranch")]
        public NodeDefinition LeftBranch;

        [XmlElement("RightBranch")]
        public NodeDefinition RightBranch;

        protected override String ValidationName {
            get { return "Node"; }
        }

        public NodeDefinition() { }

        public NodeDefinition(ByteStream stream) {
            if (stream == null) throw new ArgumentException("null stream");

            var typeFlag = stream.getUShort();

            if (typeFlag == 0) {
                ClassName = stream.getString();
            }
            else {
                Condition = new ConditionDefinition(stream);
                LeftBranch = new NodeDefinition(stream);
                RightBranch = new NodeDefinition(stream);
            }
        }

         public void AddToByteSteam(ByteStream stream) {
             if (stream == null) throw new ArgumentException("null stream");

             if (ClassName != null) {
                 stream.addUShort(0);
                 stream.addString(ClassName);
             }
             else {
                 stream.addUShort(1);
                 Condition.AddToByteSteam(stream);
                 LeftBranch.AddToByteSteam(stream);
                 RightBranch.AddToByteSteam(stream);
             }
         }

        public override void Validate(ref List<ValidationError> errors) {
            if (ClassName != null) {
                ErrorIf(String.IsNullOrWhiteSpace(ClassName),
                    "ClassName cannot be empty", ref errors);
                ErrorIf(Condition != null,
                    "Condition must be null when ClassName exists", ref errors);
                ErrorIf(LeftBranch != null,
                    "LeftBranch must be null when ClassName exists", ref errors);
                ErrorIf(RightBranch != null,
                    "RightBranch must be null when ClassName exists", ref errors);
            }
            else {
                ValidateChild(Condition, "Condition", ref errors);
                ValidateChild(LeftBranch, "LeftBranch", ref errors);
                ValidateChild(RightBranch, "RightBranch", ref errors);
            }
        }

        public void ValidateNodeReferences(
            ref IEnumerable<String> categoryNames,
            ref IEnumerable<String> blockTypeNames,
            ref List<ValidationError> errors
        ) {
            if (Condition != null) {
                ValidateValueReferences(
                    Condition.LeftSide,
                    ref categoryNames, ref blockTypeNames, ref errors
                );
                ValidateValueReferences(
                    Condition.RightSide,
                    ref categoryNames, ref blockTypeNames, ref errors
                );
                LeftBranch.ValidateNodeReferences(
                    ref categoryNames, ref blockTypeNames, ref errors
                );
                RightBranch.ValidateNodeReferences(
                    ref categoryNames, ref blockTypeNames, ref errors
                );
            }

        }

        public void ValidateValueReferences(
            ConditionValueDefinition value,
            ref IEnumerable<String> categoryNames,
            ref IEnumerable<String> blockTypeNames,
            ref List<ValidationError> errors
        ) {
            switch (value.StoredType) {
                case StoredValueType.BlockCategoryCount:
                    ErrorIf(!categoryNames.LooseContains(value.StringValue),
                        value.StringValue + " not in defined categories " + String.Join(", ", categoryNames),
                        ref errors);
                    break;
                case StoredValueType.BlockTypeCount:
                    ErrorIf(!blockTypeNames.LooseContains(value.StringValue),
                        value.StringValue + " not in defined block types " + String.Join(", ", blockTypeNames),
                        ref errors);
                    break;
            }
        }

    }

}
*/
