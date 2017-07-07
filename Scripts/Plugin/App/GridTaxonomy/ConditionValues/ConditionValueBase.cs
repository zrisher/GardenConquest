/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using E = SEGarden.Exceptions;
using SEGarden.Logging;

using GC.Definitions.GridTaxonomy;

namespace GC.App.GridTaxonomy.ConditionValues {

    public abstract class ConditionValueBase {

        static Logger Log = new Logger("GC.World.Grids.Taxonomy.ConditionValues.ConditionValueBase");

        protected StoredValueType StoredType;

        // Only uses one of these, depending on StoredType
        protected uint? UintValue = null;
        protected String StringValue;
        protected GridType? GridTypeValue = null;

        public ConditionValueBase() { }

        public ConditionValueBase(ConditionValueDefinition definition) {
            //Log.Trace("Constructing from " + definition.ToString(), "ctr");
            StoredType = definition.StoredType;
            UintValue = definition.UintValue;
            StringValue = definition.StringValue;
            GridTypeValue = definition.GridTypeValue;
        }

        public ConditionValueDefinition GetDefinition() {
            var result = new ConditionValueDefinition() {
                StoredType = StoredType
            };

            switch (StoredType) {
                case StoredValueType.UintValue:
                    result.UintValue = UintValue;
                    break;
                case StoredValueType.BlockCategoryCount:
                case StoredValueType.BlockTypeCount:
                    result.StringValue = StringValue;
                    break;
                case StoredValueType.GridTypeValue:
                    result.GridTypeValue = GridTypeValue;
                    break;
                case StoredValueType.TotalBlocksCount:
                case StoredValueType.GridType:
                    break;
                default:
                    throw new InvalidOperationException("Unexpected stored type");
            }

            return new ConditionValueDefinition() {
                StoredType = StoredType,
                UintValue = UintValue,
                StringValue = StringValue,
                GridTypeValue = GridTypeValue
            };
        }

        public String ToString() {
            switch (StoredType) {
                case StoredValueType.UintValue:
                    return UintValue.ToString();
                case StoredValueType.BlockCategoryCount:
                    return "BlockCategory " + StringValue;
                case StoredValueType.BlockTypeCount:
                    return "BlockType " + StringValue;
                case StoredValueType.TotalBlocksCount:
                    return "Total Blocks";
                case StoredValueType.GridTypeValue:
                    return String.Format("{0}",GridTypeValue);
                case StoredValueType.GridType:
                    return "Grid Type";
                default:
                    throw new InvalidOperationException("Unexpected stored type");
            }
        }

    }

}
*/