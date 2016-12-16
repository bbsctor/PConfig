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
    public class ModemController : BasicDynamicController
    {
        public override void execute(string action)
        {
            ModemDataModel mModel = (ModemDataModel)model;
            if (action.Equals("openSession"))
            {
                ((ModemService)dService).idleMode = ModemService.IdleMode.SESSION;
                server.SwitchInterval = 1000;
            }
            else if (action.Equals("closeSession"))
            {
                base.execute("closeSession");
                ((ModemService)dService).idleMode = ModemService.IdleMode.COMMON;
                server.SwitchInterval = 3000;
                ((ModemDataModel)model).clear();
            }
            else if (action.Equals("test"))
            {
                ((ModemService)dService).idleMode = ModemService.IdleMode.TEST;
                server.SwitchInterval = 1000;
            }
            else if (action.Equals("upload"))
            {
                ((ModemService)dService).idleMode = ModemService.IdleMode.UPLOAD;
                server.SwitchInterval = 1000;
            }
            else if (action.Equals("closeTest"))
            {
                ((ModemService)dService).idleMode = ModemService.IdleMode.COMMON;
                server.SwitchInterval = 3000;
            }
            else
            {
                base.execute(action);
            }
        }

        public override void handleResult(IMetaModel mModel)
        {
            ModemMetaModel cModel = mModel as ModemMetaModel;
            if (cModel != null)
            {
                switch (cModel.type)
                {
                    case ModemMetaModel.TYPE.OPENSESSION:
                        ((ModemDataModel)model).sessionRecv = (byte[])cModel.Data;
                        break;
                    case ModemMetaModel.TYPE.SENDAT:
                        ((ModemDataModel)model).sessionRecv = (byte[])cModel.Data;
                        break;
                    case ModemMetaModel.TYPE.TEST:
                        ((ModemDataModel)model).status = (byte[])cModel.Data;
                        break;
                    case ModemMetaModel.TYPE.UPLOAD:
                        ((ModemDataModel)model).status = (byte[])cModel.Data;
                        break;
                }
            }
        }
    }
}
