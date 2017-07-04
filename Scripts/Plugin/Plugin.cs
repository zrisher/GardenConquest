//using SEPC.Components;
using System;
using VRage.Plugins;
using VRage.Utils;

namespace GardenConquest
{
	/// <summary>
	/// Loaded with the game and persists until game is closed.
	/// Registers our LogicComponents.
	/// </summary>
	public class Plugin : IPlugin
	{
		public void Dispose()
		{
			MyLog.Default.WriteLine("GC.Plugin.Dispose()");
		}

		public void Init(object gameInstance)
		{
			MyLog.Default.WriteLine("GC.Plugin.Init()");
			/*
			// TODO remove this try
			try
			{
				// Tell the Registrar if we have DEBUG defined
				ComponentRegistrar.DebugConditional();

				// Tell the Registrar if we have PROFILE defined
				ComponentRegistrar.ProfileConditional();

				// Tell the Registrar about all our components
				ComponentRegistrar.AddComponents();

				// Tell the Registrar which group to load automatically
				ComponentRegistrar.LoadOnInit((int)Loader.Groups.Loader);
			}
			catch (Exception error)
			{
				Logger.DebugLog($"Error registering components: {error}");
			}
			*/
		}

		public void Update()
		{

		}
	}
}
