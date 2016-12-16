using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConfigFrame.BaseService;
using ConfigFrame.Protocol;
using ConfigFrame.BaseModel;
using ConfigFrame.CommunicationService.SerialPortSupport;


namespace ConfigFrame.CommunicationService
{
    public class StandardCommunicationService:ICommunicationService
    {
        private SerialPortAdapter serial;
        private byte[] testBytes;

        public int TimeOut
        {
            set { serial.SetTimeOut(value); }
        }

        public void process(IRequest req, IResponse resp)
        {
            byte[] recv = serial.sendAndReceive(req.genBytes());
            resp.parse(recv);
        }

        public void sendOnly(IRequest[] req)
        {
            for (int i = 0; i < req.Length; i++)
            {
                serial.writeOnly(req[i].genBytes());
            }
        }

        public void connect(IDataModel paraModel)
        {
            SerialPortModel sModel = (SerialPortModel)paraModel;
            serial.SetPortBaudRate(System.Convert.ToInt32(sModel.baudRate));
            serial.SetPortName(sModel.port);
            serial.openSerial();
        }

        public void disconnect()
        {
            serial.closeSerial();
        }

        public IResponse[] processRequestBatch(IRequest[] reqs)
        {
            List<IResponse> result = new List<IResponse>();
            for (int i = 0; i < reqs.Length; i++)
            {
                IResponse resp = processRequest(reqs[i]);
                if (resp != null)
                {
                    result.Add(resp);
                }
                
            }
            return result.ToArray();
        }

        public IResponse processRequest(IRequest req)
        {
            if (req.IsNull == false)
            {
                IResponse resp = req.genResponse();
                resp.Request = req;
                process(req, resp);
                return resp;
            }
            return null;
        }
    }
}
