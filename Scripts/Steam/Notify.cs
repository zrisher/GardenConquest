using Sandbox.ModAPI;
using VRage.Game.Components;

namespace GardenConquest
{
	/// <summary>
	/// Loads through the SE steam mod system.
	/// SEPL plugins mark it when they've loaded.
	/// Notifies the player if the plugin never loaded.
	/// </summary>
	[MySessionComponentDescriptor(MyUpdateOrder.AfterSimulation)]
	public class Notify : MySessionComponentBase
	{
		private const string ModName = "GardenConquest";
		private const int NotifyDuration = 60000;

		// Plugin sets to true when it loads.
		public bool PluginLoaded = false;

		private bool HasNotified = false;
		private int UpdateCount = 0;

		public override void UpdateAfterSimulation()
		{
			if (HasNotified)
				return;

			if (PluginLoaded)
			{
				// TODO remove when working
				{
					HasNotified = true;
					MyAPIGateway.Utilities.ShowNotification(ModName + " successfully notified .", NotifyDuration);     
					MyAPIGateway.Session.UnregisterComponent(this);
				}

				return;
			}

			UpdateCount++;
			if (UpdateCount < 100 ||
				MyAPIGateway.Session == null || MyAPIGateway.Utilities == null ||
				MyAPIGateway.Input == null || !MyAPIGateway.Input.IsAnyKeyPress())
				return;

			HasNotified = true;
			MyAPIGateway.Utilities.ShowNotification(ModName + " needs SEPL to run. See its Steam page for download link.", NotifyDuration);
			MyAPIGateway.Session.UnregisterComponent(this);
		}
	}
}
