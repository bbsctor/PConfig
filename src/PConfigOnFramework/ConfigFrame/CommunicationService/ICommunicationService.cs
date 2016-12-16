using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using ConfigFrame.Protocol;

namespace ConfigFrame.CommunicationService
{
    public interface ICommunicationService
    {
        void connect(IDataModel paraModel);
        void sendOnly(IRequest[] req);
        void process(IRequest req, IResponse resp);
        void disconnect();
        IResponse[] processRequestBatch(IRequest[] reqs);
        IResponse processRequest(IRequest req);
        int TimeOut
        {
            set;
        }
    }
}
