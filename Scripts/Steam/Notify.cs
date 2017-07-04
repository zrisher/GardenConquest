using Sandbox.ModAPI;
using VRage.Game.Components;

namespace GardenConquest
{
	/// <summary>
	/// Loads through the SE steam mod system.
	/// Plugin marks it once loaded.
	/// Notifies the player if the plugin never loaded.
	/// </summary>
	[MySessionComponentDescriptor(MyUpdateOrder.AfterSimulation)]
	public class Notify : MySessionComponentBase
	{
		private const string ModName = "GardenConquest";
		private const int NotifyDuration = 60000;

		// Plugin sets to true once loaded
		public bool PluginLoaded;

		private bool NoticeRaised;
		private int UpdateCount;

		public override void UpdateAfterSimulation()
		{
			if (NoticeRaised)
				return;

			if (PluginLoaded)
			{
				// TODO remove when working
				{
					MyAPIGateway.Utilities.ShowNotification(ModName + " successfully notified .", NotifyDuration);
					NoticeRaised = true;
					MyAPIGateway.Session.UnregisterComponent(this);
				}
				return;
			}

			UpdateCount++;
			if (UpdateCount < 100 ||
				MyAPIGateway.Session == null || MyAPIGateway.Utilities == null ||
				MyAPIGateway.Input == null || !MyAPIGateway.Input.IsAnyKeyPress())
				return;

			MyAPIGateway.Utilities.ShowNotification(ModName + " needs SEPL to run. See the User Guide on its Steam page.", NotifyDuration);
			NoticeRaised = true;
			MyAPIGateway.Session.UnregisterComponent(this);
		}
	}
}
