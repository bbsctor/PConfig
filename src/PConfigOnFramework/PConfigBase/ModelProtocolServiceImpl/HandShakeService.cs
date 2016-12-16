using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using ConfigFrame.BaseService;
using ConfigFrame.Protocol;
using PConfigBase.ProtocolImpl;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.BaseMetaModelImpl;

namespace PConfigBase.ModelProtocolServiceImpl
{
    public class HandShakeService : BasicService
    {
        public override IRequest[] genRequestByActionName(string action, IDataModel dModel)
        {
            ConnectDataModel model = dModel as ConnectDataModel;
            string baudRate = model.baudRate;
            switch (action)
            {
                case "connect":
                    switch (baudRate)
                    {
                        case "1200":
                            Request.Request_Leader_Number = 3;
                            break;
                        case "2400":
                            Request.Request_Leader_Number = 4;
                            break;
                        case "9600":
                            Request.Request_Leader_Number = 10;
                            break;
                        case "19200":
                            Request.Request_Leader_Number = 19;
                            break;
                        case "38400":
                            Request.Request_Leader_Number = 36;
                            break;
                    }
                    return genConnectHandShake();
                case "disconnect":
                    return genDisconnectHandShake();
            }
            return null;
        }

        public IRequest[] genConnectHandShake()
        {
            return new RequestWrapper(new Request(0x65, null)).getRequestArray();
        }

        public IRequest[] genDisconnectHandShake()
        {
            return new RequestWrapper(new Request(0x64, new byte[]{0x69, 0x73})).getRequestArray();
        }

        public override IMetaModel handleResponse(IResponse resp)
        {
            MetaModel model = new MetaModel();
            switch (((Request)(resp.Request)).func)
            {
                case 0x65:
                    model.Data = true;
                    break;
                case 0x64:
                    model.Data = false;
                    break;
            }
            return model;
        }
    }
}
