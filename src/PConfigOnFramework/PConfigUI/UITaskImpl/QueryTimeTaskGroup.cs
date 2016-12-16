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
    public class QueryTimeTaskGroup:BasicTaskGroup
    {
        public enum TYPE {PROBE, HOST};
        public QueryTimeTaskGroup(Control control, BasicTask.UpdateView updateView)
            : base(control, updateView)
        {
            base.Add(new BasicTask(TYPE.PROBE, control, updateView, new BasicTask.Process(queryProbeProcess)));
            base.Add(new BasicTask(TYPE.HOST, control, updateView, new BasicTask.Process(queryHostProcess)));
        }

        private void queryProbeProcess()
        {
            UIClockService.queryProbeTime();
        }

        private void queryHostProcess()
        {
            UIClockService.queryLocalTime();
        }

        public void startQueryProbeLoop()
        {
            base.execute(TYPE.PROBE, -1);
        }

        public void startQueryHostLoop()
        {
            base.execute(TYPE.HOST, -1);
        }

        public void stopQueryLoop()
        {
            base.stopLoop();
        }
    }
}
