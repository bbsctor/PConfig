using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PConfigBase.BaseModelImpl.BaseViewModelImpl
{
    public class TimeViewModel
    {
        private DateTime viewDateTime;

        public DateTime ViewDateTime
        {
            get { return viewDateTime; }
            set { viewDateTime = value; }
        }
    }
}
