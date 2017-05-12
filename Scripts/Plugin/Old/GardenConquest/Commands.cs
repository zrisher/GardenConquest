/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sandbox.ModAPI;

using VRageMath;

using SEGarden.Chat.Commands;
using SEGarden.Notifications;
using SEGarden.Logging;

//using GP.World.Entities;
//using GP.Messages.Requests;
using GC.App.LootSpawning;
using GC.Sessions;


namespace GC {

    static class Commands {

        static readonly Logger Log = new Logger("GC.Commands");

        static ClientSession Session {
            get { return ClientSession.Instance; }
        }

        #region Admin

        static Command AdminSpawnCrateCommand = new Command(
            "spawn",
            "spawn a crate",
            ".... is this ever shown for a command? ...",
            (List<String> args) => {
                var x = Double.Parse(args[0]);
                var y = Double.Parse(args[1]);
                var z = Double.Parse(args[2]);
                var pos = new Vector3D(x, y, z);
                var r = UInt32.Parse(args[3]);
                var cp = new ControlPoint("test CP", pos, r, null);


                var spawned = cp.SpawnCrate();

                if (spawned != null) {
                    return new AlertNotification() {
                        Text = "Successfully spawned at " + spawned.PositionComp.WorldMatrix.Translation.ToString(),
                        Color = VRage.Game.MyFontEnum.Green,
                        DisplaySeconds = 6
                    };
                }

                return null;
            },
            new List<String> { "X", "Y", "Z", "radius" }
        );

        static Tree AdminTree = new Tree(
            "admin",
            "Administration tools",
            "... long description of admin tools ...",
            0,
            new List<Node> {
                AdminSpawnCrateCommand
                //AdminBlockTypesTree,
                //AdminFleetsCommand,
                //AdminLicensesCommand,
            }
        );
        

        #endregion
        #region Settings



        #endregion
        #region Fleet

        static Command FleetStopCommand = new Command(
            "stop",
            "Stop your Nth ship of class CLASS",
            "Reveal a grid....",
            (List<String> args) => {
                int n = Int32.Parse(args[0]);
                //List<ConcealedGrid> grids = Session.ConcealedGrids;
                //
                //if (grids == null) return new ChatNotification() {
                //    Text = "No list of concealed grids available.",
                //    Sender = "GP"
                //};
                //
                //if (n < 1 || n > grids.Count) return new ChatNotification() {
                //    Text = "Incorrect index for list",
                //    Sender = "GP"
                //};

                //ConcealedGrid grid = grids[n - 1];
                //long entityId = grid.EntityId;

                //Log.Trace("Requesting Reveal Grid " + entityId, "RevealCommand");
                //RevealRequest request = new RevealRequest { EntityId = entityId };
                //request.SendToServer();
                // 
                //String text = grid.ConcealmentDetails() + 
                //    "\nNote: Run \"/gp c concealed list\" to refresh this info.";
				//
                //return new WindowNotification() {
                //    Text = text,
                //    BigLabel = "Garden Conquest",
                //    SmallLabel = "Revealed Grid Detail"
                //};
                return null;

            },
            new List<String> { "CLASS", "N" },
            0
        );

        static Command FleetViolationsCommand = new Command(
            "violations",
            "Your fleet's current rule violations, if any",
            "current rule violations are....",
            (List<String> args) => {
                Log.Trace("Requesting Observing Entities", "ObserversCommand");

                //m_MailMan.requestViolations();

                return new EmptyNotification();
            }
        );

        static Tree FleetTree = new Tree(
            "fleet",
            "Info on your fleet",
            "built fleet info",
            0,
            new List<Node> {
                        FleetStopCommand,
                        FleetViolationsCommand
                    },
            "f"
        );

        #endregion
        #region CPs

        static Command CPsHideCommand = new Command(
            "hide",
            "Hide the CP GPS markers",
            "....",
            (List<String> args) => {
                Log.Trace("Requesting Observing Entities", "ObserversCommand");

                //m_MailMan.removeCPGPS();

                return new EmptyNotification();
            }
        );

        static Command CPsShowCommand = new Command(
            "show",
            "Show the CP GPS markers",
            "....",
            (List<String> args) => {
                Log.Trace("Requesting Observing Entities", "ObserversCommand");

                //m_MailMan.addCPGPS();

                return new EmptyNotification();
            }
        );

        static Tree CPsTree = new Tree(
            "cps",
            "Info on Control Points",
            "cps info.......",
            0,
            new List<Node> {
                        CPsHideCommand,
                        CPsShowCommand
                    },
            "controlpoints"
        );

        #endregion
        #region Help

        static Command HelpClassesCommand = new Command(
            "classes",
            "Ship Classes and their limits",
            "....",
            (List<String> args) => {
                Log.Trace("Requesting Observing Entities", "ObserversCommand");

                return new EmptyNotification();
            }
        );

        static Command HelpClassifiersCommand = new Command(
            "classifiers",
            "Hull Classifier blocks",
            "....",
            (List<String> args) => {
                Log.Trace("Requesting Observing Entities", "ObserversCommand");

                return new EmptyNotification();
            }
        );

        static Command HelpLicensesCommand = new Command(
            "licenses",
            "Ship License components",
            "....",
            (List<String> args) => {
                Log.Trace("Requesting Observing Entities", "ObserversCommand");

                return new EmptyNotification();
            }
        );

        static string HelpLicensesText =
            "Ship Licences are a new type of building component introduced by " +
            "Garden Conquest. You can acquire Ship Licences by holding " +
            "Control Points. \n\n" +
            "You use Ship Licenses to build Hull Classifier " +
            "blocks, which determine the class of your Ship/Station.\n\n" +
            "For more info, see:\n" +
            "    /gc help classifiers\n" +
            "    /gc help cps\n";

        static Tree HelpTree = new Tree(
            "help",
            "info on the mod",
            "these commands give you info on the mod",
            0,
            new List<Node> {
                        HelpClassesCommand,
                        HelpClassifiersCommand,
                        HelpLicensesCommand,
                    }
        );


        #endregion

        public static Tree FullTree = new Tree(
            "gc",
            "all GardenConquest commands",
            "     ---------- GardenConquest v" + ModInfo.Version.Full + 
            " ---------- \n\n" +
            "Garden Conquest is an open-source Conquest mod. " +
            "It introduces ship classes, maintenance, and control points for " +
            "combat-focused survival servers. GC is designed to facilitate " + 
            "combat and help keep server load under control. \n\n",
            0,
            new List<Node> {
                AdminTree,
                //CPsTree, 
                //FleetTree, 
                //HelpTree, 
                //SettingsTree 
            }, 
            null, null, "Garden Conquest"
        );

    }
}
*/


        /*
        static Command AdminBlocksTypesUnknownCommand = new Command(
            "unknown",
            "all blocks with an unknown type",
            ".... is this ever shown for a command? ...",
            (List<String> args) => {

                String text = "All blocks with an unknown type. Suggest adding these to an existing type.\n";

                foreach (var grid in ServerSession.Instance.Grids) {

                    foreach (var block in grid.Blocks.Values) {
                        if (block.Type == GC.World.Blocks.BlockType.Unknown) {
                            text += block.Slim.ToString() + " on " + grid.Grid.DisplayName + "\n";
                        }
                    }
                }

                return new WindowNotification() {
                    Text = text,
                    BigLabel = "Garden Conquest",
                    SmallLabel = "Blocks with an unknown type"
                };
            }
        );

        static Command AdminBlocksTypesListCommand = new Command(
            "list",
            "list all block types",
            ".... is this ever shown for a command? ...",
            (List<String> args) => {

                String text = "";

                foreach (var type in GC.World.Blocks.BlockType.KnownTypes) {
                    text += String.Format("Name: {0}\n", type.DisplayName);
                    text += String.Format("  SubtypeNames: {0}\n", String.Join(", ", type.SubtypePartialNames));
                    text += String.Format("  BasicCost: {0}\n", type.BasicCost.ToString());
                    text += String.Format("  EnabledCost: {0}\n", type.EnabledCost.ToString());
                    text += String.Format("  EnablePriority: {0}\n", type.EnablePriority);
                    text += "\n";
                }

                return new WindowNotification() {
                    Text = text,
                    BigLabel = "Garden Conquest",
                    SmallLabel = "Block Types"
                };
            }
        );

        static Tree AdminBlockTypesTree = new Tree(
            "blocktypes",
            "Edit block types",
            "... long description ...",
            0,
            new List<Node> {
                AdminBlocksTypesListCommand,
                AdminBlocksTypesUnknownCommand,
            }
        );

        static Command AdminLicensesCommand = new Command(
            "licenses",
            "list all known license types",
            ".... is this ever shown for a command? ...",
            (List<String> args) => {

                String text = "";

                foreach (var def in ServerSession.Instance.LicenseDefinitions.Values) {
                    text += String.Format("{0} - {1}\n", def.Id.SubtypeName, def.Id);
                }

                return new WindowNotification() {
                    Text = text,
                    BigLabel = "Garden Conquest",
                    SmallLabel = "All License Types"
                };
            }
        );


        static Command AdminFleetsCommand = new Command(
            "fleets",
            "list all fleets",
            ".... is this ever shown for a command? ...",
            (List<String> args) => {

                String text = "Grids for all fleets - temporary:\n";

                foreach (var grid in ServerSession.Instance.Grids) {
                    text += "\n";
                    text += "Grid: " + grid.Grid.DisplayName + "\n";
                    text += "Cost: " + grid.CurrentBaseCost.ToString() + "\n";
                    text += "Available: " + grid.AvailableLicenses.ToString() + "\n";

                    var supported = grid.SupportedBlocks;
                    var decaying = grid.DecayingBlocks;

                    if (supported.Count > 0) {
                        text += "  Supported Blocks: \n";
                        foreach (var block in grid.SupportedBlocks) {
                            text += "            Id: " + block.Slim.ToString() + "\n";
                            text += "        Type: " + block.Type.DisplayName + "\n";
                        }
                    }
                    if (decaying.Count > 0) {
                        text += "  Decaying Blocks: \n";
                        foreach (var block in grid.DecayingBlocks) {
                            text += "            Id: " + block.Slim.ToString() + "\n";
                            text += "        Type: " + block.Type.DisplayName + "\n";
                        }
                    }
                }

                return new WindowNotification() {
                    Text = text,
                    BigLabel = "Garden Conquest",
                    SmallLabel = "All Fleets"
                };
            }
        );
        */

        /*
        static Command SettingsListCommand = new Command(
            "list",
            "list settings",
            "Settings are....",
            (List<String> args) => {
                Log.Trace("Requesting Observing Entities", "ObserversCommand");

                Notification notice = new WindowNotification() {
                    Text = Session.Settings.Describe(),
                    BigLabel = "Garden Conquest",
                    SmallLabel = "Settings"
                };

                return notice;
            }
        );

  
        static Command SettingsSetCommand = new Command(
            "set",
            "set setting N to X",
            "Details....",
            (List<String> args) => {
                byte n = Byte.Parse(args[0]);
                ushort x = UInt16.Parse(args[1]);

                Settings settings = Session.Settings;

                if (settings == null) return new ChatNotification() {
                    Text = "No list of settings available.",
                    Sender = "GP"
                };


                if (n < 1 || n > settings.Count) return new ChatNotification() {
                    Text = "Incorrect index for list",
                    Sender = "GP"
                };

                // TODO - have a setting identifier enum
                Log.Trace("Requesting change setting " + n + " to " + x, "ConcealCommand");

                //ChangeSettingRequest request = new ChangeSettingRequest {
                //    Index = n,
                //    Value = x
                //};
                //request.SendToServer();

                return null;


            },
            new List<String> { "N", "X" },
            0
        );

        static Tree SettingsTree = new Tree(
            "settings",
            "setting management",
            "setting management...",
            0,
            new List<Node> { 
                SettingsListCommand, 
                SettingsSetCommand 
            }
        );
        */

/*
static String helpClassifiersText() {
	if (s_HelpClassifiersText != null)
		return s_HelpClassifiersText;

	s_HelpClassifiersText =
		"Hull Classifiers are new blocks that each correspond to one " +
		"of the various classes.\n\n" +

		"Classifiers must be fully built and powered to designate your " +
		"ship as a member of its class.\n\n" +

		"Every Ship/Station must be classified, even the \"Unlicensed\" " +
		"ones. Unlicensed classifiers do not require Ship Licenses " +
		"to build, but they have relatively low block limits.\n\n" +

		"Unclassified ships are not allowed and will have some of their " +
		"blocks removed every " +
		Utility.prettySeconds(m_MailMan.ServerSettings.CleanupPeriod) + ", " +

		"For more info on Classes, type \"/gc help classes\"\n";

	return s_HelpClassifiersText;

	return "";
}

static String helpClassesText() {
	if (s_HelpClassesText != null)
		return s_HelpClassesText;

	s_HelpClassesText = "";
	int blockTypesLength = m_MailMan.ServerSettings.BlockTypes.Length;
	List<String> allowedBlockTypes = new List<String>();
	List<String> disallowedBlockTypes = new List<String>();
	String name;
	int limit;

	foreach (Records.HullRuleSet hr in m_MailMan.ServerSettings.HullRules) {
		s_HelpClassesText +=
			" --- " + hr.DisplayName + " --- \n" +
			"CP Control Value:  " + hr.CaptureMultiplier + "\n" +
			"Total allowed: " +
			hr.MaxPerFaction + " per faction, " +
			hr.MaxPerSoloPlayer + " for an individual.\n" +
			"Max blocks: " + hr.MaxBlocks + "\n";

		if (hr.ShouldBeStation) {
			s_HelpClassesText += "Must be a Station\n";
		}

		allowedBlockTypes.Clear();
		disallowedBlockTypes.Clear();

		for (int i = 0; i < blockTypesLength; ++i) {
			limit = hr.BlockTypeLimits[i];
			name = m_MailMan.ServerSettings.BlockTypes[i].DisplayName;
			if (limit < 0) {
				allowedBlockTypes.Add("unlimited " + name);
			}
			else if (limit > 0) {
				allowedBlockTypes.Add(limit + " " + name);
			}
			else {
				disallowedBlockTypes.Add(name);
			}
		}

		s_HelpClassesText +=
			"Allowed: " + String.Join(", ", allowedBlockTypes) + "\n" +
			"Denied: " + String.Join(", ", disallowedBlockTypes) + "\n\n";
	}

	// todo - get more info in here like the below
	// i.e.  ▲ StrikeCraft
	// += symbol, tier, name, license cost, max per faction
	// i.e. ▲ III Gunship - 55 L, 3 per faction
	// += grid size, block max
	// i.e. Large or Station, 500 blocks
	// foreach block limit
	// += num, category
	// i.e. 1 turret
	// 2 static weapons
	// 3 production
	// String result = "Classes:\n\n" +
	// "'5 L' means the Classifier costs 5 Ship Licenses\n" +
	// "'Small' and 'Large' below refer to Ship sizes.\n" +
	// "Block, turret, etc counts are maximums.\n\n";

	return s_HelpClassesText;
}

static String helpCPsText() {
	if (s_HelpCPsText != null)
		return s_HelpCPsText;

	s_HelpCPsText =
		"Control Points are areas of the map you can hold and control. " +
		"Each CP has a Position, Radius, and Reward:\n\n";

	foreach (Records.ControlPoint cp in m_MailMan.ServerSettings.ControlPoints) {
		s_HelpCPsText += String.Format("{0} @ {1}, {2}, {3} Licenses\n",
			cp.Name, cp.Position, Utility.prettyDistance(cp.Radius), cp.TokensPerPeriod);
	}

	s_HelpCPsText +=
		"\nWhomever controls a CP at the end of a round will receive its reward. " +
		"Rounds are calculated every " +
		Utility.prettySeconds(m_MailMan.ServerSettings.CPPeriod) + ".\n\n" +

		"In order to control the CP, your fleet must " +
		"have the most ships in that area that:\n" +
		"* have a powered, broadcasting Hull Classifier\n" +
		"* have a broadcast range on the classifier at least as large " +
		" as the ship's distance to the CP. (This is to prevent players " +
		"from hiding while capturing a CP. If someone stands in the " +
		"center of a CP, they will see broadcasts from every " +
		"Conquesting ship.)\n\n" +

		"Bigger ships count more towards your total. In the event of a " +
		"tie, no one wins.\n\n" +

		"The winner of a round will receive the Licenses directly into " +
		"the first open inventory in their largest ship. If they have no " +
		"open inventory, they won't receive the Licenses.\n";

	return s_HelpCPsText;
	return "";
}
*/
