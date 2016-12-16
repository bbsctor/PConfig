using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigFrame.Protocol.Complex
{
    public interface IComplexRequest:IRequest
    {
        Type ResponseType
        {
            get;
            set;
        }
        Dictionary<string, byte[]> ParaMap
        {
            get;
            set;
        }

        
        byte[] getPara(string name);
    }
}
