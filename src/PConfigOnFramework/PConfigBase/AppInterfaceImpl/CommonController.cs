using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.AppInterface;
using ConfigFrame.Protocol;
using ConfigFrame.BaseModel;
using ConfigFrame.CommunicationService;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.ModelProtocolServiceImpl;
using PConfigBase.BaseModelImpl.BaseMetaModelImpl;

namespace PConfigBase.AppInterfaceImpl
{
    public class CommonController : BasicDynamicController
    {
        public List<IController> controllerList;

        public override void execute(string action)
        {
            if ("read".Equals(action))
            {
                readProbe();
            }
            else if ("write".Equals(action))
            {
                writeProbe();
            }
            else if ("startServer".Equals(action))
            {
                server.start(this);
            }
            else if ("stopServer".Equals(action))
            {
                server.stop();
            }
            else if ("readProbeInfo".Equals(action))
            {
                readProbeInfo();
            }
            else if ("writeProbeInfo".Equals(action))
            {
                writeProbeInfo();
            }
        }

        public void writeProbe()
        {
            for (int i = 0; i < controllerList.Count; i++)
            {
                controllerList[i].execute("write");
            }
        }

        public void readProbe()
        {
            for (int i = 0; i < controllerList.Count; i++)
            {
                controllerList[i].execute("read");
            }
        }

        public void readProbeInfo()
        {
            base.execute("read");
        }

        public void writeProbeInfo()
        {
            base.execute("write");
        }
    }
}
