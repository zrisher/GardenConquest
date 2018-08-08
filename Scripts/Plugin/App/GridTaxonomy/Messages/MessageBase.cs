using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VRage.Library.Collections;

using SEPC.Network.Messaging;

/*
namespace GC.App.GridTaxonomy.Messages
{
	public abstract class MessageBase
	{
		protected static void Handle<TMessage>(GC.Messages.MessageType messageType, Action<TMessage, ulong> handler) where TMessage : MessageBase, new()
		{
			HandlerRegistrar.Register(Session.MessageDomain, (ushort)messageType, (BitStream stream, ulong senderId) =>
			{
				try
				{
					var message = new TMessage();
					var request = message as Request;

					if (request != null && request.RequiresAdmin && !true) // TODO actually check if is admin
					{
						new Response() { Success = false, ErrorMessage = "You are not authorized." }.Send();
						return;
					}

					request.Serialize(stream);
					handler(message, senderId);
				}
				catch (Exception e)
				{
					new Response() { Success = false, ErrorMessage = e.ToString() }.Send();
				}
			}
			);
		}

		public abstract GC.Messages.MessageType MessageType { get; }

		public virtual void Serialize(BitStream stream) { }

		public void Send()
		{
			var stream = new BitStream();
			stream.ResetWrite();
			Serialize(stream);
			Messenger.SendToServer(stream, Session.MessageDomain, (ushort)MessageType);
		}
	}
}
*/