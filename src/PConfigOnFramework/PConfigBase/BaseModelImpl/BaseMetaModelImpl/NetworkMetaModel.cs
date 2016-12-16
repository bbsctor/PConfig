using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseMetaModelImpl
{
    public class NetworkMetaModel : MetaModel
    {
        public enum TYPE {USERNAME, PASSWORD, DIALINENABLE, DIALINENABLE_RESP, DIALINDISABLE, DIALINDISABLE_RESP,
            INIT, INIT_RESP, CONNECT, CONNECT_RESP, DISCONNECT, DISCONNECT_RESP};
        public TYPE type;
    }
}
