using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigFrame.BaseModel
{
    public class SerialPortModel : BasicModel, IDataModel
    {
        public string baudRate;
        public string port;
        public bool isConnected;
    }
}
