using SEPC.Components.Attributes;
using SEPC.Logging;
using SEPC.Reflection;

using VRage.Sync;

namespace GC
{
    [IsSessionComponent]
    class Session
    {
        private Logable Log = new Logable("GC");

        public Session()
        {
            // Only load if the steam version has been loaded too.
            var steamComponent = ReflectionHelper.FindModSessionComponent("GardenConquest", 450540708, "Steam", "GC.Notify");
            if (steamComponent == null)
                return;

            Log.Log("GC steam component found, loading mod.");

            Log.Trace("Registering session components abcd");
            //UpdateManager.RegisterSessionComponent(new ServerTestSession());
            //UpdateManager.RegisterSessionComponent(new ServerSession(), RunLocation.Server);
            //UpdateManager.RegisterSessionComponent(new ClientSession(), RunLocation.Client);

            Log.Trace("Registering entity components");
            //UpdateManager.RegisterEntityComponent(
            //    ((e) => { return new EnforcedGrid(e); }),
            //    typeof(MyObjectBuilder_CubeGrid),
            //    RunLocation.Server);
            //UpdateManager.RegisterEntityComponent(
            //	((e) => {
            //		return LootCrate.IsLootCrate(e) ?
            //			new LootCrate(e) :
            //			null;
            //	}),
            //	typeof(MyObjectBuilder_CubeGrid),
            //	RunLocation.Server);

            // Tell the steam code we've loaded successfully.
            ReflectionHelper.SetInstanceField(steamComponent, "PluginLoaded", true);
        }
    }
}
