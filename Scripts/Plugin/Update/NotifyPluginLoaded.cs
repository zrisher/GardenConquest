using System.Linq;
using Sandbox.ModAPI;
using VRage.Game.Components;
using GardenConquest.ArmsOverrides;

namespace GardenConquest.Update
{
	static class NotifyPluginLoaded
	{
		private static void SetAttributeInModComponent(ulong modId, string modName, string modProject, string modClass, string ModFieldName, object ModFieldValue)
		{
			foreach (var mod in MyAPIGateway.Session.Mods.Where(x => x.PublishedFileId == modId || x.Name == modName))
			{
				Logger.DebugLog($"Looking for component in Steam mod: FriendlyName: {mod.FriendlyName}, Name: {mod.Name}, Published ID: {mod.PublishedFileId}");

				MySessionComponentBase component = Rynchodon.Mods.FindModSessionComponent(modName, modProject, modClass);
				if (component == null)
				{
					Logger.AlwaysLog($"Failed to find Session Component in mod.", Logger.severity.ERROR);
					continue;
				}
				else
				{
					Logger.DebugLog($"Setting {ModFieldName} = {ModFieldValue} in {component}", Logger.severity.TRACE);
					component.GetType().GetField(ModFieldName).SetValue(component, ModFieldValue);
					return;
				}
			}
			Logger.AlwaysLog($"Failed to find mod.", Logger.severity.ERROR);
		}

		[OnWorldLoad]
		private static void Load()
		{
			SetAttributeInModComponent(363880940, "GardenConquest", "Steam", "Notify", "PluginLoaded", true);
		}
	}
}
