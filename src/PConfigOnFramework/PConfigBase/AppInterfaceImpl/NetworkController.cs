using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.AppInterface;
using ConfigFrame.Protocol;
using ConfigFrame.BaseModel;
using ConfigFrame.CommunicationService;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.ModelProtocolServiceImpl;
using PConfigBase.BaseModelImpl.BaseMetaModelImpl;

namespace PConfigBase.AppInterfaceImpl
{
    public class NetworkController : BasicDynamicController
    {

        public override void handleResult(IMetaModel mModel)
        {
            NetworkMetaModel lModel = mModel as NetworkMetaModel;
            if (lModel != null)
            {
                switch (lModel.type)
                {
                    case NetworkMetaModel.TYPE.USERNAME:
                        ((NetworkDataModel)model).userName = (byte[])lModel.Data;
                        break;
                    case NetworkMetaModel.TYPE.PASSWORD:
                        ((NetworkDataModel)model).password = (byte[])lModel.Data;
                        break;
                    case NetworkMetaModel.TYPE.DIALINENABLE:
                        ((NetworkDataModel)model).dialInEnable = ((List<byte[]>)lModel.Data)[0];
                        ((NetworkDataModel)model).dialInEnableResp = ((List<byte[]>)lModel.Data)[1];
                        break;
                    case NetworkMetaModel.TYPE.DIALINDISABLE:
                        ((NetworkDataModel)model).dialInDisable = ((List<byte[]>)lModel.Data)[0];
                        ((NetworkDataModel)model).dialInDisableResp = ((List<byte[]>)lModel.Data)[1];
                        break;
                    case NetworkMetaModel.TYPE.INIT:
                        ((NetworkDataModel)model).init = ((List<byte[]>)lModel.Data)[0];
                        ((NetworkDataModel)model).initResp = ((List<byte[]>)lModel.Data)[1];
                        break;
                    case NetworkMetaModel.TYPE.CONNECT:
                        ((NetworkDataModel)model).connect = ((List<byte[]>)lModel.Data)[0];
                        ((NetworkDataModel)model).connectResp = ((List<byte[]>)lModel.Data)[1];
                        break;
                    case NetworkMetaModel.TYPE.DISCONNECT:
                        ((NetworkDataModel)model).disconnect = ((List<byte[]>)lModel.Data)[0];
                        ((NetworkDataModel)model).disconnectResp = ((List<byte[]>)lModel.Data)[1];
                        break;
                }
            }   
        }
    }
}
