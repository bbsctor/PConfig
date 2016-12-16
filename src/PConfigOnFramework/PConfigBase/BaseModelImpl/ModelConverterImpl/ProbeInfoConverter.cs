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
    public class ProbeInfoConverter:IModelConverter
    {
        private static ProbeInfoConverter instance = null;

        public static ProbeInfoConverter getInstance()
        {
            if (instance == null)
            {
                instance = new ProbeInfoConverter();
            }
            return instance;
        }

        private ProbeInfoConverter()
        {

        }

        private static ProbeInfoDataModel genDataModel(ProbeInfoViewModel vModel)
        {
            ProbeInfoDataModel model = new ProbeInfoDataModel();
            model.type = StringByteConverter.stringToByteArray(vModel.Type);
            model.serialNumber = StringByteConverter.stringToByteArray(vModel.SerialNumber);
            model.addr = vModel.Addr;

            return model;
        }

        public IDataModel genDataModel(IViewModel vModel)
        {
            ProbeInfoViewModel LVModel = vModel as ProbeInfoViewModel;
            ProbeInfoDataModel model = null;
            if (LVModel != null)
            {
                model = genDataModel(LVModel);
            }
            return model;
        }
        private static ProbeInfoViewModel genViewModel(ProbeInfoDataModel model)
        {
            ProbeInfoViewModel vModel = new ProbeInfoViewModel();
            vModel.Type = StringByteConverter.byteArrayToString(model.type);
            vModel.SerialNumber = StringByteConverter.byteArrayToString(model.serialNumber);
            vModel.Addr = model.addr;
            //vModel.Version = System.Convert.ToChar(model.bigVersion) + "."
            //    + System.Convert.ToChar(model.middleVersion) + "."
            //    + System.Convert.ToString(model.littleVersion);
            vModel.Version = (int)(model.bigVersion) + "."
                + (int)(model.middleVersion) + "."
                + (int)(model.littleVersion);

            return vModel;
        }

        public IViewModel genViewModel(IDataModel dModel)
        {
            ProbeInfoViewModel vModel = null;
            ProbeInfoDataModel model = dModel as ProbeInfoDataModel;
            if (model != null)
            {
                vModel = genViewModel(model);
            }
            return vModel;
        }
    }
}
