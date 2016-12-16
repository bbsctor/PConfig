using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.AppInterface;
using PConfigBase.AppInterfaceImpl;
using ConfigFrame.UITask;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.ModelConverterImpl;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;
using PConfigFacade.SpringFacade;

namespace PConfigUI.UIServiceImpl
{
    public class UIConfigurationService:IUIService
    {
        private static IController controller;
        static UIConfigurationService()
        {
            controller = ContextProvider.getControllerByName("configurationController"); 
        }
        public static void updateAirByAddr(int addr)
        {
            controller.execute("readAir" + addr);
        }

        public static void updateWaterByAddr(int addr)
        {
            controller.execute("readWater" + addr);
        }

        public static void updateAll()
        {
            controller.execute("read");
        }

        public static void autoDetect()
        {
            controller.execute("autoDetect");
        }
    }
}
