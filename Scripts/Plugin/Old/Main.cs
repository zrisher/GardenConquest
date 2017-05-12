/*
#define DEBUG // remove on build

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sandbox.ModAPI;

using VRage;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRage.ObjectBuilders;

using SEGarden.Logic;
using SEGarden.Logging;

using GC.Sessions;
using GC.World.Grids;

namespace GC {
    
    /// <summary>
    /// The main session.
    /// Initializes, updates, and terminates all sub sessions.
    /// 
    /// This is started by SE as a Session Logic Component,
    /// but GardenSession ensures its not initialized until SEGarden is.
    /// </summary>
    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class Main : MySessionComponentBase {

        public static ServerSession Server;
        public static ClientSession Client;

        private static readonly Logger Log = new Logger("GC.Main");

        private bool Constructed;
        private bool PrintedLConstructionException;
        private Exception ConstructionException;
      
        /// <summary>
        /// Initializes if needed, issues updates.
        /// </summary>
        public override void UpdateAfterSimulation() {
            if (!Constructed && 
                !PrintedLConstructionException &&
                ConstructionException != null) 
            {
                if (SEGarden.GardenGateway.Files != null && 
                    SEGarden.GardenGateway.Files.Ready) 
                {
                    Log.Trace(ConstructionException.ToString(), 
                        "UpdateAfterSimulation");
                    PrintedLConstructionException = true;
                }

            }
        }


        public Main() {
            SetDebugConditional();

            try {
                Log.Trace("Registering session components", "Main");
                //UpdateManager.RegisterSessionComponent(new ServerTestSession());
                //Server = new ServerSession();
                //Client = new ClientSession();
                UpdateManager.RegisterSessionComponent(new ServerSession(), RunLocation.Server);
                UpdateManager.RegisterSessionComponent(new ClientSession(), RunLocation.Client);
                //UpdateManager.RegisterSessionComponent(new ClientSession());
                Constructed = true;

                Log.Trace("Registering entity components", "Main");
                //UpdateManager.RegisterEntityComponent(
                //    ((e) => { return new EnforcedGrid(e); }),
                //    typeof(MyObjectBuilder_CubeGrid),
                //    RunLocation.Server);

                UpdateManager.RegisterEntityComponent(
                    ((e) => {
                        return LootCrate.IsLootCrate(e) ?
                            new LootCrate(e) :
                            null;
                    }),
                    typeof(MyObjectBuilder_CubeGrid),
                    RunLocation.Server);

            }
            catch (Exception e) {
                ConstructionException = e;
            }
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private static void SetDebugConditional() { ModInfo.DebugMode = true; }

    }

}

*/