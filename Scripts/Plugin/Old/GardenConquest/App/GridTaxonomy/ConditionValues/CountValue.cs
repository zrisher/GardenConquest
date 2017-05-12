/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using E = SEGarden.Exceptions;

using GC.Definitions.GridTaxonomy;
using GC.World.Grids;

namespace GC.App.GridTaxonomy.ConditionValues {

    public class CountValue : ConditionValueBase {

        public CountValue() {
            StoredType = StoredValueType.TotalBlocksCount;
        }

        public CountValue(uint value) {
            StoredType = StoredValueType.UintValue;
            UintValue = value;
        }

        public CountValue(StoredValueType type, String groupName) {
            if (type != StoredValueType.BlockCategoryCount && 
                type != StoredValueType.BlockTypeCount)
                throw new ArgumentException("Wrong ctr for this type.");

            if (String.IsNullOrWhiteSpace(groupName))
                throw new ArgumentException("Empty groupName");

            StoredType = type;
            StringValue = groupName;
        }

        public CountValue(ConditionValueDefinition definition)
            : base(definition) 
        {
            if (StoredType == StoredValueType.TotalBlocksCount || 
                StoredType == StoredValueType.UintValue) 
                return;

            if (StoredType == StoredValueType.BlockTypeCount ||
                StoredType == StoredValueType.BlockCategoryCount) {
                if (String.IsNullOrWhiteSpace(StringValue))
                    throw new ArgumentException("Empty groupName");

                return;
            }

            throw new ArgumentException("Incorrect StoredType");
        }

        public uint Evaluate(EnforcedGrid grid) {
            switch (StoredType) {
                case StoredValueType.UintValue:
                    if (!UintValue.HasValue)
                        throw new InvalidOperationException("Expected stored value");
                    return UintValue.Value;
                case StoredValueType.BlockCategoryCount:
                    // TODO: get, use StringValue
                    throw new E.NotImplementedException();
                case StoredValueType.BlockTypeCount:
                    // TODO: get, use StringValue
                    throw new E.NotImplementedException();
                case StoredValueType.TotalBlocksCount:
                    // TODO: get
                    throw new E.NotImplementedException();
                default:
                    throw new InvalidOperationException("Unexpected stored type");
            }
        }

    }

}
*/