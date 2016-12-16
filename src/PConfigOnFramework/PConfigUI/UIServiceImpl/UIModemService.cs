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
    public class UIModemService:IUIService
    {
        private static IController controller;
        static UIModemService()
        {
            controller = ContextProvider.getControllerByName("modemController"); 
        }
        public static void openSession()
        {
            controller.execute("openSession");
        }

        public static void closeSession()
        {
            controller.execute("closeSession");
        }

        public static void sendAT()
        {
            controller.execute("sendAT");
        }

        public static void initTest()
        {
            controller.execute("initTest");
        }

        public static void test()
        {
            controller.execute("test");
        }

        public static void closeTest()
        {
            controller.execute("closeTest");
        }

        public static void initUpload()
        {
            controller.execute("initUpload");
        }

        public static void upload()
        {
            controller.execute("upload");
        }

        public static ModemViewModel getViewModel()
        {
            ModemDataModel model = (ModemDataModel)ModelRepository.getModelByType(typeof(ModemDataModel));
            return (ModemViewModel)ModemConverter.getInstance().genViewModel(model);
        }

        public static void updateDataModel(ModemDataModel model)
        {
            ModelRepository.updateModel(model);
        }
    }
}
