using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseDataModelImpl
{
    public class TimeDataModel : BasicModel, IDataModel
    {
        public ushort year;
        public byte month;
        public byte day;
        public byte hour;
        public byte minute;
        public byte second;

        public TimeDataModel()
        {

        }

        public TimeDataModel(ushort year, byte month, 
            byte day, byte hour, byte minute, byte second)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public void updateModel(TimeDataModel model)
        {
            this.year = model.year;
            this.month = model.month;
            this.day = model.day;
            this.hour = model.hour;
            this.minute = model.minute;
            this.second = model.second; 
        }

        public override bool Equals(object obj)
        {
            TimeDataModel model = obj as TimeDataModel;
            if (model != null)
            {
                if (this.year != model.year)
                {
                    return false;
                }
                if (this.month != model.month)
                {
                    return false;
                }
                if (this.day != model.day)
                {
                    return false;
                }
                if (this.hour != model.hour)
                {
                    return false;
                }
                if (this.minute != model.minute)
                {
                    return false;
                }
                if (this.second != model.second)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
