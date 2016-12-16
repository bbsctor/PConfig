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
    public class UISerialService:IUIService
    {
        private static IController controller;
        static UISerialService()
        {
            controller = ContextProvider.getControllerByName("serialController"); 
        }
        public static void connect()
        {
            controller.execute("connect");
        }

        public static void disconnect()
        {
            controller.execute("disconnect");
        }

        public static void closePort()
        {
            controller.execute("closePort");
        }

        public static SerialViewModel getViewModel()
        {
            ConnectDataModel model = (ConnectDataModel)ModelRepository.getModelByType(typeof(ConnectDataModel));
            return (SerialViewModel)SerialConverter.getInstance().genViewModel(model);
        }

        public static void updateDataModel(ConnectDataModel model)
        {
            ModelRepository.updateModel(model);
        }
    }
}
