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
    public class SerialController : BasicStaticController
    {
        public override void execute(string action)
        {
            IResponse[] resp = null;
            resetDataModel();
            if ("connect".Equals(action))
            {
                openPort();
                IRequest[] reqs = dService.genRequestByActionName(action, model);
                resp = cService.processRequestBatch(reqs);
            }
            else if ("disconnect".Equals(action))
            {
                
                IRequest[] reqs = dService.genRequestByActionName(action, model);
                resp = cService.processRequestBatch(reqs);
                disconnect();
            }
            else if ("closePort".Equals(action))
            {
                disconnect();
            }

            if (resp != null && resp.Length > 0)
            {
                for (int i = 0; i < resp.Length; i++)
                {
                    IMetaModel model = this.ModelProtocolService.handleResponse(resp[i]);
                    this.handleResult(model);
                }
            }
        }
        private void openPort()
        {
            //resetDataModel();
            ConnectDataModel dModel = (ConnectDataModel)model;
            SerialPortModel sModel = new SerialPortModel();
            sModel.port = dModel.port;
            sModel.baudRate = dModel.baudRate;
            cService.connect(sModel);
        }

        private void disconnect()
        {
            cService.disconnect();
        }
        public override void handleResult(IMetaModel mModel)
        {
            ((ConnectDataModel)model).isConnected = (bool)((MetaModel)mModel).Data;
        }
    }
}
