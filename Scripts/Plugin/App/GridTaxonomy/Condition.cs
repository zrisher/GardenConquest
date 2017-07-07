/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using E = SEGarden.Exceptions;
using SEGarden.Logging;

using GC.App.GridTaxonomy.ConditionValues;
using GC.Definitions.GridTaxonomy;
using GC.World.Grids;

namespace GC.App.GridTaxonomy {


    enum ValueType {
        Unknown,
        GridType,
        Uint,
    }

    public class Condition {

        static Logger Log = new Logger("GC.World.Grids.Taxonomy");

        #region Static construction helpers

        public static Condition BlockTypeComparison(
            String type1, OperatorType op, String type2) 
        {
            return new Condition(
                new CountValue(StoredValueType.BlockTypeCount, type1),
                op,
                new CountValue(StoredValueType.BlockTypeCount, type2)
            );
        }

        public static Condition BlockTypeComparison(
            String type1, OperatorType op, uint type2) {
            return new Condition(
                new CountValue(StoredValueType.BlockTypeCount, type1),
                op,
                new CountValue(type2)
            );
        }

        public static Condition BlockTypeLtoE(String type1, String type2) {
            return BlockTypeComparison(
                type1, OperatorType.LessThanOrEqualTo, type2);
        }

        public static Condition BlockTypeGtoE(String type1, String type2) {
            return BlockTypeComparison(
                type1, OperatorType.GreaterThanOrEqualTo, type2);
        }

        public static Condition BlockTypeGreater(String type1, uint value) {
            return BlockTypeComparison(type1, OperatorType.GreaterThan, value);
        }


        public static Condition BlockTypeEquals(String type1, uint value) {
            return BlockTypeComparison(type1, OperatorType.Equals, value);
        }

        public static Condition BlockCategoryComparison(
            String type1, OperatorType op, String type2) 
        {
            return new Condition(
                new CountValue(StoredValueType.BlockCategoryCount, type1),
                op,
                new CountValue(StoredValueType.BlockCategoryCount, type2)
            );
        }

        public static Condition BlockCategoryLtoE(
            String type1, String type2) 
        {
                return BlockCategoryComparison(
                    type1, OperatorType.LessThanOrEqualTo, type2);
        }


        public static Condition GridTypeComparison(GridType type) {
            return new Condition(
                new GridTypeValue(),
                OperatorType.Equals,
                new GridTypeValue(type)
            );
        }

        public static Condition TotalBlocksComparison(
            OperatorType op, uint value) 
        {
            return new Condition(
                new CountValue(),
                op,
                new CountValue(value)
            );
        }

        public static Condition TotalBlocksLtoE(uint value) {       
            return TotalBlocksComparison(OperatorType.LessThanOrEqualTo, value);
        }

        #endregion

        ConditionValueBase LeftSide;
        OperatorType Operator;
        ConditionValueBase RightSide;
        ValueType ValuesType;

        public Condition(
            ConditionValueBase leftSide, OperatorType op, 
            ConditionValueBase rightSide) 
        {
            LeftSide = leftSide;
            Operator = op;
            RightSide = rightSide;

            if (Operator == OperatorType.Undefined)
                throw new ArgumentException("Undefined operator");

            if (LeftSide is GridTypeValue) {
                if (RightSide is GridTypeValue)
                    ValuesType = ValueType.GridType;
                else
                    throw new ArgumentException(
                        "Expecting rightside to be a GridTypeValue");
            }
            else if (LeftSide is CountValue) {
                if (RightSide is CountValue)
                    ValuesType = ValueType.Uint;
                else
                    throw new ArgumentException(
                        "Expecting rightside to be a CountValue");
            }
            else {
                throw new ArgumentException("Null LeftSide");
            }
        }

        public Condition(ConditionDefinition definition) {
            if (definition.Operator == null)
                throw new ArgumentException("Null Operator");
            if (definition.LeftSide == null)
                throw new ArgumentException("Null LeftSide");
            if (definition.RightSide == null)
                throw new ArgumentException("Null RightSide");

            Operator = definition.Operator;

            //Log.Trace("Constructing from defs:", "ctr");
            //Log.Trace(definition.LeftSide.ToString(), "ctr");
            //Log.Trace(String.Format("{0}", definition.Operator), "ctr");
            //Log.Trace(definition.RightSide.ToString(), "ctr");

            if (definition.LeftSide.StoredType == StoredValueType.GridType ||
                definition.LeftSide.StoredType == StoredValueType.GridTypeValue)
            {
                LeftSide = new GridTypeValue(definition.LeftSide);
                RightSide = new GridTypeValue(definition.RightSide);
                ValuesType = ValueType.GridType;
            }
            else {
                LeftSide = new CountValue(definition.LeftSide);
                RightSide = new CountValue(definition.RightSide);
                ValuesType = ValueType.Uint;
            }
        }

        public ConditionDefinition GetDefinition() {
            return new ConditionDefinition() {
                LeftSide = LeftSide.GetDefinition(),
                RightSide = RightSide.GetDefinition(),
                Operator = Operator
            };
        }

        public String ToString() {
            String opString;

            switch (Operator) {
                case OperatorType.Equals:
                    opString = "=";
                    break;
                case OperatorType.GreaterThan:
                    opString = ">";
                    break;
                case OperatorType.GreaterThanOrEqualTo:
                    opString = ">=";
                    break;
                case OperatorType.LessThan:
                    opString = "<";
                    break;
                case OperatorType.LessThanOrEqualTo:
                    opString = "<=";
                    break;
                default:
                    throw new E.FieldAccessException("Undefined ValuesType");
            }

            return String.Format("{0} {1} {2}",
                LeftSide.ToString(), opString, RightSide.ToString()
            );
        }

        public bool Evaluate(EnforcedGrid grid) {
            switch (ValuesType) {
                case ValueType.GridType:
                    GridType leftT = ((GridTypeValue)LeftSide).Evaluate(grid);
                    GridType rightT = ((GridTypeValue)RightSide).Evaluate(grid);
                    return leftT == rightT;
                case ValueType.Uint:
                    uint leftU = ((CountValue)LeftSide).Evaluate(grid);
                    uint rightU = ((CountValue)RightSide).Evaluate(grid);
                    return Compare(leftU, rightU);  
                default:
                    throw new E.FieldAccessException("Undefined ValuesType");
            }
        }

        /// <remarks>
        /// Surely there's a built-in way to do this?
        /// </remarks>
        bool Compare(uint value1, uint value2) {
            switch (Operator) {
                case OperatorType.LessThan:
                    return value1 < value2;
                case OperatorType.LessThanOrEqualTo:
                    return value1 <= value2;
                case OperatorType.Equals:
                    return value1 == value2;
                case OperatorType.GreaterThan:
                    return value1 > value2;
                case OperatorType.GreaterThanOrEqualTo:
                    return value1 >= value2;
                default:
                    throw new E.FieldAccessException("Undefined Operator");
            }       
        }

    }

}
*/