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
    public class QueryPowerTaskGroup : BasicTaskGroup
    {
        public enum TYPE {VOLTAGE};
        public QueryPowerTaskGroup(Control control, BasicTask.UpdateView updateView)
            : base(control, updateView)
        {
            base.Add(new BasicTask(TYPE.VOLTAGE, control, updateView, new BasicTask.Process(queryVoltageProcess)));
            Interval = 2000;
        }

        private void queryVoltageProcess()
        {
            UIPowerService.queryVoltage();
        }

        public void startQueryPowerLoop()
        {
            base.execute(TYPE.VOLTAGE, -1);
        }

        public void stopQueryLoop()
        {
            base.stopLoop();
        }
    }
}
