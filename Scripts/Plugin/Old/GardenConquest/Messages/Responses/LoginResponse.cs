/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VRage;

using SEGarden.Extensions;
using SEGarden.Versioning;

using GC.Definitions;

namespace GC.Messages.Responses {

    class LoginResponse : ResponseBase {

        // TODO: Provide size info from members
        //override int SIZE = sizeof(;

        public SettingsDefinition ServerSettings { get; private set; }
        public AppVersion ServerVersion { get; private set; }

        public LoginResponse(SettingsDefinition settings, AppVersion version) : 
            base((ushort)MessageType.LoginResponse) 
        {
            if (settings == null) throw new ArgumentException("settings null");
            if (version == null) throw new ArgumentException("version null");
            ServerSettings = settings;
            ServerVersion = version;
        }

        public LoginResponse(ref VRage.ByteStream stream) :
            base((ushort)MessageType.LoginResponse) 
        {
            if (stream == null) throw new ArgumentException("stream null");
            ServerSettings = new SettingsDefinition(stream);
            ServerVersion = new AppVersion(stream);
        }

        protected override byte[] ToBytes() {
            VRage.ByteStream stream = new VRage.ByteStream(SIZE);
            ServerSettings.AddToByteSteam(stream);
            ServerVersion.AddToByteSteam(stream);
            return stream.Data;
        }

    }

}
*/
