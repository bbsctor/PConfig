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
    public class UISensorTestService
    {
        public static int[] addr;
        static IController bController;
        static UISensorTestService()
        {
            bController = ContextProvider.getControllerByName("sensorTestController"); 
        }
        public static void queryAllSensor()
        {
            bController.execute("queryAll");
        }

        public static void querySelectedSensor()
        {
            bController.execute("querySelected");
        }

        public static void queryRTSelectedSensor()
        {
            string temp = "";
            for (int i = 0; i < addr.Length; i++)
            {
                if (i != addr.Length - 1)
                {
                    temp += addr[i] + ",";
                }
                else
                {
                    temp += addr[i];
                }
            }
                bController.execute("queryRTSelected" + temp);
        }

        public static void stop()
        {
            bController.execute("stop");
        }
    }
}
