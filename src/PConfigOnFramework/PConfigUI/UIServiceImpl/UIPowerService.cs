using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.AppInterface;
using ConfigFrame.UITask;
using PConfigBase.AppInterfaceImpl;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.ModelConverterImpl;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;
using PConfigFacade.SpringFacade;

namespace PConfigUI.UIServiceImpl
{
    public class UIPowerService
    {
        private static IController controller;

        static UIPowerService()
        {
            controller = ContextProvider.getControllerByName("powerController");
        }
        public static void queryVoltage()
        {
            controller.execute("queryVoltage");
        }

        public static PowerViewModel getViewModel()
        {
            PowerDataModel model = (PowerDataModel)ModelRepository.getModelByType(typeof(PowerDataModel));
            return (PowerViewModel)(PowerConverter.getInstance().genViewModel(model));
        }

        public static void updateDataModel(PowerDataModel model)
        {
            ModelRepository.updateModel(model);
        }
    }
}
