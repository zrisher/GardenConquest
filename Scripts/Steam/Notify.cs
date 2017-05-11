using Sandbox.ModAPI;
using VRage.Game.Components;

namespace Steam
{
	[MySessionComponentDescriptor(MyUpdateOrder.AfterSimulation)]
	public class Notify : MySessionComponentBase
	{
		private const string ModName = "GardenConquest";

		public bool PluginLoaded = false; // Plugin sets to true when it loads.
		private bool HasNotified = false;
		private int UpdateCount = 0;

		/// <summary>
		/// Notifies the player that they need to download Load-ARMS.
		/// </summary>
		public override void UpdateAfterSimulation()
		{
			if (PluginLoaded || HasNotified)
				return;

			UpdateCount++;
			if (UpdateCount < 100 || MyAPIGateway.Session == null || MyAPIGateway.Utilities == null || MyAPIGateway.Input == null || !MyAPIGateway.Input.IsAnyKeyPress())
				return;

			HasNotified = true;
			MyAPIGateway.Utilities.ShowNotification(ModName + " needs Load-ARMS to run. See its Steam page for download link.", 60000);
			MyAPIGateway.Session.UnregisterComponent(this);
		}
	}
}

