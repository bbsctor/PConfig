using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;

namespace PConfigBase.BaseModelImpl.ModelConverterImpl
{
    public class SensorListConverter:IModelConverter
    {
        private static SensorListConverter instance = null;

        public static SensorListConverter getInstance()
        {
            if (instance == null)
            {
                instance = new SensorListConverter();
            }
            return instance;
        }

        private SensorListConverter()
        {

        }

        public IDataModel genDataModel(IViewModel vModel)
        {
            SensorListViewModel LVModel = vModel as SensorListViewModel;
            SensorListDataModel model = null;
            if (LVModel != null)
            {
                model = genDataModel(LVModel);
            }
            return model;
        }

        public IViewModel genViewModel(IDataModel dModel)
        {
            SensorListViewModel vModel = null;
            SensorListDataModel model = dModel as SensorListDataModel;
            if (model != null)
            {
                vModel = genViewModel(model);
                SensorViewModel.ModelCompare compare = new SensorViewModel.ModelCompare();
                vModel.Sort(compare);
            }
            return vModel;
        }

        private static SensorListDataModel genDataModel(SensorListViewModel viewList)
        {
            SensorListDataModel modelList = new SensorListDataModel();
            for (int i = 0; i < viewList.Count; i++)
            {
                modelList.Add((SensorDataModel)SensorConverter.getInstance().genDataModel(viewList[i]));
            }
            return modelList;
        }

        private static SensorListViewModel genViewModel(SensorListDataModel sensorList)
        {
            SensorListViewModel viewList = new SensorListViewModel();
            for (int i = 0; i < sensorList.Count; i++)
            {
                viewList.Add((SensorViewModel)(SensorConverter.getInstance().genViewModel(sensorList[i])));
            }
            return viewList;
        }
    }
}
