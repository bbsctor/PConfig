using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;


namespace PConfigBase.BaseModelImpl.ModelConverterImpl
{
    public class TimeConverter
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

        public static DateTime genTimeViewModel(TimeDataModel model)
        {
            DateTime dateTime = DateTime.Now;
            try 
            {
                dateTime = new DateTime((int)model.year, (int)model.month,
                    (int)model.day, (int)model.hour, (int)model.minute, (int)model.second);
            }
            catch (Exception e)
            {
                dateTime = DateTime.Now;
            }
            

            return dateTime;
        }

        //public static ushort getDaySeconds(DateTime time)
        //{
        //    DateTime temp = new DateTime(time.Year, time.Month, time.Day, 0, 0, 0);
        //    TimeSpan span = time - temp;
        //    ushort seconds = (ushort)(span.Hours * 60 * 60 + span.Minutes * 60 + span.Seconds);
        //    return seconds;
        //}

        //public static DateTime getSettedTime(ushort seconds)
        //{
        //    return DateTime.Now;
        //}
    }
}
