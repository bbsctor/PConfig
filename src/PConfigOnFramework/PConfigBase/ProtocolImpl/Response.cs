using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PConfigBase.ProtocolImpl.Util;
using ConfigFrame.Protocol;
using ConfigFrame.Protocol.Complex;
using PConfigProtocol.FrameDef;
using PConfigProtocol.FrameDef.Util;

namespace PConfigBase.ProtocolImpl
{
    public class Response:IComplexResponse
    {
        private IRequest request;

        public IRequest Request
        {
            get { return request; }
            set { request = value; }
        }

        private bool isNull;
        public bool IsNull
        {
            get { return isNull; }
            set { isNull = value; }
        }

        public string type;

        public ushort dataLength;

        public ushort frameNO;

        public CommonResponseFrame responseFrame;

        private byte[] data;
        public byte[] Data
        {
            get { return data; }
            set { this.data = value; }
        }

        private Dictionary<string, byte[]> paraMap;

        public Dictionary<string, byte[]> ParaMap
        {
            get { return paraMap; }
            set { paraMap = value; }
        }

        public Response()
        {
            paraMap = new Dictionary<string, byte[]>();
        }

        public virtual void parseData()
        {

        }

        public static Response createNullResponse()
        {
            Response resp = new Response();
            resp.IsNull = true;
            return resp;
        }

        public void addPara(string name, byte[] value)
        {
            this.paraMap.Add(name, value);
        }

        public byte[] getPara(string name)
        {
            byte[] temp;
            this.paraMap.TryGetValue(name, out temp);
            return temp;
        }

        public void parse(byte[] inData)
        {
            byte[] temp;
            if (this.responseFrame == null)
            {
                this.responseFrame = new CommonResponseFrame();
            }

            responseFrame.Data = ClarityAssistant.dataDeClarityProcess(inData);
            responseFrame.Size = responseFrame.Data.Length;
            responseFrame.parse();

            temp = CommonResponseFrame.frameNO.Data;
            System.Array.Reverse(temp, 0, 2);
            frameNO = BitConverter.ToUInt16(temp, 0);
            validateFrameNO(frameNO);

            if (CommonResponseFrame.currentMode == CommonResponseFrame.DataMode.COMPLETE)
            {
                temp = CommonResponseFrame.dataLength.Data;
                System.Array.Reverse(temp, 0, 2);
                dataLength = BitConverter.ToUInt16(temp, 0);
                Data = CommonResponseFrame.data.Data;
                parseData();
                isNull = false;
            }
            else
            {
                dataLength = 0;
                Data = null;
                isNull = true;
            }

            if (CommonRequestFrame.addr1.Data[0] == 0xFF && CommonRequestFrame.addr1.Data[1] == 0xFF)
            {
                CommonRequestFrame.addr1.Data = CommonResponseFrame.addr1.Data;
            }
        }

        private bool validateFrameNO(ushort frameNO)
        {
            if (frameNO != ((Request)this.request).frameNO)
            {
                Console.WriteLine("===============Dismatch request and response!===============");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
