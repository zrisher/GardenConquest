using SEPC.Components.Attributes;
using SEPC.Logging;
using SEPC.Reflection;

namespace GC
{
    [IsSessionComponent]
    class Session
    {
        public Session()
        {
            // Only load if the steam version has been loaded too.
            var steamComponent = ReflectionHelper.FindModSessionComponent("GardenConquest", 450540708, "Steam", "GC.Notify");
            if (steamComponent == null)
                return;

            Logger.Log("GC steam component found, loading mod.");

            Logger.TraceLog("Registering session components");

            //UpdateManager.RegisterSessionComponent(new ServerTestSession());
            //UpdateManager.RegisterSessionComponent(new ServerSession(), RunLocation.Server);
            //UpdateManager.RegisterSessionComponent(new ClientSession(), RunLocation.Client);

            Logger.TraceLog("Registering entity components");
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
