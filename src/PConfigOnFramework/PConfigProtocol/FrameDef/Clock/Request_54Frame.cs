using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PConfigProtocol.FrameDef;
using ProtocolFrame.ElementDef.BasicImpl;

namespace PConfigProtocol.FrameDef.Clock
{
    public class Request_54Frame : CommonRequestFrame
    {
        public static BasicElement year;
        public static BasicElement month;
        public static BasicElement day;
        public static BasicElement hour;
        public static BasicElement minute;
        public static BasicElement second;

        static Request_54Frame()
        {
            year = new BasicElement();
            year.Size = 2;
            month = new BasicElement();
            month.Size = 1;
            day = new BasicElement();
            day.Size = 1;
            hour = new BasicElement();
            hour.Size = 1;
            minute = new BasicElement();
            minute.Size = 1;
            second = new BasicElement();
            second.Size = 1;
        }

        public Request_54Frame(byte[] year, byte month, byte day, byte hour, byte minute, byte second)
        {
            Request_54Frame.year.Data = year;
            Request_54Frame.month.Data = new byte[]{month};
            Request_54Frame.day.Data = new byte[]{day};
            Request_54Frame.hour.Data = new byte[]{hour};
            Request_54Frame.minute.Data = new byte[]{minute};
            Request_54Frame.second.Data = new byte[] { second };

            Request_54Frame.data.RelateElements = new BasicElement[]{
                Request_54Frame.year,
                Request_54Frame.month,
                Request_54Frame.day,
                Request_54Frame.hour,
                Request_54Frame.minute,
                Request_54Frame.second
            };

            Request_54Frame.data.build();
            preBuild(0x54, Request_54Frame.data.Data);
            build();
        }

    }
}
