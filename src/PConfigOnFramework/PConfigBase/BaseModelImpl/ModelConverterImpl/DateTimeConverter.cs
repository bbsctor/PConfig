using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;

namespace PConfigBase.BaseModelImpl.ModelConverterImpl
{
    public class DateTimeConverter
    {
        public static TimeDataModel genTimeDataModel(DateTime vModel)
        {
            TimeDataModel model = new TimeDataModel();
            model.year = (ushort)vModel.Year;
            model.month = (byte)vModel.Month;
            model.day = (byte)vModel.Day;
            model.hour = (byte)vModel.Hour;
            model.minute = (byte)vModel.Minute;
            model.second = (byte)vModel.Second;

            return model;
        }

        public static TimeViewModel genTimeViewModel(TimeDataModel model)
        {
            TimeViewModel vModel = new TimeViewModel();
            DateTime dateTime = new DateTime((int)model.year, (int)model.month,
                (int)model.day, (int)model.hour, (int)model.minute, (int)model.second);
            vModel.ViewDateTime = dateTime;

            return vModel;
        }
    }
}
