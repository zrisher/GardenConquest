﻿/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using VRage.Game;

using GardenConquest.Extensions;

namespace GardenConquest.Messaging {

    public class NotificationResponse : BaseResponse {
        public String NotificationText { get; set; }
        public ushort Time { get; set; }
        public MyFontEnum Font { get; set; }

        private const int BaseSize = sizeof(ushort) + sizeof(ushort);

        public NotificationResponse()
            : base(BaseResponse.TYPE.NOTIFICATION) {
        }

        public override byte[] serialize() {
            VRage.ByteStream bs = new VRage.ByteStream(BaseSize, true);

            byte[] bmessage = base.serialize();
            bs.Write(bmessage, 0, bmessage.Length);

            bs.addString(NotificationText);
            bs.addUShort(Time);
            bs.addUShort((ushort)Font);

            return bs.Data;
        }

        public override void deserialize(VRage.ByteStream stream) {
            base.deserialize(stream);

            NotificationText = stream.getString();
            Time = stream.getUShort();
            Font = (MyFontEnum)stream.getUShort();
        }
    }
}
*/