using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseDataModelImpl
{
    public class ModemDataModel : BasicModel, IDataModel
    {
        public byte[] atCommand;
        public byte baudRate;
        public byte parity;

        public byte[] sessionRecv;
        public byte[] status;

        public void clear()
        {
            atCommand = null;
            sessionRecv = null;
        }

        public override void update(IModel newModel)
        {
            ModemDataModel temp = newModel as ModemDataModel;
            if (temp != null)
            {
                this.atCommand = temp.atCommand;
            }
        }

        public override bool Equals(object obj)
        {
            return false;
        }
    }
}
