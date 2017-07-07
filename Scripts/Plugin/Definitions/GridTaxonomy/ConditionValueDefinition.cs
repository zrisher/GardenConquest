/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using VRage;

using SEGarden.Definitions;
using SEGarden.Extensions;
using SEGarden.Logging;

namespace GC.Definitions.GridTaxonomy {

    [XmlType("ConditionValue")]
    public class ConditionValueDefinition : DefinitionBase {

        //static Logger Log = new Logger("GC.Definitions.GridTaxonomy.ConditionValueDefinition");

        /// <summary>
        /// Which type of value does this holds
        /// </summary>
        [XmlAttribute("StoredType")]
        public StoredValueType StoredType;

        /// <summary>
        /// A number to compare against a count
        /// </summary>
        [XmlElement("UintValue")]
        public uint? UintValue = null;

        /// <summary>
        /// The name of a block type or category
        /// </summary>
        [XmlElement("StringValue")]
        public String StringValue;

        /// <summary>
        /// Some type of grid, compared against a Grid's actual type
        /// </summary>
        [XmlElement("GridTypeValue")]
        public GridType? GridTypeValue = null;

        // We should only store one value (if any)
        public bool ShouldSerializeUintValue() { return UintValue.HasValue; }
        public bool ShouldSerializeStringValue() { return StringValue != null; }
        public bool ShouldSerializeGridTypeValue() { return GridTypeValue.HasValue; }

        protected override String ValidationName {
            get { return "ConditionValue"; }
        }

        public ConditionValueDefinition() { }

        public ConditionValueDefinition(ByteStream stream) {
            if (stream == null) throw new ArgumentException("null stream");

            //var typeUshort = stream.getUShort();
            //var deserialized = (StoredValueType)typeUshort;
            //StoredType = deserialized;
            StoredType = (StoredValueType)stream.getUShort();

            //Log.Trace(String.Format("Received StoredType {0} as ushort {1}", deserialized, typeUshort), "ctr");

            switch (StoredType) {
                case StoredValueType.UintValue:
                    UintValue = (uint)stream.getUlong();
                    break;
                case StoredValueType.BlockCategoryCount:
                case StoredValueType.BlockTypeCount:
                    StringValue = stream.getString();
                    break;
                case StoredValueType.GridTypeValue:
                    GridTypeValue = (GridType)stream.getUShort();
                    break;
                case StoredValueType.TotalBlocksCount:
                case StoredValueType.GridType:
                    break;
                default:
                    throw new InvalidOperationException("Unexpected stored type");
            }
        }

        public void AddToByteSteam(ByteStream stream) {
            if (stream == null) throw new ArgumentException("null stream");

            stream.addUShort((ushort)StoredType);
            //Log.Trace(String.Format("Adding StoredType {0} as ushort {1}",StoredType, (ushort)StoredType), "AddToByteSteam");

            switch (StoredType) {
                case StoredValueType.UintValue:
                    if (UintValue == null)
                        throw new InvalidOperationException("Expected stored value");
                    stream.addUlong((ulong)UintValue);
                    break;
                case StoredValueType.BlockCategoryCount:
                case StoredValueType.BlockTypeCount:
                    if (StringValue == null)
                        throw new InvalidOperationException("Expected stored value");
                    stream.addString(StringValue);
                    break;
                case StoredValueType.GridTypeValue:
                    if (GridTypeValue == null)
                        throw new InvalidOperationException("Expected stored value");
                    stream.addUShort((ushort)GridTypeValue);
                    break;
                case StoredValueType.TotalBlocksCount:
                case StoredValueType.GridType:
                    break;
                default:
                    throw new InvalidOperationException("Unexpected stored type");
            }
        }

        public override void Validate(ref List<ValidationError> errors) {
            switch (StoredType) {
                case StoredValueType.UintValue:
                    ErrorIf(UintValue == null,
                        "UintValue cannot be null when uint Type", ref errors);
                    ErrorIf(StringValue != null,
                        "StringValue must be null when uint Type", ref errors);
                    ErrorIf(GridTypeValue != null,
                        "GridTypeValue must be null when uint Type", ref errors);
                    break;
                case StoredValueType.GridTypeValue:
                    ErrorIf(GridTypeValue == null,
                        "GridTypeValue cannot be null when GridType Type", ref errors);
                    ErrorIf(StringValue != null,
                        "StringValue must be null when GridType Type", ref errors);
                    ErrorIf(UintValue != null,
                        "UintValue must be null when GridType Type", ref errors);
                    break;
                case StoredValueType.BlockTypeCount:
                case StoredValueType.BlockCategoryCount:
                    ErrorIf(StringValue == null,
                        "StringValue cannot be null when StringValue Type", ref errors);
                    ErrorIf(GridTypeValue != null,
                        "GridTypeValue must be null when GridType Type", ref errors);
                    ErrorIf(UintValue != null,
                        "UintValue must be null when GridType Type", ref errors);
                    break;
                case StoredValueType.GridType:
                case StoredValueType.TotalBlocksCount:
                    ErrorIf(StringValue != null,
                        "StringValue must be null when reference Type", ref errors);
                    ErrorIf(GridTypeValue != null,
                        "GridTypeValue must be null when reference Type", ref errors);
                    ErrorIf(UintValue != null,
                        "UintValue must be null when reference Type", ref errors);
                    break;
            }
        }

        public override String ToString() {
            return String.Format("{0} {1} {2} {3}", 
                StoredType, UintValue, StringValue, GridTypeValue
            );
        }
    }

}
*/
