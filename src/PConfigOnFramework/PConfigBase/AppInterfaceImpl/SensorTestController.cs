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
    public class SensorTestController : BasicDynamicController
    {
        public override void execute(string action)
        {
            if ("stop".Equals(action))
            {
                server.BusyInterval = 0;
                server.SwitchInterval = 3000;
                ((SensorTestService)dService).idleMode = SensorTestService.IdleMode.COMMON;
            }
            else if ("queryAll".Equals(action))
            {
                base.execute(action);
                server.SwitchInterval = 0;
                server.IdleInterval = 200;
                ((SensorTestService)dService).idleMode = SensorTestService.IdleMode.ALL;
            }
            else if (action.Contains("queryRTSelected"))
            {
                base.execute(action);
                server.SwitchInterval = 0;
                server.IdleInterval = 200;
                ((SensorTestService)dService).idleMode = SensorTestService.IdleMode.SELECTED;
            }
            else
            {
                base.execute(action);
            }
        }

        public override void handleResult(IMetaModel mModel)
        {
            if (mModel != MetaModel.NULL)
            {
                TestMetaModel tModel = mModel as TestMetaModel;
                if (tModel != null)
                {
                    
                    switch (tModel.type)
                    {
                        case TestMetaModel.TYPE.RAW:
                            SensorListDataModel modelList = (SensorListDataModel)tModel.Data;
                            ((SensorListDataModel)model).cleanRowCount();
                            for (int i = 0; i < modelList.Count; i++)
                            {
                                ((SensorListDataModel)model).update(modelList[i], new string[] { "rawCount" });
                            }
                            break;
                        case TestMetaModel.TYPE.CELIBRATE:
                            modelList = (SensorListDataModel)tModel.Data;
                            ((SensorListDataModel)model).cleanCelibrate();
                            for (int i = 0; i < modelList.Count; i++)
                            {
                                ((SensorListDataModel)model).update(modelList[i], new string[] { "celibrateValue" });
                            }
                            break;
                    }
                }
            }   
        }
    }
}
