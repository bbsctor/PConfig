using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PConfigProtocol.FrameDef;
using ProtocolFrame.ElementDef.BasicImpl;

namespace PConfigProtocol.FrameDef.Clock
{
    public class Response_74Frame : CommonResponseFrame
    {
        public static BasicElement year;
        public static BasicElement month;
        public static BasicElement day;
        public static BasicElement hour;
        public static BasicElement minute;
        public static BasicElement second;

        static Response_74Frame()
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

        public Response_74Frame()
        {
            CommonResponseFrame.data.RelateElements = new BasicElement[]{
                Response_74Frame.year,
                Response_74Frame.month,
                Response_74Frame.day,
                Response_74Frame.hour,
                Response_74Frame.minute,
                Response_74Frame.second
            };
        }
    }
}
