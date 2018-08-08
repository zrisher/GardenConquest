/*
using System;

using Sandbox.Definitions;
using VRage.Game;

namespace GC.World.Types
{
	public class PhysicalItemType : DefinedObjectType
	{
		public PhysicalItemType(String typeName, String subtypeName) : base(typeName, subtypeName)
		{
			if (!(Definition is MyPhysicalItemDefinition))
				throw new InvalidOperationException("Passed type/subtype is not a PhysicalItem.");
		}

		public PhysicalItemType(MyDefinitionId definitionId) : base(definitionId)
		{
			if (!(Definition is MyPhysicalItemDefinition))
				throw new InvalidOperationException("Passed type/subtype is not a PhysicalItem.");
		}

	}
}
*/