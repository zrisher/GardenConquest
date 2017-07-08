/*
using System;
using System.Collections.Generic;
using System.Text;

using SEGarden;
using SEGarden.Logging;
using SEGarden.Logic;
//using SEGarden.Notifications;

using GC.Messages.Requests;

namespace GC.Sessions {

    public class ClientSession : SessionComponent {

        private static Logger Log = new Logger("GC.Sessions.ClientSession");

        public static ClientSession Instance;
        //public static ClientMessageHandler Messenger;
        public Settings Settings;
        //public ulong LocalSteamId;

        public override string ComponentName { 
            get { return "GCClientSession"; } 
        }

        public override Dictionary<uint, Action> UpdateActions {
            get {
                var actions = base.UpdateActions;
                //actions.Add(150, UpdateLojackWarning);
                return actions;
            }
        }

        public override void Initialize() {
            Log.Trace("Initializing Client Session", "Initialize");
            GardenGateway.Commands.addCommands(Commands.FullTree);
            //Messenger = new ClientMessageHandler();
            new LoginRequest().SendToServer();
            //new SettingsRequest().SendToServer();
            //m_Player = MyAPIGateway.Session.Player;
  
            Instance = this;
            base.Initialize();
            Log.Trace("Finished Initializing Client Session", "Initialize");
        }

        public override void Terminate() {
            Log.Trace("Terminating Client Session", "Terminate");
            //Messenger = null;
            // m_Player = null

            Instance = null;
            base.Terminate();
            Log.Trace("Finished Terminate Client Session", "Terminate");
        }

        private void HandleLoginResponse() { 
        }


        private void UpdateLojackWarning()
        {
            // if (m_Player.Controller.ControlledEntity is InGame.IMyShipController) {
            //    IMyCubeGrid currentControllerGrid = (m_Player.Controller.ControlledEntity as IMyCubeBlock).CubeGrid;
            //    IMyCubeBlock classifierBlock = currentControllerGrid.getFirstClassifierBlock();
            //    if (classifierBlock != null && classifierBlock.OwnerId != m_Player.PlayerID && ConquestSettings.getInstance().SimpleOwnership) {
            //        MyAPIGateway.Utilities.ShowNotification("WARNING: Take control of the hull classifier or you may be tracked by the original owner!", 1250, MyFontEnum.Red);
            //    }
            //}
        }



    }
}
*/

#region Make Requests
/*

public bool requestSettings() {
  log("Sending Settings request", "requestSettings");
  try {
	  SettingsRequest req = new SettingsRequest();
	  req.ReturnAddress = MyAPIGateway.Session.Player.PlayerID;
	  send(req);
	  return true;
  }
  catch (Exception e) {
	  log("Exception occured: " + e, "requestSettings", Logger.severity.ERROR);
	  return false;
  }
}

public bool requestFleet(String hullClassString = "") {
  log("Sending Fleet request", "requestFleet");
  try {
	  FleetRequest req = new FleetRequest();
	  req.ReturnAddress = MyAPIGateway.Session.Player.PlayerID;
	  send(req);
	  return true;
  }
  catch (Exception e) {
	  log("Exception occured: " + e, "requestFleet");
	  return false;
  }
}

public bool requestViolations(String hullClassString = "") {
  log("Sending Violations request", "requestViolations");
  try {
	  ViolationsRequest req = new ViolationsRequest();
	  req.ReturnAddress = MyAPIGateway.Session.Player.PlayerID;
	  send(req);
	  return true;
  }
  catch (Exception e) {
	  log("Exception occured: " + e, "requestViolations");
	  return false;
  }
}

public bool requestStopGrid(string shipClass, string ID) {
  log("Sending Stop Grid request", "requestStopGrid");
  try {
	  HullClass.CLASS classID;
	  int localID = -1;

	  // Check user's input for shipClass is valid
	  if (!Enum.TryParse<HullClass.CLASS>(shipClass.ToUpper(), out classID)) {
		  MyAPIGateway.Utilities.ShowNotification("Invalid Ship Class!", Constants.NotificationMillis, MyFontEnum.Red);
		  return false;
	  }
	  // Check if user's input for index is valid
	  if (!int.TryParse(ID, out localID) || localID < 1 || localID > m_SupportedGrids[(int)classID].Count + m_UnsupportedGrids[(int)classID].Count) {
		  MyAPIGateway.Utilities.ShowNotification("Invalid Index!", Constants.NotificationMillis, MyFontEnum.Red);
		  return false;
	  }

	  long entityID;

	  //Some logic to decide whether or not the choice is a supported or unsupported grid, and its entityID
	  if (localID - 1 >= m_SupportedGrids[(int)classID].Count ) {
		  entityID = m_UnsupportedGrids[(int)classID][localID - 1 - m_SupportedGrids[(int)classID].Count].shipID;
	  } else {
		  entityID = m_SupportedGrids[(int)classID][localID - 1].shipID;
	  }

	  StopGridRequest req = new StopGridRequest();
	  req.ReturnAddress = MyAPIGateway.Session.Player.PlayerID;
	  req.EntityID = entityID;
	  send(req);
	  return true;
  }
  catch (Exception e) {
	  log("Exception occured: " + e, "requestStopGrid");
	  return false;
  }
}

public bool requestDisown(string shipClass, string ID) {
  log("Sending Disown request", "requestDisown");
  try {
	  int classID = (int)Enum.Parse(typeof(HullClass.CLASS), shipClass.ToUpper());
	  int localID = Convert.ToInt32(ID);
	  long entityID;

	  //Some logic to decide whether or not the choice is a supported or unsupported grid, and its entityID
	  if (localID >= m_SupportedGrids[classID].Count) {
		  entityID = m_UnsupportedGrids[classID][localID - m_SupportedGrids[classID].Count].shipID;
	  } else {
		  entityID = m_SupportedGrids[classID][localID].shipID;
	  }

	  DisownRequest req = new DisownRequest();
	  req.ReturnAddress = MyAPIGateway.Session.Player.PlayerID;
	  req.EntityID = entityID;
	  send(req);
	  return true;
  }
  catch (Exception e) {
	  log("Exception occured: " + e, "requestDisown");
	  return false;
  }
}
*/
/*
#endregion
#region Process Responses
/*
public void incomming(byte[] buffer) {
  log("Got message of size " + buffer.Length, "incomming");

  try {
	  // Deserialize the message
	  BaseResponse msg = BaseResponse.messageFromBytes(buffer);

	  // Is this message even intended for us?
	  if (msg.DestType == BaseResponse.DEST_TYPE.FACTION) {
		  IMyFaction fac = MyAPIGateway.Session.Factions.TryGetPlayerFaction(
			  MyAPIGateway.Session.Player.PlayerID);
		  if (fac == null || !msg.Destination.Contains(fac.FactionId)) {
			  return; // Message not meant for us
		  }
	  } else if (msg.DestType == BaseResponse.DEST_TYPE.PLAYER) {
		  long localUserId = (long)MyAPIGateway.Session.Player.PlayerID;
		  if (!msg.Destination.Contains(localUserId)) {
			  return; // Message not meant for us
		  }
	  }

	  switch (msg.MsgType) {
		  case BaseResponse.TYPE.NOTIFICATION:
			  processNotificationResponse(msg as NotificationResponse);
			  break;
		  case BaseResponse.TYPE.DIALOG:
			  processDialogResponse(msg as DialogResponse);
			  break;
		  case BaseResponse.TYPE.SETTINGS:
			  processSettingsResponse(msg as SettingsResponse);
			  break;
		  case BaseResponse.TYPE.FLEET:
			  processFleetResponse(msg as FleetResponse);
			  break;
	  }
  } catch (Exception e) {
	  log("Exception occured: " + e, "incomming", Logger.severity.ERROR);
  }
}

private void processNotificationResponse(NotificationResponse noti) {
  log("Hit", "processNotificationResponse");
  MyAPIGateway.Utilities.ShowNotification(noti.NotificationText, noti.Time, noti.Font);
}

private void processDialogResponse(DialogResponse resp) {
  log("Hit", "processDialogResponse");
  Utility.showDialog(resp.Title, resp.Body, "Close");
}

private void processSettingsResponse(SettingsResponse resp) {
  log("Loading settings from server", "processSettingsResponse");
  m_ServerSettings = resp.Settings;

  log("Adding CP GPS", "processSettingsResponse");
  foreach (Records.ControlPoint cp in ServerSettings.ControlPoints) {
	  m_ServerCPGPS.Add(MyAPIGateway.Session.GPS.Create(
		  cp.Name,
		  "GardenConquest Control Point",
		  new VRageMath.Vector3D(cp.Position.X, cp.Position.Y, cp.Position.Z),
		  true, true
	  ));
  }

  addCPGPS();
}

private void processFleetResponse(FleetResponse resp) {
  log("Loading fleet data from server", "processFleetResponse");
  List<GridEnforcer.GridData> gridData = resp.FleetData;

  // Clear our current data to get fresh data from server
  Array.Clear(m_Counts, 0, m_Counts.Length);
  for (int i = 0; i < m_Counts.Length; ++i) {
	  m_SupportedGrids[i].Clear();
	  m_UnsupportedGrids[i].Clear();
  }

  // Saving data from server to client
  for (int i = 0; i < gridData.Count; ++i) {
	  int classID = (int)gridData[i].shipClass;
	  m_Counts[classID] += 1;
	  if (gridData[i].supported) {
		  m_SupportedGrids[classID].Add(gridData[i]);
	  }
	  else {
		  m_UnsupportedGrids[classID].Add(gridData[i]);
	  }
  }

  // Building fleet info to display in a dialog
  string fleetInfoBody = buildFleetInfoBody(resp.OwnerType);
  string fleetInfoTitle = buildFleetInfoTitle(resp.OwnerType);

  // Displaying the fleet information
  Utility.showDialog(fleetInfoTitle, fleetInfoBody, "Close");
}
*/
/*
#endregion
#region Process Response Utilities
/*
private string buildFleetInfoBody(GridOwner.OWNER_TYPE ownerType) {
	log("Building Fleet Info Body", "buildFleetInfoBody");
	string fleetInfoBody = "";
	List<GridEnforcer.GridData> gdList;
	for (int i = 0; i < m_Counts.Length; ++i) {
		if (m_Counts[i] > 0) {
			fleetInfoBody += (HullClass.CLASS)i + ": " + m_Counts[i] + " / ";
			if (ownerType == GridOwner.OWNER_TYPE.FACTION) {
				fleetInfoBody += ServerSettings.HullRules[i].MaxPerFaction + "\n";
			}
			else if (ownerType == GridOwner.OWNER_TYPE.PLAYER) {
				fleetInfoBody += ServerSettings.HullRules[i].MaxPerSoloPlayer + "\n";
			}
			else {
				fleetInfoBody += "0\n";
			}

			if (m_SupportedGrids[i].Count > 0) {
				gdList = m_SupportedGrids[i];
				for (int j = 0; j < gdList.Count; ++j) {
					fleetInfoBody += "  " + (j + 1) + ". " + gdList[j].shipName + " - " + gdList[j].blockCount + " blocks\n";
					if (gdList[j].displayPos) {
						fleetInfoBody += "      GPS: " + gdList[j].shipPosition.X + ", " + gdList[j].shipPosition.Y + ", " + gdList[j].shipPosition.Z + "\n";
					}
					else {
						fleetInfoBody += "      GPS: Unavailable - Must own the Main Cockpit\n";
					}
				}
			}
			if (m_UnsupportedGrids[i].Count > 0) {
				gdList = m_UnsupportedGrids[i];
				int offset = m_SupportedGrids[i].Count;
				fleetInfoBody += "\n  Unsupported:\n";
				for (int j = 0; j < gdList.Count; ++j) {
					//Some code logic to continue the numbering of entries where m_SupportedGrid leaves off
					fleetInfoBody += "     " + (j + offset + 1) + ". " + gdList[j].shipName + " - " + gdList[j].blockCount + " blocks\n";
					if (gdList[j].displayPos) {
						fleetInfoBody += "         GPS: " + gdList[j].shipPosition.X + ", " + gdList[j].shipPosition.Y + ", " + gdList[j].shipPosition.Z + "\n";
					}
					else {
						fleetInfoBody += "         GPS: Unavailable - Must own the Main Cockpit\n";
					}
				}
			}

			fleetInfoBody += "\n";
		}
	}
	return fleetInfoBody;
}
private string buildFleetInfoTitle(GridOwner.OWNER_TYPE ownerType) {
	string fleetInfoTitle = "";
	switch (ownerType) {
		case GridOwner.OWNER_TYPE.FACTION:
			fleetInfoTitle = "Your Faction's Fleet:";
			break;
		case GridOwner.OWNER_TYPE.PLAYER:
			fleetInfoTitle = "Your Fleet:";
			break;
	}
	return fleetInfoTitle;
}

public void addCPGPS() {
	foreach (IMyGps gps in m_ServerCPGPS) {
		MyAPIGateway.Session.GPS.AddLocalGps(gps);
	}

	m_ServerCPGPSAdded = true;
}

public void removeCPGPS() {
	if (!m_ServerCPGPSAdded)
		return;

	foreach (IMyGps gps in m_ServerCPGPS) {
		MyAPIGateway.Session.GPS.RemoveLocalGps(gps.Hash);
	}

	m_ServerCPGPSAdded = false;
}

#endregion
#endregion
#endregion
   */

/*
private void processStopGridRequest(StopGridRequest req) {
   log("", "processStopGridRequest");
   IMyCubeGrid gridToStop = MyAPIGateway.Entities.GetEntityById(req.EntityID) as IMyCubeGrid;

   // @TODO: make it easy to find enforcers by entityId so we can provide
   // greater accuracy to our canInteractWith check
   //GridEnforcer enforcer = StateTracker.getInstance().

   // Can the player interact with this grid? If they can, stop the ship by enabling dampeners, turning off
   // space balls and artificial masses, and disable thruster override
   if (gridToStop.canInteractWith(req.ReturnAddress)) {

	   // Get all thrusters, spaceballs, artificial masses, and cockpits
	   List<IMySlimBlock> fatBlocks = new List<IMySlimBlock>();
	   Func<IMySlimBlock, bool> selectBlocks = b =>
		   b.FatBlock != null && (b.FatBlock is IMyThrust || b.FatBlock is SE_Ingame.IMySpaceBall || b.FatBlock is SE_Ingame.IMyVirtualMass || b.FatBlock is InGame.IMyShipController);
	   gridToStop.GetBlocks(fatBlocks, selectBlocks);

	   foreach (IMySlimBlock block in fatBlocks) {
		   // Thruster
		   if (block.FatBlock is IMyThrust) {
			   TerminalPropertyExtensions.SetValueFloat(block.FatBlock as IMyTerminalBlock, "Override", 0);
		   }
		   // Spaceball
		   else if (block.FatBlock is SE_Ingame.IMySpaceBall) {
			   (block.FatBlock as InGame.IMyFunctionalBlock).RequestEnable(false);
		   }
		   // Artificial Mass
		   else if (block.FatBlock is SE_Ingame.IMyVirtualMass) {
			   (block.FatBlock as InGame.IMyFunctionalBlock).RequestEnable(false);
		   }
		   // Cockpit
		   else if (block.FatBlock is InGame.IMyShipController) {
			   TerminalPropertyExtensions.SetValueBool(block.FatBlock as InGame.IMyShipController, "DampenersOverride", true);
		   }
	   }
	   gridToStop.Physics.ClearSpeed();
   }
   // Player can't interact with grid, send error message
   else {
	   GridOwner.OWNER owner = GridOwner.ownerFromPlayerID(req.ReturnAddress);
	   string errorMessage = "";

	   // Build text based on whether or not player is in faction
	   switch (owner.OwnerType) {
		   case GridOwner.OWNER_TYPE.FACTION:
			   errorMessage = "Your faction does not have control of that ship's Main Cockpit!";
			   break;
		   case GridOwner.OWNER_TYPE.PLAYER:
			   errorMessage = "You do not have control of that ship's Main Cockpit!";
			   break;
	   }

	   NotificationResponse noti = new NotificationResponse() {
		   NotificationText = errorMessage,
		   Time = Constants.NotificationMillis,
		   Font = MyFontEnum.Red,
		   Destination = new List<long>() { req.ReturnAddress },
		   DestType = BaseResponse.DEST_TYPE.PLAYER
	   };

	   send(noti);
   }
}

private void processViolationsRequest(ViolationsRequest req) {
   // Get an Owner object from the player ID of the request
   GridOwner.OWNER owner = GridOwner.ownerFromPlayerID(req.ReturnAddress);

   // Retrieve that owner's fleet
   FactionFleet fleet = GardenConquest.Core.StateTracker.
	   getInstance().getFleet(owner.FleetID, owner.OwnerType);

   // Get the fleet's juicy description
   String body = fleet.violationsToString();

   // build the title
   String title = "";
   switch (owner.OwnerType) {
	   case GridOwner.OWNER_TYPE.FACTION:
		   title = "Your Faction's Fleet's Violations";
		   break;
	   case GridOwner.OWNER_TYPE.PLAYER:
		   title = "Your Fleet Violations";
		   break;
   }

   // send the response
   DialogResponse resp = new DialogResponse() {
	   Body = body,
	   Title = title,
	   Destination = new List<long>() { req.ReturnAddress },
	   DestType = BaseResponse.DEST_TYPE.PLAYER
   };

   send(resp);
}

private void processDisownRequest(DisownRequest req) {
   IMyCubeGrid gridToDisown = MyAPIGateway.Entities.GetEntityById(req.EntityID) as IMyCubeGrid;

   List<IMySlimBlock> allBlocks = new List<IMySlimBlock>();

   // Get only FatBlocks from the blocks list from the grid
   Func<IMySlimBlock, bool> isFatBlock = b => b.FatBlock != null;
   gridToDisown.GetBlocks(allBlocks, isFatBlock);

   foreach (IMySlimBlock block in allBlocks) {
	   if (block.FatBlock.OwnerId == req.ReturnAddress)  {
			   // Code to disown blocks goes here
		   // Disabled because current Space Engineer's Mod API does not have the capability to disown individual blocks
		   //fatBlock.ChangeOwner(0, 0);
	   }
   }
}
*/

#endregion
