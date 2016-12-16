using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;

namespace PConfigBase.BaseModelImpl.ModelConverterImpl
{
    public class PowerConverter:IModelConverter
    {
        private static PowerConverter instance = null;

        public static PowerConverter getInstance()
        {
            if (instance == null)
            {
                instance = new PowerConverter();
            }
            return instance;
        }

        private PowerConverter()
        {

        }

        private static PowerDataModel genDataModel(PowerViewModel vModel)
        {
            PowerDataModel model = new PowerDataModel();
            model.battery = vModel.Battery;
            model.disableProbe = vModel.DisableProbe;
            model.disableProbe_high = vModel.DisableProbe_high;
            model.disableProbe_low = vModel.DisableProbe_low;
            model.disableTelecom = vModel.DisableTelecom;
            model.disableTelecom_high = vModel.DisableTelecom_high;
            model.disableTelecom_low = vModel.DisableTelecom_low;
            model.enableProbe = vModel.EnableProbe;
            model.enableProbe_high = vModel.EnableProbe_high;
            model.enableProbe_low = vModel.EnableProbe_low;
            model.solar = vModel.Solar;
            model.solarCharge = vModel.SolarCharge;
            model.supply = vModel.Supply;

            return model;
        }

        public IDataModel genDataModel(IViewModel vModel)
        {
            PowerViewModel LVModel = vModel as PowerViewModel;
            PowerDataModel model = null;
            if (LVModel != null)
            {
                model = genDataModel(LVModel);
            }
            return model;
        }
        private static PowerViewModel genViewModel(PowerDataModel model)
        {
            PowerViewModel vModel = new PowerViewModel();
            vModel.Battery = model.battery;
            vModel.DisableProbe = model.disableProbe;
            vModel.DisableProbe_high = model.disableProbe_high;
            vModel.DisableProbe_low = model.disableProbe_low;
            vModel.DisableTelecom = model.disableTelecom;
            vModel.DisableTelecom_high = model.disableTelecom_high;
            vModel.DisableTelecom_low = model.disableTelecom_low;
            vModel.EnableProbe = model.enableProbe;
            vModel.EnableProbe_high = model.enableProbe_high;
            vModel.EnableProbe_low = model.enableProbe_low;
            vModel.Solar = model.solar;
            vModel.SolarCharge = model.solarCharge;
            vModel.Supply = model.supply;  

            return vModel;
        }

        public IViewModel genViewModel(IDataModel dModel)
        {
            PowerViewModel vModel = null;
            PowerDataModel model = dModel as PowerDataModel;
            if (model != null)
            {
                vModel = genViewModel(model);
            }
            return vModel;
        }
    }
}
