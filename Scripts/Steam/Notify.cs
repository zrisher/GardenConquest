using Sandbox.ModAPI;
using VRage.Game;
using VRage.Game.Components;

namespace GC
{
	/// <summary>
	/// Loads through the SE steam mod system.
	/// Plugin sets PluginLoaded = true via reflection once loaded.
	/// Notifies the player of the plugin's load status.
	/// </summary>
	[MySessionComponentDescriptor(MyUpdateOrder.AfterSimulation)]
	public class Notify : MySessionComponentBase
	{
		// Mod-specific configuration
		private const string ModName = "GardenConquest";
		private const bool NotifyOnSuccess = true;

		private bool PluginLoaded;
		private bool NoticeRaised;
		private int UpdateCount;

		public override void UpdateAfterSimulation()
		{
			if (NoticeRaised)
				return;

			if (PluginLoaded)
			{
				if (NotifyOnSuccess)
					MyAPIGateway.Utilities.ShowNotification(ModName + " loaded.", 6000, MyFontEnum.Green);

				NoticeRaised = true;
				MyAPIGateway.Session.UnregisterComponent(this);
				return;
			}

			UpdateCount++;
			if (UpdateCount < 100 ||
				MyAPIGateway.Session == null || MyAPIGateway.Utilities == null ||
				MyAPIGateway.Input == null || !MyAPIGateway.Input.IsAnyKeyPress())
				return;

			MyAPIGateway.Utilities.ShowNotification(ModName + " failed to load. Ensure you've installed SEPL.", 60000, MyFontEnum.Red);
			NoticeRaised = true;
			MyAPIGateway.Session.UnregisterComponent(this);
		}
	}
}
