using System;

using Sandbox.Game;
using Sandbox.Graphics.GUI;
using VRage.Game.ModAPI;

using SEPC.Components.Attributes;
using SEPC.Logging;
using SEPC.Reflection;
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
			{
				Log.Log("Garden Conquest steam mod not pressent in this session. Not running.");
				return;
			}
               

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
		

			//MyAPIGateway.Utilities.ShowMissionScreen("title", "currentObjectivePrefix", "currentObjective", "description", (x) => ButtonClicked(x), "buttonCaption");
			//ShowScreen("title", "currentObjectivePrefix", "currentObjective", "description", (x) => ButtonClicked(x), "buttonCaption");
			//MyGuiSandbox.AddScreen(MyGuiSandbox.CreateScreen(MyPerGameSettings.GUI.ScenarioScreen));

			// Tell the steam code we've loaded successfully.
			ReflectionHelper.SetInstanceField(steamComponent, "PluginLoaded", true);
        }

		/*
		void ShowScreen(string screenTitle, string currentObjectivePrefix, string currentObjective, string screenDescription, Action<ResultEnum> callback = null, string okButtonCaption = null)
		{
			var missionScreen = new App.GridTaxonomy.EditorScreen(missionTitle: screenTitle,
				currentObjectivePrefix: currentObjectivePrefix,
				currentObjective: currentObjective,
				description: screenDescription,
				resultCallback: callback,
				okButtonCaption: okButtonCaption);

			MyScreenManager.AddScreen(missionScreen);
			//MyScreenManager.AddScreen(new Sandbox.Game.Screens.MyGuiScreenSc);
		}

		public void ButtonClicked(ResultEnum result)
		{
			Log.Trace($"Button clicked result: {result}");
			MyScreenManager.AddScreen(new App.GridTaxonomy.EditorScreenNew());
		}
		*/
    }
}
