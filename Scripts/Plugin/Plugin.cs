using System.Reflection;

using VRage.Plugins;

using SEPC.Components;
using SEPC.Diagnostics;
using SEPC.Logging;

namespace GC
{
    /// <summary>
    /// Loaded with the game and persists until game is closed.
    /// Registers our mod with SEPC.
    /// </summary>
    public class Plugin : IPlugin
    {
        public void Dispose()
        {
            Logger.DebugLog("GC.Plugin.Dispose()");
        }

        public void Init(object gameInstance)
        {
            // Register our compilation symbol state
            SymbolRegistrar.SetDebugIfDefined();
            SymbolRegistrar.SetProfileIfDefined();

            Logger.DebugLog("GC.Plugin.Init()");

            // Register our SEPC-managed SessionComponents
            ComponentRegistrar.AddComponents(Assembly.GetExecutingAssembly());
            ComponentRegistrar.LoadOnInit(0, Assembly.GetExecutingAssembly());
        }

        public void Update() { }
    }
}
