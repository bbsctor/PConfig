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
using PConfigBase.ProtocolImpl;

namespace PConfigBase.AppInterfaceImpl
{
    public class ClockController : BasicDynamicController
    {
        public bool ignoreResult;
        public override void execute(string action)
        {
            if ("queryLocalTime".Equals(action))
            {
                ClockMetaModel mModel = new ClockMetaModel();
                mModel.type = ClockMetaModel.TYPE.DATETIME;
                DateTime now = DateTime.Now;
                TimeDataModel time = new TimeDataModel((ushort)now.Year, (byte)now.Month,
                    (byte)now.Day, (byte)now.Hour, (byte)now.Minute, (byte)now.Second);
                mModel.Data = time;
                handleResult(mModel);
            }
            else if ("ignoreResult".Equals(action))
            {
                ignoreResult = true;
            }
            else
            {
                base.execute(action);
                if (action.Equals("bindingServer"))
                {
                    server.SwitchInterval = 1000;
                }
                else if (action.Equals("write"))
                {
                    ignoreResult = false;
                }
            }
        }

        public override void handleResult(IMetaModel mModel)
        {
            if (ignoreResult == false)
            {
                ClockMetaModel cModel = mModel as ClockMetaModel;
                if (cModel != null)
                {
                    switch (cModel.type)
                    {
                        case ClockMetaModel.TYPE.SAMPLINGINTERVAL:
                            ((ClockDataModel)model).samplingInterval = (uint)cModel.Data;
                            break;
                        case ClockMetaModel.TYPE.DATETIME:
                            ((ClockDataModel)model).timeModel.updateModel((TimeDataModel)(cModel.Data));
                            break;
                    }
                }
            }
        }
    }
}
