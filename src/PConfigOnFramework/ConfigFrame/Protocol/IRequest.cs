using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigFrame.Protocol
{
    public interface IRequest
    {
        byte[] Data
        {
            get;
            set;
        }
        bool IsNull
        {
            get;
            set;
        }
        IResponse genResponse();
        byte[] genBytes();
    }
}
