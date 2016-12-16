using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseDataModelImpl
{
    public class ConnectDataModel : BasicModel, IDataModel
    {
        public string baudRate;
        public static LoggerIDDataModel loggerID;
        public string port;
        public bool isConnected;

        public override bool Equals(object obj)
        {
            ConnectDataModel model = obj as ConnectDataModel;
            if (model != null)
            {
                if (this.baudRate != model.baudRate)
                {
                    return false;
                }
                if (this.port != model.port)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
