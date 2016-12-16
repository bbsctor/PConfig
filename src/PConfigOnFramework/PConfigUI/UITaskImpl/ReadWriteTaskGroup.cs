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
    public class ReadWriteTaskGroup:BasicTaskGroup
    {
        public enum TYPE { READ, WRITE, AUTODETECT};
        
        public ReadWriteTaskGroup(Control control, BasicTask.UpdateView updateView)
            :base(control, updateView)
        {
            base.Add(new BasicTask(TYPE.READ, control, updateView, new BasicTask.Process(readProcess)));
            base.Add(new BasicTask(TYPE.WRITE, control, updateView, new BasicTask.Process(writeProcess)));
            base.Add(new BasicTask(TYPE.AUTODETECT, control, updateView, new BasicTask.Process(autoDetectProcess)));
        }

        private void readProcess()
        {
            UICommonService.readProbe();
            //autoDetectProcess();
        }

        private void writeProcess()
        {
            UICommonService.writeProbe();
        }

        private void autoDetectProcess()
        {
            UIConfigurationService.autoDetect();
        }

        public void readProbe()
        {
            base.execute(TYPE.READ, 1);
        }

        public void writeProbe()
        {
            base.execute(TYPE.WRITE, 1);
        }

        public void autoDetect()
        {
            base.execute(TYPE.AUTODETECT, 1);
        }
    }
}
