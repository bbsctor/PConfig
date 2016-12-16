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
    public class UIProbeInfoService:IUIService
    {
        private static IController controller;
        static UIProbeInfoService()
        {
            controller = ContextProvider.getControllerByName("probeInfoController");
        }
        public static ProbeInfoViewModel getViewModel()
        {
            ProbeInfoDataModel model = (ProbeInfoDataModel)ModelRepository.getModelByType(typeof(ProbeInfoDataModel));
            return (ProbeInfoViewModel)ProbeInfoConverter.getInstance().genViewModel(model);
        }

        public static void updateDataModel(ProbeInfoDataModel model)
        {
            ModelRepository.updateModel(model);
        }

        public static void writeProbeInfo()
        {
            controller.execute("write");
        }

        public static void readProbeInfo()
        {
            controller.execute("read");
        }
    }
}
