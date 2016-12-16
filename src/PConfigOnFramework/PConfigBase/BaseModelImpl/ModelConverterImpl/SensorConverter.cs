using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;

namespace PConfigBase.BaseModelImpl.ModelConverterImpl
{
    public class SensorConverter:IModelConverter
    {
        private static SensorConverter instance = null;

        public static SensorConverter getInstance()
        {
            if (instance == null)
            {
                instance = new SensorConverter();
            }
            return instance;
        }

        private SensorConverter()
        {

        }

        private static SensorDataModel genDataModel(SensorViewModel vModel)
        {
            SensorDataModel model = new SensorDataModel();
            model.addr = vModel.Addr;
            model.celibrateValue = vModel.celibrateValue;
            model.depth = vModel.Depth;
            model.equationA = vModel.EquationA;
            model.equationB = vModel.EquationB;
            model.equationC = vModel.EquationC;
            model.highAir = vModel.HighAir;
            model.lowWater = vModel.LowWater;
            model.rawCount = (ushort)vModel.RawCount;
            model.isSelected = vModel.IsSelected;

            return model;
        }

        private static SensorViewModel genViewModel(SensorDataModel model)
        {
            SensorViewModel vModel = new SensorViewModel();
            vModel.Addr = model.addr;
            vModel.celibrateValue = model.celibrateValue;
            vModel.Depth = model.depth;
            vModel.EquationA = model.equationA;
            vModel.EquationB = model.equationB;
            vModel.EquationC = model.equationC;
            vModel.HighAir = model.highAir;
            vModel.LowWater = model.lowWater;
            vModel.RawCount = model.rawCount;
            vModel.IsSelected = model.isSelected;

            return vModel;
        }

        public IDataModel genDataModel(IViewModel vModel)
        {
            SensorViewModel LVModel = vModel as SensorViewModel;
            SensorDataModel model = null;
            if (LVModel != null)
            {
                model = genDataModel(LVModel);
            }
            return model;
        }

        public IViewModel genViewModel(IDataModel dModel)
        {
            SensorViewModel vModel = null;
            SensorDataModel model = dModel as SensorDataModel;
            if (model != null)
            {
                vModel = genViewModel(model);
            }
            return vModel;
        }
    }
}
