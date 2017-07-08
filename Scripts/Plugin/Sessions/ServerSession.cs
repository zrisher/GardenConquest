/*
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
using VRage.ModAPI;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.Game.ObjectBuilders;

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


namespace GC.Sessions {

    public class ServerSession : SessionComponent {

        const ulong FramesBetweenLootSpawns = 60 * 3; //60; // 1 minute
        const uint FramesBetweenSpawnUpdates = 97;
        const ulong SupportedCPCount =
            FramesBetweenLootSpawns / FramesBetweenSpawnUpdates; // 37

        private static Logger Log = new Logger("GC.Sessions.ServerSession");

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

        public Settings Settings;
        //public List<EnforcedGrid> Grids = new List<EnforcedGrid>();

        private Queue<ControlPoint> CPsToUpdate = new Queue<ControlPoint>();    

        public override String ComponentName {get {return "GCServerSession";}}

        // TODO: tweak update intervals
        public override Dictionary<uint, Action> UpdateActions {
            get {
                return new Dictionary<uint, Action> {
                    {FramesBetweenSpawnUpdates, UpdateCPs},
                };
            }
        }

        #region Init / Terminate

        public override void Initialize() {
            Log.Trace("Initializing Server Session", "Initialize");

            if (ModInfo.DebugMode && !RunTests()) {
                Log.Info("Tests failed, aborting init.", "Initialize");
                return;
            }

            if (!Settings.TryLoadOrCreate(out Settings)) {
                Log.Info("Settings load failed, aborting init.", "Initialize");
                return;
            }

            Settings.ControlPoints.ForEach(x => x.Initialize());

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


            base.Initialize();
            Log.Trace("Finished Initializing Server Session", "Initialize");
        }

        public override void Terminate() {
            Log.Trace("Terminating Server Session", "Terminate");

            Log.Trace("Saving settings", "Initialize");
            //Settings.Instance.Save();

            //Log.Trace("Terminating concealment manager", "Terminate");
            //Manager.Terminate();

            Log.Trace("Terminating server messenger", "Terminate");
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
            base.Terminate();
            Log.Trace("Finished Terminating Server Session", "Terminate");

        }

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

        private void RegisterMessagesAndHandlers() {
            Log.Trace("Registering message handlers and ctrs", "Initialize");
            GardenGateway.Messages.AddConstructor((ushort)MessageType.LoginRequest, (bytes) => { return new LoginRequest(); });
            GardenGateway.Messages.AddHandler((ushort)MessageDomain.Server, (ushort)MessageType.LoginRequest, TestHandle);
            //Messenger.RegisterHandler<LoginRequest>(
            //    MessageType.LoginRequest, HandleLogin);
        }

        #endregion
        #region Updates

        /// <summary>
        /// Updates CP spawns, distributes one per frame
        /// </summary>
        private void UpdateCPs() {
            if (CPsToUpdate.Count > 0) {
                CPsToUpdate.Dequeue().UpdateSpawns();
            }

            if (UpdateManager.Frame % FramesBetweenLootSpawns == 0) {
                Settings.ControlPoints.ForEach(x => CPsToUpdate.Enqueue(x));
            }
        }

        #endregion
        #region Replies

        private void HandleLogin(Messages.Requests.LoginRequest request) {

        }

        private void TestHandle(SEGarden.Messaging.MessageBase msg) {
            Log.Trace("Received message!", "TestHandle");
        }

        #endregion
    }

}
*/