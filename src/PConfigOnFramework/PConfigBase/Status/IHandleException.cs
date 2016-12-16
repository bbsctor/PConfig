using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PConfigBase.Status
{
    public interface IHandleException
    {
        event EventHandler ExceptionOccurred;
    }
}
