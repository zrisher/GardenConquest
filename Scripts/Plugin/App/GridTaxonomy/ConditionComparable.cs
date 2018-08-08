/*
using System;

using VRage.Library.Collections;

using SEPC.Logging;
using SEPC.Extensions;

using GC.World.Grids;

namespace GC.App.GridTaxonomy {

	public enum ComparableType : byte
	{
		// Values
		UintValue,          // value stored, points to stored
		GridTypeValue,      // grid type stored, points to stored

		// References to the current grid
		BlockTypeCount,     // name of block type stored, points to this grid's count in that type, compared to UintValue, BlockTypeCount, or BlockCategoryCount
		BlockCategoryCount, // name of category stored, points to this grid's count in that category, compared to UintValue, BlockTypeCount, or BlockCategoryCount
		GridType,           // no value stored, points to this grid's type, compared to GridTypeValue
		TotalBlocksCount,   // no value stored, points to this grid's total block count, compared to UintValue
	}

	/// <summary>
	/// Holds a value or a way of deriving a value from a grid that can then be compared within a condition.
	/// </summary>
	public class ConditionComparable {

		public ComparableType CType;

		// Uses 0 or 1 of these, depending on CType
		public uint UintValue;
		public String StringValue;
		public GridType GridTypeValue;

		public void Serialize(BitStream stream) {
			if (stream.Reading)
				stream.WriteByte((byte)CType);
			else
				CType = (ComparableType)stream.ReadByte();

			// Only serializes the value matching its type
			switch (CType)
			{
				case ComparableType.UintValue:
					stream.Serialize(ref UintValue);
					break;
				case ComparableType.BlockCategoryCount:
				case ComparableType.BlockTypeCount:
					stream.Serialize(ref StringValue);
					break;
				case ComparableType.GridTypeValue:
					if (stream.Reading)
						stream.WriteByte((byte)GridTypeValue);
					else
						GridTypeValue = (GridType)stream.ReadByte();
					break;
				case ComparableType.TotalBlocksCount:
				case ComparableType.GridType:
					break;
				default:
					throw new InvalidOperationException("Unexpected stored type");
			}
        }

        public override String ToString() {
            switch (CType) {
                case ComparableType.UintValue:
                    return UintValue.ToString();
                case ComparableType.BlockCategoryCount:
                    return "BlockCategory " + StringValue;
                case ComparableType.BlockTypeCount:
                    return "BlockType " + StringValue;
                case ComparableType.TotalBlocksCount:
                    return "Total Blocks";
                case ComparableType.GridTypeValue:
                    return $"{GridTypeValue}";
                case ComparableType.GridType:
                    return "Grid Type";
                default:
                    throw new InvalidOperationException("Unexpected stored type");
            }
        }

//		public uint Evaluate(EnforcedGrid grid) {
//			switch (MyType) {
//				case ConditionValueType.UintValue:
//					if (!UintValue.HasValue)
//						throw new InvalidOperationException("Expected stored value");
//					return UintValue.Value;
//				case ConditionValueType.BlockCategoryCount:
//					// TODO: get, use StringValue
//					throw new SEGarden.Exceptions.NotImplementedException();
//				case ConditionValueType.BlockTypeCount:
//					// TODO: get, use StringValue
//					throw new SEGarden.Exceptions.NotImplementedException();
//				case ConditionValueType.TotalBlocksCount:
//					// TODO: get
//					throw new SEGarden.Exceptions.NotImplementedException();
//				default:
//					throw new InvalidOperationException("Unexpected stored type");
//			}
//		}

//		public GridType Evaluate(EnforcedGrid grid) {
//			switch (MyType) {
//				case ConditionValueType.GridTypeValue:
//					if (!GridTypeValue.HasValue)
//						throw new InvalidOperationException("Expected stored value");
//					return GridTypeValue.Value;
//				case ConditionValueType.GridType:
//					// TODO: get
//					throw new E.NotImplementedException();
//				default:
//					throw new InvalidOperationException("Unexpected stored type");
			}
		}
	}

}
*/