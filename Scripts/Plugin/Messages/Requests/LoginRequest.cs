/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sandbox.ModAPI;
using VRage;

using SEGarden.Extensions;

namespace GC.Messages.Requests {

    class LoginRequest : RequestBase {

        //public static readonly int SIZE = sizeof(long) * 2 + RequestBase.SIZE;

        public LoginRequest() : base((ushort)MessageType.LoginRequest) {

        }

        public LoginRequest(ref ByteStream stream) : 
            base((ushort)MessageType.LoginRequest) 
        {

        }

        protected override byte[] ToBytes() {
            ByteStream stream = new ByteStream(SIZE);
            return stream.Data;
        }

    }
}
*/
