/*
using VRage.Library.Collections;

using SEPC.Components;
using SEPC.Components.Attributes;
using SEPC.Logging;
using SEPC.Network.Messaging;

using GC.App.GridTaxonomy.Messages;


namespace GC.App.GridTaxonomy.Sessions
{
	[IsSessionComponent(RunLocation.Client, groupId: (int)Session.Groups.Sessions, order: RegistrationOrder)]
	public class ClientSession
	{
		const int RegistrationOrder = ServerSession.RegistrationOrder + 1;

		static readonly Logable Log = new Logable("GC.App.GridTaxonomy.Sessions");

		public static ClientSession Static;

		public Node Taxonomy { get; private set; }

		public ClientSession()
		{
			Log.Entered();
			RegisterMessageHandlers();
			SendSettingsRequest();
			Static = this;
		}

		[OnSessionClose]
		void Terminate()
		{
			Log.Entered();
			Static = null;
		}

		//void RegisterMessageHandlers()
		//{
		//	Log.Entered();
		//	HandlerRegistrar.Register(Session.MessageDomain, (ushort)Messages.MessageType.GridTaxonomyRequest, HandleTaxonomyResponse);
		//}

		void SendSettingsRequest()
		{
			Log.Entered();
			Messenger.SendToServer(new BitStream(), Session.MessageDomain, (ushort)Messages.MessageType.GridTaxonomyRequest);
		}

		void SendTaxonomyChangeRequest(Node changed)
		{
			new TaxonomyChangeRequest() { Taxonomy = changed }.Send();
		}

		void HandleTaxonomyResponse(BitStream data, ulong senderId)
		{
			Log.Entered();

			Taxonomy = new Node();
			Taxonomy.Serialize(data);
		}
	}
}
*/