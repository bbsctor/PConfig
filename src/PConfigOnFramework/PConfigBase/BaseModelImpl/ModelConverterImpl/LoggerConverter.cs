using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using ConfigFrame.Util;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;

namespace PConfigBase.BaseModelImpl.ModelConverterImpl
{
    public class LoggerConverter : IModelConverter
    {
        private static LoggerConverter instance = null;

        public static LoggerConverter getInstance()
        {
            if (instance == null)
            {
                instance = new LoggerConverter();
            }
            return instance;
        }

        private LoggerConverter()
        {

        }

        private static LoggerDataModel genDataModel(LoggerViewModel vModel)
        {
            LoggerDataModel model = new LoggerDataModel();
            model.baudRate = BaudRateConverter.getHexByBaudRate(vModel.BaudRate);
            model.connectOut = vModel.ConnectOut *1000;
            model.destURL = (URLDataModel)URLConverter.getInstance().genDataModel(vModel.DestURL);
            //model.dialInTime = vModel.DialInTime;
            model.dialInTime = (uint)(vModel.DialInTime.Hours * 60 * 60
                + vModel.DialInTime.Minutes * 60 + vModel.DialInTime.Seconds);
            LoggerDataModel.loggerID.LoggerID = StringByteConverter.stringToByteArray("\"" + vModel.LoggerID + "\"");
            switch (vModel.Parity)
            {
                case "无":
                    model.parity = 0x00;
                    break;
                case "奇校验":
                    model.parity = 0x01;
                    break;
                case "偶校验":
                    model.parity = 0x02;
                    break;
            }
            model.responseOut = vModel.ResponseOut *1000;
            model.sampleCount = vModel.SampleCount;
            model.sampleOrigin = TimeConverter.genTimeDataModel(vModel.SampleOrigin);

            return model;
        }

        public IDataModel genDataModel(IViewModel vModel)
        {
            LoggerViewModel LVModel = vModel as LoggerViewModel;
            LoggerDataModel model = null;
            if (LVModel != null)
            {
                model = genDataModel(LVModel);
            }
            return model;
        }
        private static LoggerViewModel genViewModel(LoggerDataModel model)
        {
            LoggerViewModel vModel = new LoggerViewModel();
            vModel.BaudRate = BaudRateConverter.getBaudRateByHex(model.baudRate);
            vModel.ConnectOut = model.connectOut / 1000;
            vModel.DestURL = new URLViewModel(StringByteConverter.byteArrayToString(model.destURL.Url));
            vModel.DialInTime = new TimeSpan((int)model.dialInTime / 3600, 
                (int)model.dialInTime % 3600 / 60, (int)model.dialInTime % 3600 % 60 % 60);
            vModel.LoggerID = StringByteConverter.byteArrayToString(LoggerDataModel.loggerID.LoggerID).Substring(1,
                LoggerDataModel.loggerID.LoggerID.Length - 2);
            switch (model.parity)
            {
                case 0x00:
                    vModel.Parity = "无";
                    break;
                case 0x01:
                    vModel.Parity = "奇校验";
                    break;
                case 0x02:
                    vModel.Parity = "偶校验";
                    break;
            }
            vModel.ResponseOut = model.responseOut / 1000;
            vModel.SampleCount = model.sampleCount;
            vModel.SampleOrigin = TimeConverter.genTimeViewModel(model.sampleOrigin);
            vModel.ConnectStatus = StringByteConverter.byteArrayToString(model.connectStatus);

            return vModel;
        }

        public IViewModel genViewModel(IDataModel dModel)
        {
            LoggerDataModel model = dModel as LoggerDataModel;
            LoggerViewModel vModel = null;
            if (model != null)
            {
                vModel = genViewModel(model);
            }
            return vModel;
        }
    }
}
