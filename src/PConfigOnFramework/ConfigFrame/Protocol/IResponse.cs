using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigFrame.Protocol
{
    public interface IResponse
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

        IRequest Request
        {
            get;
            set;
        }
        void parse(byte[] inData);
    }
}
