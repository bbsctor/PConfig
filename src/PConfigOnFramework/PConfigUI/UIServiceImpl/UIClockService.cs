using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.AppInterface;
using ConfigFrame.UITask;
using PConfigBase.AppInterfaceImpl;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.ModelConverterImpl;
using PConfigFacade.SpringFacade;

namespace PConfigUI.UIServiceImpl
{
    public class UIClockService:IUIService
    {
        private static IController controller;

        static UIClockService()
        {
            controller = ContextProvider.getControllerByName("clockController");
        }

        public static void queryLocalTime()
        {
            controller.execute("queryLocalTime");
        }

        public static void queryProbeTime()
        {
            //controller.execute("queryProbeTime");
        }

        public static DateTime getTimeView()
        {
            ClockDataModel cModel = (ClockDataModel)(ModelRepository.getModelByType(typeof(ClockDataModel)));
            TimeDataModel model = cModel.timeModel;
            return TimeConverter.genTimeViewModel(model);
        }

        public static void updateSamplingInterval(uint seconds)
        {
            ClockDataModel cModel = (ClockDataModel)(ModelRepository.getModelByType(typeof(ClockDataModel)));
            cModel.update(genDataModelWithSamplingIntreval(seconds));
            controller.execute("setSamplingInterval");
        }

        private static ClockDataModel genDataModelWithSamplingIntreval(uint samplingInterval)
        {
            ClockDataModel cModel = new ClockDataModel();
            cModel.samplingInterval = samplingInterval;
            return cModel;
        }

        public static void updateDataModel(ClockDataModel cModel)
        {
            controller.execute("ignoreResult");
            ModelRepository.updateModel(cModel);
        }

        public static uint getSamplingIntervalView()
        {
            ClockDataModel cModel = (ClockDataModel)(ModelRepository.getModelByType(typeof(ClockDataModel)));
            return cModel.samplingInterval;
        }

        public static void bindingServer()
        {
            ((BasicDynamicController)controller).bindingServer();
        }

        public static void unbindingServer()
        {
            ((BasicDynamicController)controller).unbindingServer();
        }
    }
}
