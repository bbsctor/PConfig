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
    public class PowerController : BasicDynamicController
    {
        public override void handleResult(IMetaModel mModel)
        {
            PowerMetaModel lModel = mModel as PowerMetaModel;
            if (lModel != null)
            {
                switch (lModel.type)
                {
                    case PowerMetaModel.TYPE.OBSERVE:
                        ((PowerDataModel)model).supply = ((List<float>)(lModel.Data))[0];
                        ((PowerDataModel)model).battery = ((List<float>)(lModel.Data))[1];
                        ((PowerDataModel)model).solar = ((List<float>)(lModel.Data))[2];
                        break;
                    case PowerMetaModel.TYPE.ENABLEPROBE:
                        ((PowerDataModel)model).enableProbe = ((List<float>)(lModel.Data))[0];
                        ((PowerDataModel)model).enableProbe_low = ((List<float>)(lModel.Data))[1];
                        ((PowerDataModel)model).enableProbe_high = ((List<float>)(lModel.Data))[2];
                        break;
                    case PowerMetaModel.TYPE.DISABLETELECOM:
                        ((PowerDataModel)model).disableTelecom = ((List<float>)(lModel.Data))[0];
                        ((PowerDataModel)model).disableTelecom_low = ((List<float>)(lModel.Data))[1];
                        ((PowerDataModel)model).disableTelecom_high = ((List<float>)(lModel.Data))[2];
                        break;
                    case PowerMetaModel.TYPE.DISABLEPROBE:
                        ((PowerDataModel)model).disableProbe = ((List<float>)(lModel.Data))[0];
                        ((PowerDataModel)model).disableProbe_low = ((List<float>)(lModel.Data))[1];
                        ((PowerDataModel)model).disableProbe_high = ((List<float>)(lModel.Data))[2];
                        break;
                }
            }  
        }
    }
}
