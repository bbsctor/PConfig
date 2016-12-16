using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.AppInterface;
using PConfigBase.AppInterfaceImpl;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.ModelConverterImpl;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;
using PConfigFacade.SpringFacade;

namespace PConfigUI.UIServiceImpl
{
    public class UILoggerService
    {
        private static IController controller;
        static UILoggerService()
        {
            controller = ContextProvider.getControllerByName("loggerController"); 
        }

        public static void deleteReading()
        {
            controller.execute("deleteReading");
        }

        public static LoggerViewModel getViewModel()
        {
            LoggerDataModel model = (LoggerDataModel)ModelRepository.getModelByType(typeof(LoggerDataModel));
            return (LoggerViewModel)LoggerConverter.getInstance().genViewModel(model);
        }

        public static void updateDataModel(LoggerDataModel model)
        {
            ModelRepository.updateModel(model);
        }
    }
}
