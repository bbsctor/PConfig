using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseViewModelImpl
{
    public class ModemViewModel :BasicModel, IViewModel
    {
        private string sessionRecv;

        public string SessionRecv
        {
            get { return sessionRecv; }
            set { sessionRecv = value; }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
