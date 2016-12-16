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
    public class ProbeInfoController : BasicDynamicController
    {
        public override void handleResult(IMetaModel mModel)
        {
            ProbeInfoMetaModel cModel = mModel as ProbeInfoMetaModel;
            if (cModel != null)
            {
                switch (cModel.type)
                {
                    case ProbeInfoMetaModel.TYPE.PROBEINFO:
                        ((ProbeInfoDataModel)model).type = ((ProbeInfoDataModel)(cModel.Data)).type;
                        ((ProbeInfoDataModel)model).serialNumber = ((ProbeInfoDataModel)(cModel.Data)).serialNumber;
                        ((ProbeInfoDataModel)model).addr = ((ProbeInfoDataModel)(cModel.Data)).addr;
                        ((ProbeInfoDataModel)model).bigVersion = ((ProbeInfoDataModel)(cModel.Data)).bigVersion;
                        ((ProbeInfoDataModel)model).middleVersion = ((ProbeInfoDataModel)(cModel.Data)).middleVersion;
                        ((ProbeInfoDataModel)model).littleVersion = ((ProbeInfoDataModel)(cModel.Data)).littleVersion;
                        break;
                }
            }
        }
    }
}
