/*
using System;

using Sandbox.Definitions;
using VRage.Game;
using VRage.ObjectBuilders;

using SEPC.Logging;

namespace GC.World.Types
{
	/// <summary>
	/// Helps deal in object types defined by TypeName and SubTypeName strings.
	/// Useful when allowing users to input types for configuration.
	/// </summary>
    public class DefinedObjectType
    {
		protected static readonly Logable Log = new Logable("GC.World.Types");

        protected readonly MyDefinitionBase Definition;

        public String TypeName
        {
            get { return DefinitionId.TypeId.ToString(); }
        }

        public String SubtypeName
        {
            get { return DefinitionId.SubtypeName; }
        }

        public MyObjectBuilderType BuilderType
        {
            get { return DefinitionId.TypeId; }
        }

        public MyDefinitionId DefinitionId
        {
            get { return Definition.Id; }
        }

        public DefinedObjectType(String typeName, String subtypeName)
        {
            MyObjectBuilderType builderType;
            try
            {
                builderType = MyObjectBuilderType.Parse(typeName);
            }
            catch (Exception e)
            {
                throw new TypeLoadException($"Failed to find builder type \"{typeName}\"");
            }

            MyDefinitionId id;
            try
            {
                id = new MyDefinitionId(builderType, subtypeName);
            }
            catch (Exception e)
            {
				throw new TypeLoadException($"Failed to find definitionId for \"{builderType}/{subtypeName}\"");
			}

            try
            {
                Definition = MyDefinitionManager.Static.GetDefinition(id);
            }
            catch (Exception e)
            {
//				Log.Trace("Logging existing cb defs", "ctr");
//				var entities = Sandbox.Game.Entities.MyEntities.GetEntities(); //.Select(x => x as Sandbox.Game.Entities.Cube.MySlimBlock).Where(x => x != null).ToList();
//
//				foreach (var entity in entities) {
//					if (entity is Sandbox.Game.Entities.MyCubeGrid) {
//						var grid = entity as Sandbox.Game.Entities.MyCubeGrid;
//						foreach (VRage.Game.ModAPI.IMySlimBlock block in grid.CubeBlocks) {
//							if (block.FatBlock != null)
//								Log.Trace(String.Format("{0}", block.FatBlock.BlockDefinition), "ctr");
//						}
//					}
//				}

				throw new TypeLoadException($"Failed to find Definition for \"{id}\"");
            }
        }

        public DefinedObjectType(MyDefinitionId definitionId)
        {
            Definition = MyDefinitionManager.Static.GetDefinition(definitionId);
        }

    }

}
*/