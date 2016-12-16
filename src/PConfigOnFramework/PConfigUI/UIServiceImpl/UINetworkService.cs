using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.AppInterface;
using PConfigBase.AppInterfaceImpl;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.ModelConverterImpl;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;

namespace PConfigUI.UIServiceImpl
{
    public class UINetworkService
    {
        public static NetworkViewModel getViewModel()
        {
            NetworkDataModel model = (NetworkDataModel)ModelRepository.getModelByType(typeof(NetworkDataModel));
            return NetworkConverter.genViewModel(model);
        }

        public static void updateDataModel(NetworkDataModel model)
        {
            ModelRepository.updateModel(model);
        }
    }
}
