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
    public class NetworkConverter:IModelConverter
    {
        private static NetworkConverter instance = null;

        public static NetworkConverter getInstance()
        {
            if (instance == null)
            {
                instance = new NetworkConverter();
            }
            return instance;
        }

        private NetworkConverter()
        {

        }

        private static NetworkDataModel genDataModel(NetworkViewModel vModel)
        {
            NetworkDataModel model = new NetworkDataModel();
            model.userName = StringByteConverter.stringToByteArray(vModel.UserName);
            model.password = StringByteConverter.stringToByteArray(vModel.Password);
            model.dialInEnable = StringByteConverter.stringToByteArray(vModel.DialInEnable);
            model.dialInEnableResp = StringByteConverter.stringToByteArray(vModel.DialInEnableResp);
            model.dialInDisable = StringByteConverter.stringToByteArray(vModel.DialInDisable);
            model.dialInDisableResp = StringByteConverter.stringToByteArray(vModel.DialInDisableResp);
            model.init = StringByteConverter.stringToByteArray(vModel.Init);
            model.initResp = StringByteConverter.stringToByteArray(vModel.InitResp);
            model.connect = StringByteConverter.stringToByteArray(vModel.Connect);
            model.connectResp = StringByteConverter.stringToByteArray(vModel.ConnectResp);
            model.disconnect = StringByteConverter.stringToByteArray(vModel.Disconnect);
            model.disconnectResp = StringByteConverter.stringToByteArray(vModel.DisconnectResp);

            return model;
        }

        public static NetworkViewModel genViewModel(NetworkDataModel model)
        {
            NetworkViewModel vModel = new NetworkViewModel();
            vModel.UserName = StringByteConverter.byteArrayToString(model.userName);
            vModel.Password = StringByteConverter.byteArrayToString(model.password);
            vModel.DialInEnable = StringByteConverter.byteArrayToString(model.dialInEnable);
            vModel.DialInEnableResp = StringByteConverter.byteArrayToString(model.dialInEnableResp);
            vModel.DialInDisable = StringByteConverter.byteArrayToString(model.dialInDisable);
            vModel.DialInDisableResp = StringByteConverter.byteArrayToString(model.dialInDisableResp);
            vModel.Init = StringByteConverter.byteArrayToString(model.init);
            vModel.InitResp = StringByteConverter.byteArrayToString(model.initResp);
            vModel.Connect = StringByteConverter.byteArrayToString(model.connect);
            vModel.ConnectResp = StringByteConverter.byteArrayToString(model.connectResp);
            vModel.Disconnect = StringByteConverter.byteArrayToString(model.disconnect);
            vModel.DisconnectResp = StringByteConverter.byteArrayToString(model.disconnectResp);

            return vModel;
        }

        public IDataModel genDataModel(IViewModel vModel)
        {
            NetworkViewModel LVModel = vModel as NetworkViewModel;
            NetworkDataModel model = null;
            if (LVModel != null)
            {
                model = genDataModel(LVModel);
            }
            return model;
        }

        public IViewModel genViewModel(IDataModel dModel)
        {
            NetworkViewModel vModel = null;
            NetworkDataModel model = dModel as NetworkDataModel;
            if (model != null)
            {
                vModel = genViewModel(model);
            }
            return vModel;
        }
    }
}
