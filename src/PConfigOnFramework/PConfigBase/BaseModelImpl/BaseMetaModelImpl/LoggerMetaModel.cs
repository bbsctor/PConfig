using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseMetaModelImpl
{
    public class LoggerMetaModel : MetaModel
    {
        public enum TYPE { MODEM, BAUDRATE, CONNECTOUT, DAILINTIME, DESTURL, LOGGERID, PARITY, RESPONSEOUT, SAMPLECOUNT, SAMPLEORIGIN, CONNECTSTATUS };
        public TYPE type;

    }
}
