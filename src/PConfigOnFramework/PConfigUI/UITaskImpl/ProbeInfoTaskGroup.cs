using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ConfigFrame.UITask;
using PConfigUI.UIServiceImpl;

namespace PConfigUI.UITaskImpl
{
    public class ProbeInfoTaskGroup:BasicTaskGroup
    {
        public enum TYPE { READ, WRITE};
        private int addr;
        
        public ProbeInfoTaskGroup(Control control, BasicTask.UpdateView updateView)
            :base(control, updateView)
        {
            base.Add(new BasicTask(TYPE.READ, control, updateView, new BasicTask.Process(readProcess)));
            base.Add(new BasicTask(TYPE.WRITE, control, updateView, new BasicTask.Process(writeProcess)));
        }

        private void readProcess()
        {
            UIProbeInfoService.readProbeInfo();
        }

        private void writeProcess()
        {
            UIProbeInfoService.writeProbeInfo();
        }

        public void readProbeInfo()
        {
            base.execute(TYPE.READ, 1);
        }

        public void writeProbeInfo()
        {
            base.execute(TYPE.WRITE, 1);
        }
    }
}
