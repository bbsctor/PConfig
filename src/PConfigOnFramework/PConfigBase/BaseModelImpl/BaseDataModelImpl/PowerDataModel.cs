using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseDataModelImpl
{
    public class PowerDataModel : BasicModel, IDataModel
    {
        public float enableProbe;
        public float enableProbe_low;
        public float enableProbe_high;
        public float disableProbe;
        public float disableProbe_low;
        public float disableProbe_high;
        public float disableTelecom;
        public float disableTelecom_low;
        public float disableTelecom_high;
        public float supply;
        public float battery;
        public float solar;
        public float solarCharge;

        public virtual void update(IModel model)
        {
            update(model, new string[]{"enableProbe", "disableProbe", "disableTelecom"});
        }

        public override bool Equals(object obj)
        {
            PowerDataModel model = obj as PowerDataModel;
            if (model != null)
            {
                if (this.enableProbe != model.enableProbe)
                {
                    return false;
                }
                if (this.disableProbe != model.disableProbe)
                {
                    return false;
                }
                if (this.disableTelecom != model.disableTelecom)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
