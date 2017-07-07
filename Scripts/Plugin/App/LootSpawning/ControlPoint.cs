/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Sandbox;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Blocks;
using Sandbox.Game.Entities.Cube;
using Sandbox.Game.GameSystems;
using Sandbox.Game.World;
using Sandbox.Definitions;
using Sandbox.ModAPI;
//using Interfaces = Sandbox.ModAPI.Interfaces;
//using InGame = Sandbox.ModAPI.Ingame;

using VRage;
using VRage.ObjectBuilders;
using VRage.ModAPI;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.Game.ObjectBuilders;
using VRage.Utils;
using VRageMath;

using SEGarden.Exceptions;
using SEGarden.Extensions;
using SEGarden.Logging;
using SEGarden.World;
using SEGarden.World.Inventory;

using GC.Definitions.LootSpawning;
using GC.World.Blocks;
using GC.World.Grids;

namespace GC.App.LootSpawning {

    public class ControlPoint {

        static Logger Log = new Logger("GC.World.ControlPoint");

        public readonly String Name;
        public readonly Vector3D Position;
        public readonly uint Radius;
        public readonly List<LootCrateCount> DesiredCrates = new List<LootCrateCount>();
        public readonly MyPlanet Planet;
        //public readonly List<LootCrate> Crates;

        readonly Dictionary<LootCrateType, List<LootCrate>> VirginCrates = 
            new Dictionary<LootCrateType, List<LootCrate>>();

        BoundingSphereD Bounds;

        public ControlPoint(
            String name, Vector3D position, uint radius, 
            List<LootCrateCount> desiredCrates
        ) {
            if (radius == 0)
                throw new ArgumentException("radius must be > 0");

            Name = name;
            Position = position;
            Radius = radius;
            if (desiredCrates != null) DesiredCrates = desiredCrates;

            // Note that this could cause errors if planets are added/removed
            // during the game. However, until MyPlanets or MyGravityProviderSystem
            // are whitelisted, this makes sense. I don't want to iterate
            // through all voxels every time we spawn a loot crate.
            var planet = MyPlanetExtensions.GetClosestPlanet(Position);
            if (planet.IsPositionInGravityWell(Position))
                Planet = planet;
        }

        public ControlPoint(
            ControlPointDefinition definition, List<LootCrateType> crateTypes
        ) {
            if (definition.Radius == 0)
                throw new ArgumentException("radius must be > 0");
            if (definition.DesiredCrates == null || definition.DesiredCrates.Count == 0)
                throw new ArgumentException("LootCrateCounts cannot be empty");

            Name = definition.Name;
            Position = definition.Position;
            Radius = definition.Radius;
            DesiredCrates = definition.DesiredCrates.
                Select(x => new LootCrateCount(x, crateTypes)).ToList();
        }

        public ControlPointDefinition GetDefinition() {
            return new ControlPointDefinition() {
                Name = Name,
                Position = Position,
                Radius = Radius,
                DesiredCrates = DesiredCrates.
                    Select(x => x.GetDefinition()).ToList()
            };
        }

        public override String ToString() {
            String result = String.Format(
                "{0} @ {1} Radius {2}", Name, Position, Radius
            );

            foreach (var crate in DesiredCrates) {
                result += "\r\n  " + crate.ToString();
            }

            return result;
        }

        public void Initialize() {
            Bounds = new BoundingSphereD(Position, (double)Radius);           
        }

        public void UpdateSpawns() {
            Log.Trace("Updating Spawns for " + Name, "UpdateSpawns");
        }

        public MyCubeGrid SpawnCrate() {
            Log.Trace("SpawnCrate BEGIN", "SpawnCrate");

            // MyGravityProviderSystem isn't whitelisted
            //var nearbyPlanet = MyGravityProviderSystem.GetStrongestGravityWell(cp.Position);

            // MyPlanets isn't whitelisted either  
            //MyPlanet nearbyPlanet = null;
            //foreach (var planet in Sandbox.Game.Entities.Planet.MyPlanets.GetPlanets()) {
            //    // note this will fail in the case where only part of the CP lies within the grav field
            //    if (planet.IsPositionInGravityWell(cp.Position)) {
            //        nearbyPlanet = planet;
            //        break;
            //    }
            //}           

            for (int i = 1; i <= 10; i++) {

                var spawnPos = Position +
                    MyUtils.GetRandomVector3D() * 
                    Radius * MyUtils.GetRandomDouble(0, 1);

                Log.Trace("Trying spawn pos " + spawnPos, "SpawnCrate");

                if (Planet != null) {
                    spawnPos = Planet.GetClosestSurfacePointGlobal(ref spawnPos);
                    Log.Trace("In planet, correcting to surface point " + spawnPos.ToString(), "SpawnCrateForCP");
                }

                var spawned = SpawnCrate(spawnPos);

                if (spawned != null) {
                    Log.Trace("Found a location!", "SpawnCrateForCP");
                    return spawned;
                }
            }

            return null;
        }

        public static MyCubeGrid SpawnCrate(Vector3D position, bool large = false) {
            //Log.Trace("SpawnCrate BEGIN", "SpawnCrate");
            String blockSubType = large ? "LargeBlockLargeContainer" : "LargeBlockSmallContainer";

            var cargoDef = new CubeBlockType("MyObjectBuilder_CargoContainer", blockSubType).
                Definition as MyCubeBlockDefinition;

            //Log.Trace("Looking for open space", "SpawnCrate");
            var testLocation = MyAPIGateway.Entities.FindFreePlace(position, 1.5f);
            if (testLocation == null) {
                Log.Debug("Failed to find open space", "SpawnCrate");
                return null;
            }
            //Log.Trace("Found open space " + testLocation.ToString(), "SpawnCrate");

            var matrix = new MatrixD(); // MatrixD.CreateWorld(position, direction, upVector);
            matrix.Translation = testLocation.Value;
            matrix.Up = Vector3D.Up;
            matrix.Forward = Vector3D.Forward;

            var created = MyCubeBuilder.SpawnDynamicGrid(cargoDef, null, matrix);

            //Log.Debug("Successfully created new entities", "SpawnCrate");
            //Log.Debug(String.Format("save: {0}, server_position: {1}, positioncomp_pos: {2} ", created.Save, created.m_serverPosition, created.PositionComp.WorldMatrix.Translation), "SpawnCrate");
            //Log.Debug(String.Format("HasInventory: {0}, InScene: {1}, BlocksCount: {2}, DisplayName: {3} ", created.HasInventory, created.InScene, created.BlocksCount, created.DisplayName), "SpawnCrate");
            //Log.Debug("Successfully created new entities", "SpawnCrate");
            created.Save = false; // don't save these
            return created;
        }

        private void RandomNotes() {
            /*
            var planet = MyGravityProviderSystem.GetStrongestGravityWell(position);

            //Log.Trace("Creating block builder", "SpawnCrate");
            //var block = (MyObjectBuilder_CubeBlock)MyObjectBuilderSerializer.
            //    CreateNewObject(cargoDef.Id);

            //var block = MyCubeGrid.createblock
            //    cargo_ll.Definition, Vector3I.Zero,
            //     MyBlockOrientation.Identity, MyEntityIdentifier.AllocateId(),
            //    0, true
            //);

            block.EntityId = MyEntityIdentifier.AllocateId();

            Log.Trace("Created block builder", "SpawnCrate");
            Log.Trace("Creating grid builder", "SpawnCrate");
            //var gridBuilder = MyObjectBuilderSerializer.CreateNewObject<MyObjectBuilder_CubeGrid>();
            var gridObjectBuilder = new MyObjectBuilder_CubeGrid() {
                PersistentFlags = MyPersistentEntityFlags2.CastShadows | MyPersistentEntityFlags2.InScene,
                GridSizeEnum = MyCubeSize.Large,
                IsStatic = false,
                CreatePhysics = true,
                LinearVelocity = new SerializableVector3(0, 0, 0),
                AngularVelocity = new SerializableVector3(0, 0, 0),
                PositionAndOrientation = new MyPositionAndOrientation(testLocation.Value, Vector3.UnitX, Vector3.UnitY),
                DisplayName = "Test Grid 1",
                EntityId = MyEntityIdentifier.AllocateId()
            };
            Log.Trace("Created grid builder", "SpawnCrate");

            gridObjectBuilder.CubeBlocks.Add(block);
            Log.Debug("Added block to grid builder", "SpawnCrate");

            //MyObjectBuilder_Reactor cube = new MyObjectBuilder_Reactor() {
            //    Min = new SerializableVector3I(0, 0, 0),
            //    SubtypeName = "Phoenix_Stargate_EventHorizon_Vortex",
            //    ColorMaskHSV = new SerializableVector3(0, -1, 0),
            //    EntityId = 0,
            //    Owner = 0,
            //    BlockOrientation = new SerializableBlockOrientation(VRageMath.Base6Directions.Direction.Forward, VRageMath.Base6Directions.Direction.Up),
            //    ShareMode = MyOwnershipShareModeEnum.All,
            //    CustomName = "Event Horizon Vortex",
            //};
            //
            //Log.Debug("Successfully created new block builder", "Initialize()");
			//
            //gridObjectBuilder.CubeBlocks.Add(cube);
            //
            //MyObjectBuilder_InventoryItem item = new MyObjectBuilder_InventoryItem() { Amount = 100, Content = new MyObjectBuilder_Ore() { SubtypeName = "Stone" } };
			//
            //Log.Debug("Rock builder position&orientation: " + rockBuilder.PositionAndOrientation.ToString(), "Initialize()")
			//
            //IMyEntity myRock = MyAPIGateway.Entities.CreateFromObjectBuilderAndAdd(rockBuilder);
            //Log.Debug("created rock at " + myRock.GetPosition(), "Initialize()");
            //IMyEntity testGrid = MyAPIGateway.Entities.CreateFromObjectBuilderAndAdd(gridObjectBuilder);
        }
    }
}
*/