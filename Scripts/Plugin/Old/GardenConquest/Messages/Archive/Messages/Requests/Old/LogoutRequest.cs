/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SEGarden.Extensions;

namespace GP.Concealment.Messages.Requests {
    class LogoutRequest : Request {

        public static readonly int SIZE = sizeof(long) + Request.SIZE;

        public LogoutRequest(byte[] bytes) :
            base((ushort)MessageType.LogoutRequest) 
        {
            VRage.ByteStream stream = new VRage.ByteStream(bytes, bytes.Length);
            PlayerId = stream.getLong();
            FactionId = stream.getLong();
        }

        public LogoutRequest(long playerId, long factionId)
            : base((ushort)MessageType.LogoutRequest) 
        {
            PlayerId = playerId;
            FactionId = factionId;
        }

        public long PlayerId;
        public long FactionId;

        protected override byte[] ToBytes() {
            VRage.ByteStream stream = new VRage.ByteStream(SIZE);
            stream.addLong(PlayerId);
            stream.addLong(FactionId);
            return stream.Data;
        }


    }
}
*/
