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
    public class LoggerController : BasicDynamicController
    {
        public override void handleResult(IMetaModel mModel)
        {
            LoggerMetaModel lModel = mModel as LoggerMetaModel;
            if (lModel != null)
            {
                switch (lModel.type)
                {
                    case LoggerMetaModel.TYPE.CONNECTOUT:
                        ((LoggerDataModel)model).connectOut = (uint)lModel.Data;
                        break;
                    case LoggerMetaModel.TYPE.DAILINTIME:
                        ((LoggerDataModel)model).dialInTime = (uint)lModel.Data;
                        break;
                    case LoggerMetaModel.TYPE.DESTURL:
                        ((LoggerDataModel)model).destURL.Url = (byte[])lModel.Data;
                        break;
                    case LoggerMetaModel.TYPE.LOGGERID:
                        LoggerDataModel.loggerID.LoggerID = (byte[])lModel.Data;
                        break;
                    case LoggerMetaModel.TYPE.MODEM:
                        ((LoggerDataModel)model).baudRate = (byte)((ModemDataModel)lModel.Data).baudRate;
                        ((LoggerDataModel)model).parity = (byte)((ModemDataModel)lModel.Data).parity;
                        break;
                    case LoggerMetaModel.TYPE.RESPONSEOUT:
                        ((LoggerDataModel)model).responseOut = (uint)lModel.Data;
                        break;
                    case LoggerMetaModel.TYPE.SAMPLECOUNT:
                        ((LoggerDataModel)model).sampleCount = (ushort)lModel.Data;
                        break;
                    case LoggerMetaModel.TYPE.SAMPLEORIGIN:
                        ((LoggerDataModel)model).sampleOrigin = (TimeDataModel)lModel.Data;
                        break;
                    case LoggerMetaModel.TYPE.CONNECTSTATUS:
                        ((LoggerDataModel)model).connectStatus = (byte[])lModel.Data;
                        break;
                }
            }
            
        }
    }
}
