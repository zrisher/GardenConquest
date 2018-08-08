/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VRage;
using VRage.Library.Collections;

using SEPC.Logging;

using GC.World.Grids;

namespace GC.App.GridTaxonomy {

	public enum ConditionOperator
	{
		Undefined,
		LessThan,
		LessThanOrEqualTo,
		Equals,
		GreaterThan,
		GreaterThanOrEqualTo,
	}

	public class Condition {

		enum ConditionType
		{
			Unknown,
			Count,
			GridType,
		}

		static readonly Logable Log = new Logable("GC.App.GridTaxonomy");

		static ConditionType ConditionTypeOf(ComparableType comparableType)
		{
			switch (comparableType)
			{
				case ComparableType.UintValue:
				case ComparableType.BlockCategoryCount:
				case ComparableType.BlockTypeCount:
					return ConditionType.Count;
				case ComparableType.GridTypeValue:
				case ComparableType.GridType:
					return ConditionType.GridType;
				default:
					throw new InvalidOperationException("Unknown type");
			}
		}

		static ConditionType ConditionTypeOf(ConditionComparable comparable)
		{
			return ConditionTypeOf(comparable.CType);
		}

		static bool ApplyOperator(ConditionOperator op, uint value1, uint value2)
		{
			switch (op)
			{
				case ConditionOperator.LessThan:
					return value1 < value2;
				case ConditionOperator.LessThanOrEqualTo:
					return value1 <= value2;
				case ConditionOperator.Equals:
					return value1 == value2;
				case ConditionOperator.GreaterThan:
					return value1 > value2;
				case ConditionOperator.GreaterThanOrEqualTo:
					return value1 >= value2;
				default:
					throw new FieldAccessException("Undefined Operator");
			}
		}

		static String OperatorToString(ConditionOperator operatorType)
		{
			switch (operatorType)
			{
				case ConditionOperator.Equals:
					return "=";
				case ConditionOperator.GreaterThan:
					return ">";
				case ConditionOperator.GreaterThanOrEqualTo:
					return ">=";
				case ConditionOperator.LessThan:
					return "<";
				case ConditionOperator.LessThanOrEqualTo:
					return "<=";
				default:
					throw new Exception("Undefined ConditionOperator");
			}
		}

		ConditionComparable Left;
		ConditionOperator Operator;
		ConditionComparable Right;
		ConditionType CType;

//        Condition(ConditionComparable left, ConditionOperator op, ConditionComparable right) 
//        {
//			Exceptions.ThrowIf<ArgumentException>(Operator == ConditionOperator.Undefined, "Undefined operator");
//			Exceptions.ThrowIf<ArgumentException>(ConditionTypeOf(left) != ConditionTypeOf(right), "Different types");
//
//			CType = ConditionTypeOf(left);
//			Left = left;
//            Operator = op;
//            Right = right;
//		}

//		public bool Evaluate(EnforcedGrid grid)
//		{
//			switch (ValuesType)
//			{
//				case ConditionType.GridType:
//					GridType leftT = ((GridTypeValue)LeftSide).Evaluate(grid);
//					GridType rightT = ((GridTypeValue)RightSide).Evaluate(grid);
//					return leftT == rightT;
//				case ConditionType.Count:
//					uint leftU = ((CountValue)LeftSide).Evaluate(grid);
//					uint rightU = ((CountValue)RightSide).Evaluate(grid);
//					return Compare(leftU, rightU);
//				default:
//					throw new E.FieldAccessException("Undefined ValuesType");
//			}
//		}

		public void Serialize(BitStream stream)
		{
			if (stream.Reading)
			{
				stream.WriteByte((byte)CType);
				stream.WriteByte((byte)Operator);
			}
			else
			{
				CType = (ConditionType)stream.ReadByte();
				Operator = (ConditionOperator)stream.ReadByte();
			}

			Left.Serialize(stream);
			Right.Serialize(stream);
		}

		public override String ToString()
		{
			return $"{Left} {Operator} {Right}";
		}
    }

}
*/