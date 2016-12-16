using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseViewModelImpl
{
    public class SerialViewModel : BasicModel, IViewModel
    {
        string port;

        public string Port
        {
            get { return port; }
            set { port = value; }
        }
        int baudRate;

        public int BaudRate
        {
            get { return baudRate; }
            set { baudRate = value; }
        }

        string loggerID;

        public string LoggerID
        {
            get { return loggerID; }
            set { loggerID = value; }
        }

        bool isConnected;

        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }
    }
}
