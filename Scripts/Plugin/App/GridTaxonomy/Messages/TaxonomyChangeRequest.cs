using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SEPC.Network.Messaging;

using VRage.Library.Collections;

/*
namespace GC.App.GridTaxonomy.Messages
{
	public class TaxonomyChangeRequest : Request
	{
		const GC.Messages.MessageType _MessageType = GC.Messages.MessageType.GridTaxonomyChangeRequest;

		public static void Handle(Action<TaxonomyChangeRequest, ulong> handler)
		{
			Handle(_MessageType, handler);
		}

		public override GC.Messages.MessageType MessageType { get { return _MessageType; } }
		public override bool RequiresAdmin { get { return true; } }

		public Node Taxonomy;

		public override void Serialize(BitStream stream)
		{
			base.Serialize(stream);

			if (stream.Reading)
				Taxonomy = new Node();

			Taxonomy.Serialize(stream);
		}
	}
}
*/