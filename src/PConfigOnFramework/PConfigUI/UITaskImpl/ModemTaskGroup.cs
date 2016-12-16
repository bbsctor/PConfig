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
    public class ModemTaskGroup:BasicTaskGroup
    {
        public enum TYPE { OPEN, CLOSE, SEND, TEST, UPLOAD};
        public string cmd;
        
        public ModemTaskGroup(Control control, BasicTask.UpdateView updateView)
            :base(control, updateView)
        {
            base.Add(new BasicTask(TYPE.OPEN, control, updateView, new BasicTask.Process(openProcess)));
            base.Add(new BasicTask(TYPE.SEND, control, updateView, new BasicTask.Process(sendProcess)));
            base.Add(new BasicTask(TYPE.TEST, control, updateView, new BasicTask.Process(testProcess)));
            base.Add(new BasicTask(TYPE.UPLOAD, control, updateView, new BasicTask.Process(uploadProcess)));

            base.Interval = 1000;
        }

        private void openProcess()
        {
            //UIModemService.openSession();
        }

        private void sendProcess()
        {
            UIModemService.sendAT();
        }

        private void testProcess()
        {
            //UIModemService.test();
        }

        private void uploadProcess()
        {
            //UIModemService.upload();
        }

        public void openSession()
        {
            UIModemService.openSession();
            base.execute(TYPE.OPEN, -1);
        }

        public void closeSession()
        {
            UIModemService.closeSession();
            close();
        }

        public void close()
        {
            base.stopLoop();
        }

        public void sendAT()
        {
            UIModemService.sendAT();
            //base.execute(TYPE.SEND, 1);
            //Thread.Sleep(2000);
            //base.execute(TYPE.OPEN, -1);
        }

        public void test()
        {
            UIModemService.initTest();
            UIModemService.test();
            base.execute(TYPE.TEST, -1);
        }

        public void closeTest()
        {
            UIModemService.closeTest();
            close();
        }

        public void upload()
        {
            UIModemService.initUpload();
            UIModemService.upload();
            base.execute(TYPE.UPLOAD, -1);
        }
    }
}
