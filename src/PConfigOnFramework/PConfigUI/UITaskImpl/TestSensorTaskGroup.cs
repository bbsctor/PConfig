using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;
using ConfigFrame.UITask;
using PConfigUI.UIServiceImpl;

namespace PConfigUI.UITaskImpl
{
    public class TestSensorTaskGroup:BasicTaskGroup
    {
        public enum TYPE {ALL, SELECTED, RTSELECTED};

        public TestSensorTaskGroup(Control control, BasicTask.UpdateView updateView)
            :base(control, updateView)
        {
            base.Add(new BasicTask(TYPE.ALL, control, updateView, new BasicTask.Process(queryAllProcess)));
            base.Add(new BasicTask(TYPE.SELECTED, control, updateView, new BasicTask.Process(querySelectProcess)));
            base.Add(new BasicTask(TYPE.RTSELECTED, control, updateView, new BasicTask.Process(queryRTSelectProcess)));
        }

        private void queryAllProcess()
        {
            //UISensorTestService.queryAllSensor();
        }

        private void querySelectProcess()
        {
            //UISensorTestService.querySelectedSensor();
        }

        private void queryRTSelectProcess()
        {
            //UISensorTestService.queryRTSelectedSensor();
        }

        public void queryAllSensor()
        {
            UISensorTestService.queryAllSensor();
            base.execute(TYPE.ALL, -1);
        }

        public void querySelectedSensor()
        {
            UISensorTestService.querySelectedSensor();
            base.execute(TYPE.SELECTED, -1);
        }

        public void queryRTSelectedSensor(int[] addr)
        {
            UISensorTestService.addr = addr;
            UISensorTestService.queryRTSelectedSensor();
            base.execute(TYPE.RTSELECTED, -1);
        }

        public void stopQueryLoop()
        {
            base.stopLoop();
            UISensorTestService.stop();
        }
    }
}
