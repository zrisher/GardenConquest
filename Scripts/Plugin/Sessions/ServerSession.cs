using System;
using System.Collections.Generic;
using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Serialization;

using Sandbox.Definitions;
using Sandbox.ModAPI;
//using Interfaces = Sandbox.ModAPI.Interfaces;
//using InGame = Sandbox.ModAPI.Ingame;

using VRage;
using VRage.ObjectBuilders;
using VRage.Library.Collections;
using VRage.ModAPI;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.Game.ObjectBuilders;

/*
using SEGarden;
using SEGarden.Extensions;
using SEGarden.Logging;
using SEGarden.Logic;
//using SEGarden.Notifications;
using SEGarden.Testing;
using SEGarden.World.Inventory;

using GC.App.LootSpawning;
using GC.Messages;
using GC.Messages.Requests;
using GC.Messages.Responses;
using GC.Tests;
using GC.Tests.App.LootSpawning;
using GC.Tests.Definitions;
using GC.Tests.Definitions.BlockTaxonomy;
using GC.Tests.Definitions.GridTaxonomy;
using GC.Tests.Definitions.LootSpawning;
using GC.World.Blocks;
using GC.World.Grids;
*/

using SEPC.Components;
using SEPC.Components.Attributes;
using SEPC.Extensions;
using SEPC.Logging;
using SEPC.Network.Messaging;

namespace GC.Sessions {

	[IsSessionComponent(RunLocation.Client, groupId: (int)Session.Groups.Sessions, order: RegistrationOrder)]
	public class ServerSession {

		public const int RegistrationOrder = 0;

		const ulong FramesBetweenLootSpawns = 60 * 3; //60; // 1 minute
        const uint FramesBetweenSpawnUpdates = 97;
        const ulong SupportedCPCount = FramesBetweenLootSpawns / FramesBetweenSpawnUpdates; // 37

        private static Logable Log = new Logable("GC.Sessions");

        //private static Action<int, List<long>, List<IMyPlayer>, ControlPoint> rewardDistribution;
        //public static event Action<int, List<long>, List<IMyPlayer>, ControlPoint> RewardsDistributed {
        //    add { rewardDistribution += value; }
        //    remove { rewardDistribution -= value; }
        //}
        //private static void notifyRewardsDistributed(int distributed, List<long> winningFleets,
        //    List<IMyPlayer> nearbyPlayers, ControlPoint cp) {
        //    if (rewardDistribution != null)
        //        rewardDistribution(distributed, winningFleets, nearbyPlayers, cp);
        //}

        ////public Settings Settings;
        //public List<EnforcedGrid> Grids = new List<EnforcedGrid>();

        ////private Queue<ControlPoint> CPsToUpdate = new Queue<ControlPoint>();    

        #region Init / Terminate

        public ServerSession() {
            Log.Trace("Initializing Server Session");

			RegisterMessageHandlers();



            ////if (ModInfo.DebugMode && !RunTests()) {
            ////    Log.Info("Tests failed, aborting init.", "Initialize");
            ////    return;
            ////}

            ////if (!Settings.TryLoadOrCreate(out Settings)) {
            ////    Log.Info("Settings load failed, aborting init.", "Initialize");
            ////    return;
            ////}

            ////Settings.ControlPoints.ForEach(x => x.Initialize());

            //Log.Trace("Registering concealment manager", "Initialize");
            //Manager = new ConcealmentManager();
            //Manager.Initialize();
            //if (!Manager.Loaded) {
            //    Log.Error("Error loading sector, conceal disabled.", "Initialize");
            //    Messenger.Disabled = true;
            //}

            // Start round timer
            //m_RoundTimer = new MyTimer(s_Settings.CPPeriod * 1000, roundEnd);
            //m_RoundTimer.Start();
            //log("Round timer started with " + s_Settings.CPPeriod + " seconds");

            // Subscribe events
            //GridEnforcer.OnPlacementViolation += eventPlacementViolation;
            //GridEnforcer.OnCleanupViolation += eventCleanupViolation;
            //GridEnforcer.OnCleanupTimerStart += eventCleanupTimerStart;
            //GridEnforcer.OnCleanupTimerEnd += eventCleanupTimerEnd;
            //ControlPoint.OnRewardsDistributed += notifyPlayersOfCPResults;

            Log.Trace("Finished Initializing Server Session");
        }

		[OnSessionClose]
        void Terminate() {
            Log.Trace("Terminating Server Session");

            ////Log.Trace("Saving settings", "Initialize");
            //Settings.Instance.Save();

            //Log.Trace("Terminating concealment manager", "Terminate");
            //Manager.Terminate();

            ////Log.Trace("Terminating server messenger", "Terminate");
            //if (Messenger != null)
               // Messenger.Disabled = true;

            //GridEnforcer.OnPlacementViolation -= eventPlacementViolation;
            //GridEnforcer.OnCleanupViolation -= eventCleanupViolation;
            //GridEnforcer.OnCleanupTimerStart -= eventCleanupTimerStart;
            //GridEnforcer.OnCleanupTimerEnd -= eventCleanupTimerEnd;
            //ControlPoint.OnRewardsDistributed -= notifyPlayersOfCPResults;

            //m_RoundTimer.Dispose();
            //m_RoundTimer = null;
            //m_SaveTimer.Dispose();
            //m_SaveTimer = null;

            //Instance = null;
            Log.Trace("Finished Terminating Server Session");

        }

		/*
        private bool RunTests() {
            return Specification.RunSpecTests(
                "GardenConquest Server",
                new List<Specification>{
                    new BlockTypeCategoryDefinitionSpec(),
                    new BlockTypeDefinitionSpec(),
                    new ConditionDefinitionSpec(),
                    new ConditionValueDefinitionSpec(),
                    new ControlPointDefinitionSpec(),
                    new LootCrateCountDefinitionSpec(),
                    new LootCrateDefinitionSpec(),
                    new ControlPointSpec(),
                    new LootDropDefinitionSpec(),
                    new NodeDefinitionSpec(),
                    new SettingsDefinitionSpec(),
                    new SettingsSpec(),              
                }             
            );
        }
		*/


        #endregion
        #region Updates

        /// <summary>
        /// Updates CP spawns, distributes one per frame
        /// </summary>
		[OnSessionUpdate(FramesBetweenSpawnUpdates)]
        void UpdateCPs() {
			/*
            if (CPsToUpdate.Count > 0) {
                CPsToUpdate.Dequeue().UpdateSpawns();
            }

            if (UpdateManager.Frame % FramesBetweenLootSpawns == 0) {
                Settings.ControlPoints.ForEach(x => CPsToUpdate.Enqueue(x));
            }
			*/
        }

		#endregion
		#region Message Handlers

		void RegisterMessageHandlers()
		{
			Log.Entered();
			HandlerRegistrar.Register(Session.MessageDomain, (ushort)Messages.MessageType.LoginRequest, HandleLoginRequest);
		}

		void HandleLoginRequest(BitStream data, ulong senderId) {
			Log.Entered();
			string content = data.ReadString();
			Log.Debug($"Received Login Request from '{senderId}' with content '{content}'");

			BitStream stream = new BitStream();
			stream.ResetWrite();
			stream.WriteString("This is 249er, we read you loud and clear Breaker.");
			Messenger.SendToPlayer(stream, Session.MessageDomain, (ushort)Messages.MessageType.LoginResponse, senderId);
		}

        #endregion
    }

}
