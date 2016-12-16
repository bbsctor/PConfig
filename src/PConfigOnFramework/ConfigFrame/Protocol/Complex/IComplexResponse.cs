using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigFrame.Protocol.Complex
{
    public interface IComplexResponse:IResponse
    {
        bool IsNull
        {
            get;
            set;
        }

        Dictionary<string, byte[]> ParaMap
        {
            get;
            set;
        }

        void parseData();
        void addPara(string name, byte[] value);
        byte[] getPara(string name);
    }
}
