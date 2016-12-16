using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseDataModelImpl
{
    public class ClockDataModel :BasicModel, IDataModel
    {
        public TimeDataModel timeModel;
        public uint samplingInterval;

        public ClockDataModel()
        {
            timeModel = new TimeDataModel();
        }

        public override bool Equals(object obj)
        {
            ClockDataModel model = obj as ClockDataModel;
            if (model != null)
            {
                if (this.timeModel.Equals(model.timeModel) == false)
                {
                    return false;
                }

                if (this.samplingInterval != model.samplingInterval)
                {
                    return false;
                }

                return true;
            }
            return false;
        }
    }
}
