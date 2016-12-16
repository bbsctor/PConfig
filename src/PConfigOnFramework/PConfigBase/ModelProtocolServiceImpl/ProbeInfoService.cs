using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using ConfigFrame.BaseService;
using ConfigFrame.Protocol;
using PConfigBase.ProtocolImpl;
using PConfigBase.BaseModelImpl.BaseMetaModelImpl;
using PConfigBase.BaseModelImpl.BaseDataModelImpl;
using PConfigBase.ModelProtocolServiceImpl.Convert;
using PConfigProtocol.FrameDef;

namespace PConfigBase.ModelProtocolServiceImpl
{
    public class ProbeInfoService : BasicService
    {
        public static byte[] loggerID = null;
        public override IRequest[] genRequestByActionName(string action, IDataModel dModel)
        {
            ProbeInfoDataModel model = dModel as ProbeInfoDataModel;
            switch (action)
            {
                case "read":
                    return genRead(model);
                case "write":
                    return genWrite(model);
            }
            return null;
        }

//前导帧	    帧头	地址位1	  地址位2	帧序号	 CRC1	数据长度	功能码	数据	 CRC2	  帧尾
//AA FF(10对)	00 FF	04 0A	  2 Byte	2 Byte	 2 Byte	(0BH)	    65H	    10 Byte	 2 Byte	  FF
        public IRequest genQueryProbeInfo()
        {
            Request req = new Request();
            req.func = 0x65;

            //req.Data = LoggerDataModel.loggerID.LoggerID;
            req.Data = loggerID;
            return req;
        }

        public IRequest genModifyAddr(byte[] addr)
        {
            return new Request(0x45, addr);
        }

        public override IMetaModel handleResponse(IResponse response)
        {
            Response resp = (Response)response;
            byte[] data = resp.Data;
            
            switch (((Request)(resp.Request)).func)
            {
                case 0x65:
                    return parseProbeInfoData(data);
                case 0x45:
                    CommonRequestFrame.addr1.Data = ((Request)(resp.Request)).Data;
                    return null;
                default:
                    return null;
            }
        }
//” XEPI-232 (16/PLUS)(RMT)”1034"01040A651700007D"1.6.2
        private IMetaModel parseProbeInfoData(byte[] data)
        {
            ProbeInfoMetaModel mModel = new ProbeInfoMetaModel();
            mModel.type = ProbeInfoMetaModel.TYPE.PROBEINFO;
            ProbeInfoDataModel model = new ProbeInfoDataModel();
            model.type = new byte[25];
            System.Array.Copy(data, 1, model.type, 0, 25);
            model.serialNumber = new byte[18];
            System.Array.Copy(data, 28, model.serialNumber, 0, 18);

            System.Array.Reverse(data, 26, 2);
            
            model.addr = BitConverter.ToUInt16(data, 26);
            model.bigVersion = data[46];
            model.middleVersion = data[47];

            System.Array.Reverse(data, 48, 2);

            model.littleVersion = BitConverter.ToUInt16(data, 48);

            mModel.Data = model;
            return mModel;
        }

        public IRequest[] genRead(IDataModel model)
        {
            return new RequestWrapper(genQueryProbeInfo()).getRequestArray();
        }

        public IRequest[] genWrite(IDataModel model)
        {
            if (model.Modified == false)
            {
                return new RequestWrapper(Request.createNullRequest()).getRequestArray();
            }
            byte[] temp = BitConverter.GetBytes(((ProbeInfoDataModel)model).addr);
            System.Array.Reverse(temp, 0, 2);

            return new RequestWrapper(genModifyAddr(temp)).getRequestArray();
        }
    }
}
