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
    public class URLConverter:IModelConverter
    {
        private static URLConverter instance = null;

        public static URLConverter getInstance()
        {
            if (instance == null)
            {
                instance = new URLConverter();
            }
            return instance;
        }

        private URLConverter()
        {

        }
        private static URLDataModel genDataModel(URLViewModel vModel)
        {
            URLDataModel model = new URLDataModel();
            model.password = StringByteConverter.stringToByteArray(vModel.Password);
            model.path = StringByteConverter.stringToByteArray(vModel.Path);
            model.port = StringByteConverter.stringToByteArray(vModel.Port);
            model.serverAddr = StringByteConverter.stringToByteArray(vModel.ServerAddr);
            model.userName = StringByteConverter.stringToByteArray(vModel.UserName);

            return model;
        }

        public IDataModel genDataModel(IViewModel vModel)
        {
            URLViewModel LVModel = vModel as URLViewModel;
            URLDataModel model = null;
            if (LVModel != null)
            {
                model = genDataModel(LVModel);
            }
            return model;
        }
        private static URLViewModel genViewModel(URLDataModel model)
        {
            URLViewModel vModel = new URLViewModel();
            vModel.Password = StringByteConverter.byteArrayToString(model.password);
            vModel.Path = StringByteConverter.byteArrayToString(model.path);
            vModel.Port = StringByteConverter.byteArrayToString(model.port);
            vModel.ServerAddr = StringByteConverter.byteArrayToString(model.serverAddr);
            vModel.UserName = StringByteConverter.byteArrayToString(model.userName);

            return vModel;
        }

        public IViewModel genViewModel(IDataModel dModel)
        {
            URLViewModel vModel = null;
            URLDataModel model = dModel as URLDataModel;
            if (model != null)
            {
                vModel = genViewModel(model);
            }
            return vModel;
        }
    }
}
