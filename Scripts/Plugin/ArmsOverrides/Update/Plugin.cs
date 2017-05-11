using System.Reflection;
using Sandbox.Game.World;
using VRage.Plugins;

/// <summary>
/// Just for UpdateManager
/// </summary>
namespace GardenConquest.ArmsOverrides.Update
{
	public class Plugin : IPlugin
	{
		private bool _loaded;

		public void Dispose() { }

		public void Init(object gameInstance) { }

		public void Update()
		{
			if (MySession.Static != null && MySession.Static.Ready)
			{
				if (!_loaded)
				{
					Load();
					_loaded = true;
				}
			}
		}

		private static void Load()
		{
			// TODO: Only load when steam mod is selected (i.e. get my own block for the below)
			// if (!Game.IsDedicated && MyDefinitionManager.Static.GetCubeBlockDefinition(new SerializableDefinitionId(typeof(MyObjectBuilder_Cockpit), "Autopilot-Block_Large")) == null)
			//	return;

			Logger.DebugLog("Loading GardenConquest.ARMSOverrides");
			MySession.Static.RegisterComponentsFromAssembly(Assembly.GetExecutingAssembly(), true);
		}
	}
}
