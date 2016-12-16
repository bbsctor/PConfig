using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PConfigBase.Status;

namespace PConfigBase.Status
{
    public class StatusManager:IProcessStatus
    {
        public event EventHandler ProcessChanged;

        public void changeProcess(string message)
        {
            ProcessEventArgs info = new ProcessEventArgs();
            info.message = message;
            onProcessChanged(info);
        }

        protected virtual void onProcessChanged(EventArgs e)
        {
            if (ProcessChanged != null)
            {
                ProcessChanged(this, e);
            }
        }
    }
}
