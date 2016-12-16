using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseViewModelImpl
{
    public class ProbeInfoViewModel : BasicModel, IViewModel
    {
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string serialNumber;

        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }
        private ushort addr;

        public ushort Addr
        {
            get { return addr; }
            set { addr = value; }
        }
        private string version;

        public string Version
        {
            get { return version; }
            set { version = value; }
        }
    }
}
