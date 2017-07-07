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

    [XmlType("Condition")]
    public class ConditionDefinition : DefinitionBase {

        /// <summary>
        /// Left side of the comparison
        /// </summary>
        [XmlElement("LeftSide")]
        public ConditionValueDefinition LeftSide;

        /// <summary>
        /// Comparison operator
        /// </summary>
        [XmlAttribute("Operator")]
        public OperatorType Operator;

        /// <summary>
        /// Right side of the comparison
        /// </summary>
        [XmlElement("RightSide")]
        public ConditionValueDefinition RightSide;

        protected override String ValidationName {
            get { return "Condition"; }
        }

         public ConditionDefinition() { }

         public ConditionDefinition(ByteStream stream) {
             if (stream == null) throw new ArgumentException("null stream");

             Operator = (OperatorType)stream.getUShort();
             LeftSide = new ConditionValueDefinition(stream);
             RightSide = new ConditionValueDefinition(stream);
        }

         public void AddToByteSteam(ByteStream stream) {
             if (stream == null) throw new ArgumentException("null stream");

             stream.addUShort((ushort)Operator);
             LeftSide.AddToByteSteam(stream);
             RightSide.AddToByteSteam(stream);
         }

        public override void Validate(ref List<ValidationError> errors) {
            ErrorIf(Operator == OperatorType.Undefined,
                "Operator cannot be Undefined", ref errors);
            ValidateChild(LeftSide, "LeftSide", ref errors);
            ValidateChild(RightSide, "RightSide", ref errors);
        }

    }

}
*/
