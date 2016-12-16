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
    public class QueryConfigurationTaskGroup:BasicTaskGroup
    {
        public enum TYPE { AIR, WATER ,ALL};
        private int addr;
        
        public QueryConfigurationTaskGroup(Control control, BasicTask.UpdateView updateView)
            :base(control, updateView)
        {
            base.Add(new BasicTask(TYPE.AIR, control, updateView, new BasicTask.Process(queryAirProcess)));
            base.Add(new BasicTask(TYPE.WATER, control, updateView, new BasicTask.Process(queryWaterProcess)));
            base.Add(new BasicTask(TYPE.ALL, control, updateView, new BasicTask.Process(queryAllProcess)));
        }

        private void queryAirProcess()
        {
            UIConfigurationService.updateAirByAddr(addr);
        }

        private void queryWaterProcess()
        {
            UIConfigurationService.updateWaterByAddr(addr);
        }

        private void queryAllProcess()
        {
            UIConfigurationService.updateAll();
        }

        public void updateAirByAddr(int addr)
        {
            this.addr = addr;
            base.execute(TYPE.AIR, 1);
        }

        public void updateWaterByAddr(int addr)
        {
            this.addr = addr;
            base.execute(TYPE.WATER, 1);
        }

        public void updateAll()
        {
            base.execute(TYPE.ALL, 1);
        } 
    }
}
