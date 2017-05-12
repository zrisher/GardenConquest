/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using E = SEGarden.Exceptions;
using SEGarden.Logging;

using GC.Definitions.GridTaxonomy;
using GC.World.Grids;

namespace GC.App.GridTaxonomy.ConditionValues {

    public class GridTypeValue : ConditionValueBase {

        static Logger Log = new Logger("GC.World.Grids.Taxonomy.ConditionValues.GridTypeValue");

        public GridTypeValue() {
            StoredType = StoredValueType.GridType;
        }

        public GridTypeValue(GridType gridType) {
            if (gridType == GridType.Unknown)
                throw new ArgumentException("Unknown GridType");

            StoredType = StoredValueType.GridTypeValue;
            GridTypeValue = gridType;
        }

        public GridTypeValue(ConditionValueDefinition definition)
            : base(definition) 
        {
            //Log.Trace("Constructing from " + definition.ToString(), "ctr");
            //Log.Trace("StoredType " + StoredType, "ctr");

            if (StoredType == StoredValueType.GridType) 
                return;

            if (StoredType == StoredValueType.GridTypeValue) {
                if (GridTypeValue == GridType.Unknown) 
                    throw new ArgumentException("Unknown GridType");

                return;
            }

            throw new ArgumentException("Incorrect StoredType");
        }

        public GridType Evaluate(EnforcedGrid grid) {
            switch (StoredType) {
                case StoredValueType.GridTypeValue:
                    if (!GridTypeValue.HasValue)
                        throw new InvalidOperationException("Expected stored value");
                    return GridTypeValue.Value;
                case StoredValueType.GridType:
                    // TODO: get
                    throw new E.NotImplementedException();
                default:
                    throw new InvalidOperationException("Unexpected stored type");
            }
        }

    }

}
*/