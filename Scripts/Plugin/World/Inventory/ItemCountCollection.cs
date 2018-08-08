/*
using System;
using System.Collections.Generic;
using System.Linq;

using VRage;
using VRage.Game;

using SEPC.Logging;

using GC.World.Types;

namespace GC.World.Inventory
{
    /// <summary>
    /// Represents a collection of item counts as a vector
    /// </summary>
    public class ItemCountCollection
    {

        public static readonly ItemCountCollection Zero = new ItemCountCollection();

        static Logable Log = new Logable("GC.World.Inventory");

        #region Static Operators

        public static ItemCountCollection operator +(ItemCountCollection value1, ItemCountCollection value2)
        {
            Exceptions.ThrowIf<ArgumentNullException>(value1 == null, "value1");
            Exceptions.ThrowIf<ArgumentNullException>(value2 == null, "value2");

            ItemCountCollection result = value1.Copy();

            foreach (var kvp in value2.Counts)
                result.Counts[kvp.Key] = result.Get(kvp.Key) + kvp.Value;

            return result;
        }

        public static ItemCountCollection operator -(ItemCountCollection value1, ItemCountCollection value2)
        {
            Exceptions.ThrowIf<ArgumentNullException>(value1 == null, "value1");
            Exceptions.ThrowIf<ArgumentNullException>(value2 == null, "value2");

            ItemCountCollection result = value1.Copy();

            foreach (var kvp in value2.Counts)
                result.Counts[kvp.Key] = result.Get(kvp.Key) - kvp.Value;

            return result;
        }

        public static ItemCountCollection operator *(ItemCountCollection value1, MyFixedPoint value2)
        {
            Exceptions.ThrowIf<ArgumentNullException>(value1 == null, "value1");

            ItemCountCollection result = value1.Copy();

            foreach (var key in value1.Counts.Keys)
                result.Counts[key] *= value2;

            return result;
        }

        public static ItemCountCollection operator *(ItemCountCollection value1, float value2)
        {
            return value1 * (MyFixedPoint)value2;
        }

        public static ItemCountCollection operator *(ItemCountCollection value1, double value2)
        {
            return value1 * (MyFixedPoint)value2;
        }

        public static ItemCountCollection operator /(ItemCountCollection value1, float value2)
        {
            return value1 * (1 / value2);
        }

//        public static bool operator <(InventoryItemsCount value1, InventoryItemsCount value2) {
//            return value2.Contains(value1);
//        }
//
//        public static bool operator <=(InventoryItemsCount value1, InventoryItemsCount value2) {
//            return value1 < value2;
//        }

        #endregion

        readonly Dictionary<MyDefinitionId, MyFixedPoint> Counts = new Dictionary<MyDefinitionId, MyFixedPoint>();

		#region Ctrs

		public ItemCountCollection() { }

        public ItemCountCollection(Dictionary<MyDefinitionId, MyFixedPoint> counts)
        {
            Counts = counts;
        }

        public ItemCountCollection(ItemCount count)
        {
            Set(count.Item.DefinitionId, count.Amount);
        }

        public ItemCountCollection(List<ItemCount> counts)
        {
            foreach (var count in counts)
                Set(count.Item.DefinitionId, count.Amount);
        }

		#endregion
		#region Accessors

		public MyFixedPoint Get(MyDefinitionId definitionId)
        {
            return Counts.ContainsKey(definitionId) ? Counts[definitionId] : MyFixedPoint.Zero;
        }

        public void Set(MyDefinitionId defId, MyFixedPoint count)
        {
            Counts[defId] = count;
        }

        public bool IsEmpty()
        {
            return Counts.Values.All((x) => (x <= MyFixedPoint.Zero));
        }

        public bool Contains(ItemCountCollection other)
        {
            return other.Counts.All((kvp) => (kvp.Value <= Get(kvp.Key)));
        }

//        public Dictionary<MyDefinitionId, MyFixedPoint> GetCounts() {
//            VRage.Exceptions.ThrowIf<FieldAccessException>(this.Counts == null, "this.Counts");
//
//            return new Dictionary<MyDefinitionId, MyFixedPoint>(Counts);
//        }

		#endregion
		#region Conversions

		public ItemCountCollection Copy()
		{
			//Log.Trace($"Copying {this}");
			ItemCountCollection result = new ItemCountCollection();

			foreach (var kvp in this.Counts)
				result.Set(kvp.Key, kvp.Value);

			//Log.Trace("Returning result");
			return result;
		}

		public List<ItemCount> ToList()
		{
			var result = new List<ItemCount>();
			foreach (var kvp in Counts)
				result.Add(new ItemCount(kvp.Value, new PhysicalItemType(kvp.Key)));
			return result;
		}

		public override String ToString()
        {
            List<String> results = new List<String>();

            foreach (var kvp in Counts)
            {
                if (kvp.Value == 0) continue;
                results.Add(kvp.Key.SubtypeName.ToString() + ": " + kvp.Value.ToString());
            }

            return $"[ {String.Join(", ", results)} ]";
        }

//		// TODO - Serialization 
//		public ItemCountCollection(ItemCountAggregateDefinition definition)
//		{
//			foreach (var countDef in definition.Counts)
//			{
//				var a = new PhysicalItemType(countDef.TypeName, countDef.SubtypeName);
//				this.Set(a.DefinitionId, (MyFixedPoint)countDef.Count);
//			}
//		}
//
//		public ItemCountAggregateDefinition GetDefinition()
//		{
//			var result = new ItemCountAggregateDefinition();
//
//			foreach (var kvp in Counts)
//			{
//				if (kvp.Value <= 0) continue;
//				var item = new PhysicalItemType(kvp.Key);
//				var countDef = new ItemCountDefinition()
//				{
//					TypeName = item.TypeName,
//					SubtypeName = item.SubtypeName,
//					Count = (double)kvp.Value,
//				};
//				result.Counts.Add(countDef);
//			}
//
//			return result;
//		}

		#endregion
	}
}
*/