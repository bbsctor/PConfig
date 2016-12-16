using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using ConfigFrame.Util;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.BaseModelImpl.BaseViewModelImpl;

namespace PConfigBase.BaseModelImpl.ModelConverterImpl
{
    public class ModemConverter:IModelConverter
    {
        private static ModemConverter instance = null;

        public static ModemConverter getInstance()
        {
            if (instance == null)
            {
                instance = new ModemConverter();
            }
            return instance;
        }

        private ModemConverter()
        {

        }

        private static ModemDataModel genDataModel(ModemViewModel vModel)
        {
            return null;
        }

        private static ModemViewModel genViewModel(ModemDataModel model)
        {
            ModemViewModel vModel = new ModemViewModel();
            List<byte> bytes = new List<byte>();
  
            vModel.SessionRecv = StringByteConverter.byteArrayToString(model.sessionRecv);
            //model.sessionRecv = null;
            vModel.Status = StringByteConverter.byteArrayToString(model.status);

            return vModel;
        }

        private static byte[] escapeHandle(byte[] bytes)
        {
            List<byte> temp = new List<byte>();
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 0x5C /*|| bytes[i] == 0x54*/ || bytes[i] == 0x00)
                {
                    //temp.Add(0x5C);
                    continue;
                }
                temp.Add(bytes[i]);
            }
            return temp.ToArray();
        }

        public IDataModel genDataModel(IViewModel vModel)
        {
            throw new NotImplementedException();
        }

        public IViewModel genViewModel(IDataModel dModel)
        {
            ModemViewModel vModel = null;
            ModemDataModel model = dModel as ModemDataModel;
            if (model != null)
            {
                vModel = genViewModel(model);
            }
            return vModel;
        }
    }
}
