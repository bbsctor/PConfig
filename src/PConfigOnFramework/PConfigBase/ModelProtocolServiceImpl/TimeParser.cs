using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using ConfigFrame.BaseService;
using ConfigFrame.Protocol;
using PConfigBase.ProtocolImpl;
using PConfigBase.BaseModelImpl.BaseMetaModelImpl;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.ModelProtocolServiceImpl.Convert;

namespace PConfigBase.ModelProtocolServiceImpl
{
    public class TimeParser
    {
        public static TimeDataModel parseTimeData(byte[] data)
        {
            TimeDataModel time = new TimeDataModel();
            System.Array.Reverse(data, 0, 2);
            time.year = BitConverter.ToUInt16(data, 0);
            time.month = data[2];
            time.day = data[3];
            time.hour = data[4];
            time.minute = data[5];
            time.second = data[6];

            return time;
        }
    }
}
