using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PConfigBase.Status
{
    public interface IProcessStatus
    {
        event EventHandler ProcessChanged;
    }
}
