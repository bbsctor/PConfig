using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PConfigBase.ProtocolImpl.Util;
using ConfigFrame.Protocol;
using ConfigFrame.Protocol.Complex;
using PConfigProtocol.FrameDef;
using PConfigProtocol.FrameDef.Util;
using PConfigProtocol.FrameDef.Configuration;
using PConfigProtocol.FrameDef.Clock;

namespace PConfigBase.ProtocolImpl
{
    public class Request:IComplexRequest
    {
        private Type responseType;

        public Type ResponseType
        {
            get { return responseType; }
            set { responseType = value; }
        }

        public CommonRequestFrame requestFrame;
        public CommonResponseFrame responseFrame;

        public static int Request_Leader_Number = 10;

        public ushort dataLength;

        public ushort frameNO;

        public byte func;

        private byte[] data;
        public byte[] Data
        {
            get { return data; }
            set { this.data = value; }
        }

        private bool isNull;

        public bool IsNull
        {
            get{ return this.isNull;}
            set{ this.isNull = value;}
        }

        private Dictionary<string, byte[]> paraMap;

        public Dictionary<string, byte[]> ParaMap
        {
            get { return paraMap; }
            set { paraMap = value; }
        }

        public Request()
        {
            paraMap = new Dictionary<string, byte[]>();
            this.responseType = typeof(Response);
            //this.requestFrame = null;
        }

        public Request(CommonRequestFrame requestFrame)
            : this()
        {
            this.requestFrame = requestFrame;
        }

        public static Request createNullRequest()
        {
            Request req = new Request();
            req.IsNull = true;
            return req;
        }

        public virtual IResponse genResponse()
        {
            //return (Response)Activator.CreateInstance(responseType);
            Response resp = new Response();
            //if (this.func == 0x6B)
            //{
            //    resp.responseFrame = new Response_6BFrame();
            //}
            //else if (this.func == 0x74)
            //{
            //    resp.responseFrame = new Response_74Frame();
            //}
            Type t = FrameMapper.getInstance().getRespFrameType(func);
            if (t != null)
            {
                resp.responseFrame = (CommonResponseFrame)Activator.
                CreateInstance(t);
            }
    
            return resp;
        }

        public Request(byte func, byte[] data)
        {
            paraMap = new Dictionary<string, byte[]>();
            this.responseType = typeof(Response);
            this.func = func;
            this.Data = data;
        }

        public virtual void buildData()
        {

        }

        public byte[] getPara(string name)
        {
            byte[] temp;
            this.paraMap.TryGetValue(name, out temp);
            return temp;
        }

        public byte[] genBytes()
        {
            buildData();
            if (this.requestFrame == null)
            {
                this.requestFrame = new CommonRequestFrame(func, Data);
            }

            //requestFrame.build();
            frameNO = CommonRequestFrame.frameNO.getCurrentNO();
            byte[] seg2 = ClarityAssistant.dataClarityProcess(requestFrame);
            return seg2.ToArray();
        }
    }
}
