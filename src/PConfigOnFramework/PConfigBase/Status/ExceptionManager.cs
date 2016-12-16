using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PConfigBase.Status;

namespace PConfigBase.Status
{
    public class ExceptionManager:IHandleException
    {
        public event EventHandler ExceptionOccurred;

        public void dispatchException(Exception ex)
        {
            ExceptionEventArgs info = new ExceptionEventArgs();
            info.exception = ex;
            onExceptionOccurred(info);
        }

        protected virtual void onExceptionOccurred(EventArgs e)
        {
            if (ExceptionOccurred != null)
            {
                ExceptionOccurred(this, e);
            }
        }
    }
}
