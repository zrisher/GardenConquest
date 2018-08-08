/*
using System;

using Sandbox.Definitions;
using VRage.Game;

namespace GC.World.Types
{
    public class CubeBlockType : DefinedObjectType
    {
        public CubeBlockType(String typeName, String subtypeName) : base(typeName, subtypeName)
        {
            if (!(Definition is MyCubeBlockDefinition))
                throw new InvalidOperationException("Passed type/subtype is not a CubeBlock.");
        }

        public CubeBlockType(MyDefinitionId definitionId) : base(definitionId)
        {
            if (!(Definition is MyCubeBlockDefinition))
                throw new InvalidOperationException("Passed type/subtype is not a CubeBlock.");
        }
    }

}
*/