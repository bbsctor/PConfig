using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConfigFrame.AppInterface;
using ConfigFrame.UITask;
using PConfigBase.AppInterfaceImpl;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.ModelConverterImpl;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;
using PConfigFacade.SpringFacade;

namespace PConfigUI.UIServiceImpl
{
    public class UICommonService:IUIService
    {
        private static IController controller;
        private static IController oldController;
        private static IController selectedController;


        static UICommonService()
        {
            controller = ContextProvider.getControllerByName("commonController"); 
        }

        public static SensorListViewModel getSensorListView()
        {
            SensorListViewModel viewList = new SensorListViewModel();
            SensorListDataModel sensorList = (SensorListDataModel)ModelRepository.getModelByType(typeof(SensorListDataModel));

            return (SensorListViewModel)SensorListConverter.getInstance().genViewModel(sensorList);
        }

        public static void updateSensorListDataModel(SensorListDataModel modelList)
        {
            ModelRepository.updateModel(modelList);
        }

        public static void startLocalServer()
        {
            controller.execute("startServer");
        }

        public static void stopLocalServer()
        {
            controller.execute("stopServer");
        }

        public static void readProbe()
        {
            controller.execute("read"); 
        }

        public static void writeProbe()
        {
            controller.execute("write"); 
        }

        public static void setSelectedController(string controllerName)
        {
            selectedController = ContextProvider.getControllerByName(controllerName);
            selectedController.execute("bindingServer");
        }

        //public static void restoreSelectedController()
        //{
        //    AppInterfaceContext ctx = SpringContext.getAppContext();
        //    ctx.CurrentController = oldController;
        //}

        //public static IController getSelectedController()
        //{
        //    AppInterfaceContext ctx = SpringContext.getAppContext();
        //    return ctx.CurrentController;
        //}
    }
}
