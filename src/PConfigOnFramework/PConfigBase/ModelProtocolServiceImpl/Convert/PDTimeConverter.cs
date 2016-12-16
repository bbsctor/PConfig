using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using ConfigFrame.Protocol;
using ConfigFrame.Protocol.Complex;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.ProtocolImpl;
using PConfigProtocol.FrameDef.Clock;

namespace PConfigBase.ModelProtocolServiceImpl.Convert
{
    public class PDTimeConverter:IProtocolDModelConverter
    {
        public static TimeDataModel parseTimeData(IComplexResponse resp)
        {
            TimeDataModel model = new TimeDataModel();
            byte[] temp;

            temp = Response_74Frame.year.Data;
            System.Array.Reverse(temp, 0, 2);
            model.year = BitConverter.ToUInt16(temp, 0);

            temp = Response_74Frame.month.Data;
            model.month = temp[0];

            temp = Response_74Frame.day.Data;
            model.day = temp[0];

            temp = Response_74Frame.hour.Data;
            model.hour = temp[0];

            temp = Response_74Frame.minute.Data;
            model.minute = temp[0];

            temp = Response_74Frame.second.Data;
            model.second = temp[0];

            return model;
        }

        public static IRequest genSettingTime(TimeDataModel time)
        {
            Request req = new Request();

            byte[] temp = BitConverter.GetBytes(time.year);
            System.Array.Reverse(temp, 0, 2);

            Request_54Frame rf = new Request_54Frame(temp, time.month, time.day, time.hour, time.minute, time.second);
            req.requestFrame = rf;
            return req;
        }
    }
}
