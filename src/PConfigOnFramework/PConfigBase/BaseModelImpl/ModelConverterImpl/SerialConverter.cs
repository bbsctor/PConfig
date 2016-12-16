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
    public class SerialConverter:IModelConverter
    {
        private static SerialConverter instance = null;

        public static SerialConverter getInstance()
        {
            if (instance == null)
            {
                instance = new SerialConverter();
            }
            return instance;
        }

        private SerialConverter()
        {

        }

        private static ConnectDataModel genDataModel(SerialViewModel vModel)
        {
            ConnectDataModel model = new ConnectDataModel();
            model.port = vModel.Port;
            model.baudRate = System.Convert.ToString(vModel.BaudRate);
            model.isConnected = vModel.IsConnected;
            return model;
        }

        public IDataModel genDataModel(IViewModel vModel)
        {
            SerialViewModel LVModel = vModel as SerialViewModel;
            ConnectDataModel model = null;
            if (LVModel != null)
            {
                model = genDataModel(LVModel);
            }
            return model;
        }
        private static SerialViewModel genViewModel(ConnectDataModel model)
        {
            SerialViewModel vModel = new SerialViewModel();
            vModel.BaudRate = System.Convert.ToInt32(model.baudRate);
            vModel.Port = model.port;
            if (ConnectDataModel.loggerID != null)
            {
                vModel.LoggerID = StringByteConverter.byteArrayToString(ConnectDataModel.loggerID.LoggerID);
            }
            vModel.IsConnected = model.isConnected;

            return vModel;
        }

        public IViewModel genViewModel(IDataModel dModel)
        {
            SerialViewModel vModel = null;
            ConnectDataModel model = dModel as ConnectDataModel;
            if (model != null)
            {
                vModel = genViewModel(model);
            }
            return vModel;
        }
    }
}
