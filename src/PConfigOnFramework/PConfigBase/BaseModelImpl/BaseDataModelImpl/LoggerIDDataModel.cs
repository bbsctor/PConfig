using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PConfigBase.BaseModelImpl.BaseDataModelImpl
{
    public class LoggerIDDataModel
    {
        private byte[] loggerID;
        public byte[] LoggerID
        {
            get { return loggerID; }
            set { this.loggerID = value; }
        }
    }
}
