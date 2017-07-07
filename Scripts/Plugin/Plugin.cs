using System;
using System.Reflection;
using System.Runtime.CompilerServices;

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
        private Logable Log = new Logable("GC");

        public void Dispose()
        {
            Log.Entered();
        }

        /// <remarks>
        /// Skips inlining so the registrars correctly detect calling assembly.
        /// </remarks>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Init(object gameInstance)
        {
            Log.Entered();

            try
            {
                // Register our compilation symbol state
                SymbolRegistrar.SetDebugIfDefined();
                SymbolRegistrar.SetProfileIfDefined();

                // Register our SEPC-managed SessionComponents
                ComponentRegistrar.AddComponents();
                ComponentRegistrar.LoadOnInit(0);
            }
            catch (Exception error)
            {
                Log.Error(error);
            }

        }

        public void Update() { }
    }
}
