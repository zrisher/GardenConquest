/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sandbox.ModAPI;
using VRageMath;

using SEGarden.Definitions;
using SEGarden.Logging;
using SEGarden.Testing;

using GC.App.LootSpawning;
using GC.Definitions;


namespace GC.Tests.App.LootSpawning {

    public class ControlPointSpec : Specification {

        public ControlPointSpec() {
            Subject = "ControlPoint";
            Describe("Should spawn a loot crate", TestSpawn);
        }

        private void TestSpawn(SpecCase x) {
            var spawnPos = MyAPIGateway.Entities.FindFreePlace(Vector3D.Zero, 5);
            if (spawnPos == null) {
                x.Assert(false, "Should find an empty testing position");
            }
            else {
                var spawned = ControlPoint.SpawnCrate(spawnPos.Value);
                spawned.SyncObject.SendCloseRequest();
            }
        }

    

    }

}
*/