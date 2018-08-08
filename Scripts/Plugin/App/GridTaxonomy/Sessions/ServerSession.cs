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
using VRage.Library.Collections;
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

using SEPC.Components;
using SEPC.Components.Attributes;
using SEPC.Extensions;
using SEPC.Logging;
using SEPC.Network.Messaging;

using GC.App.GridTaxonomy.Messages;

namespace GC.App.GridTaxonomy.Sessions
{
	[IsSessionComponent(RunLocation.Server, groupId: (int)Session.Groups.Sessions, order: RegistrationOrder)]
	public class ServerSession
	{
		public const int RegistrationOrder = 0;

		Logable Log = new Logable("GC.App.GridTaxonomy.Sessions");
		Node Taxonomy;

		public ServerSession()
		{
			Log.Entered();
			//LoadSettings();
			//RegisterMessageHandlers();
		}

		[OnSessionClose]
		void Terminate()
		{
			Log.Entered();
		}

//		void RegisterMessageHandlers()
//		{
//			Log.Entered();
//			TaxonomyChangeRequest.Handle(HandleTaxonomyChangeRequest);
//			HandlerRegistrar.Register(Session.MessageDomain, (ushort)Messages.MessageType.GridTaxonomyRequest, HandleTaxonomyRequest);
//			HandlerRegistrar.Register(Session.MessageDomain, (ushort)Messages.MessageType.GridTaxonomyChangeRequest, HandleTaxonomyChangeRequest);
//		}
//
//		void HandleTaxonomyRequest(BitStream data, ulong senderId)
//		{
//			Log.Entered();
//			BitStream stream = new BitStream();
//			stream.ResetWrite();
//			Taxonomy.Serialize(stream);
//			Messenger.SendToPlayer(stream, Session.MessageDomain, (ushort)Messages.MessageType.GridTaxonomyResponse, senderId);
//		}

		void HandleTaxonomyChangeRequest(TaxonomyChangeRequest request, ulong senderId)
		{
			Log.Entered();

			Taxonomy = request.Taxonomy;
			SaveSettings();

			new TaxonomyChangeResponse() { Success = true }.Send();
		}


	}
}
*/
