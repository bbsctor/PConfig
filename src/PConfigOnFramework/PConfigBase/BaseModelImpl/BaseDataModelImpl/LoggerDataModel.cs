using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseDataModelImpl
{
    public class LoggerDataModel : BasicModel, IDataModel
    {
        public byte baudRate;
        public uint connectOut;
        public uint dialInTime;
        public URLDataModel destURL;
        public static LoggerIDDataModel loggerID;
        public byte parity;
        public uint responseOut;
        public ushort sampleCount;
        public TimeDataModel sampleOrigin;
        public byte[] connectStatus;

        public LoggerDataModel()
        {
            destURL = new URLDataModel(); 
        }

        public virtual void update(IModel model)
        {
            update(model, new string[]{"baudRate", "connectOut", "dialInTime",
                "destURL", "loggerID", "parity", "responseOut", "sampleOrigin", "sampleCount"});
        }
    }
}
