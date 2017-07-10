using SEPC.Components.Attributes;
using SEPC.Logging;
using SEPC.Reflection;

using VRage.Sync;
using SEPC.Components;

namespace GC
{
    [IsSessionComponent(groupId: (int)Groups.Init)]
    class Session
    {
		public enum Groups { Init, Sessions }

		public static readonly ushort MessageDomain = (ushort)"GC".GetHashCode();

		private static readonly Logable Log = new Logable("GC");

		public Session()
        {
            // Only load if the steam version has been loaded too.
            var steamComponent = ReflectionHelper.FindModSessionComponent("GardenConquest", 450540708, "Steam", "GC.Notify");
            if (steamComponent == null)
                return;

            Log.Log("GC steam component found, loading mod.");

            Log.Trace("Registering session components");
			ComponentSession.RegisterComponentGroup((int)Groups.Sessions);
            //UpdateManager.RegisterSessionComponent(new ServerTestSession());

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
