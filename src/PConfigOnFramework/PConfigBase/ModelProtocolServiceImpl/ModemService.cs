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

namespace PConfigBase.ModelProtocolServiceImpl
{
    public class ModemService : BasicService
    {
        public enum IdleMode { SESSION, UPLOAD, TEST, COMMON };
        public IdleMode idleMode = IdleMode.COMMON;
        public override IRequest[] genRequestByActionName(string action, IDataModel dModel)
        {
            ModemDataModel model = dModel as ModemDataModel;
            switch (action)
            {
                case "read":
                    return genRead(model);
                case "write":
                    return genWrite(model);
                case "openSession":
                    return genOpenSession();
                case "closeSession":
                    return genCloseSession();
                case "sendAT":
                    byte[] temp = model.atCommand;
                    model.atCommand = null;
                    return genSendAT(temp);
                case "initTest":
                    return genInitTest();
                case "test":
                    return genTest();
                case "initUpload":
                    return genInitUpload();
                case "upload":
                    return genTest();
            }
            return null;
        }

//数据长度	功能码	数据
//02H	    62H	    03H
        private IRequest[] genOpenSession()
        {
            Request req = new Request();
            req.func = 0x62;
            req.dataLength = 0x02;
            req.Data = new byte[] { 0x03 };
            return new RequestWrapper(req).getRequestArray();
        }

//AA FF(10) 00 7D DF 04 00 00 01 01 C7 0E 7A 00 02 50 00 60 DF FF 
//AA FF(10) 00 7D DF 04 00 00 01 01 C8 7D DF 95 00 03 63 61 6E EC 94 FF
        private IRequest[] genCloseSession()
        {
            Request[] reqs = new Request[2];
            reqs[0] = new Request(0x50, new byte[]{0x00});
            reqs[1] = new Request(0x63, new byte[]{0x61, 0x6E });
            return reqs;
        }

//数据长度	功能位		          命令	预留空位
//          42H	    03 00 00 01		    0DH
        private IRequest[] genSendAT(byte[] data)
        {
            Request[] reqs = new Request[2];
            
            byte[] temp = new byte[] { 0x03, 0x00, 0x00, 0x01 };
            temp = temp.Concat(data).Concat(new byte[] { 0x0D }).ToArray();
            reqs[0] = new Request(0x42, temp);
            reqs[1] = new Request(0x62, new byte[] { 0x03 });
            return reqs;
        }

//数据长度	功能位	待定	                          URL
//39H	    55H	    52 4C 8A DC(响应帧数据长度后出现)	
        private IRequest[] genTest()
        {
            return new RequestWrapper(new Request(0x75, new byte[] { 0x72, 0x65 })).getRequestArray();
        }

        private IRequest[] genInitTest()
        {
            Request[] reqs = new Request[2];
            reqs[0] = new Request(0x50, new byte[] { 0x00 });
            byte[] temp = new byte[] { 0x52, 0x4C, 0x8A, 0xDC };
            URLDataModel uModel = new URLDataModel();
            temp = temp.Concat(uModel.Url).ToArray();
            reqs[1] = new Request(0x55, temp);
            return reqs;
        }

        private IRequest[] genInitUpload()
        {
            Request[] reqs = new Request[2];
            reqs[0] = new Request(0x50, new byte[] { 0x00 });
            byte[] temp = new byte[] { 0x70, 0x66, 0x53, 0x58 };
            URLDataModel uModel = new URLDataModel();
            temp = temp.Concat(uModel.Url).ToArray();
            reqs[1] = new Request(0x75, temp);
            return reqs;
        }

        public override IMetaModel handleResponse(IResponse response)
        {
            MetaModel model = null;
            Response resp = (Response)response;
            byte[] data = resp.Data;
            switch (((Request)resp.Request).func)
            {
                case 0x62:
                    if (data != null)
                    {
                        return parseOpenSessionData(data); 
                    }
                    else
                    {
                        return model;
                    }
                case 0x42:
                    return parseSendATData(data);
                case 0x55:
                    return parseTestData(data);
                case 0x75:
                    return parseUploadData(data);
            }
            return model;
        }

        public IMetaModel parseOpenSessionData(byte[] data)
        {
            ModemMetaModel mModel = new ModemMetaModel();
            mModel.type = ModemMetaModel.TYPE.OPENSESSION;
            mModel.Data = data;
            return mModel;
        }

        public IMetaModel parseSendATData(byte[] data)
        {
            ModemMetaModel mModel = new ModemMetaModel();
            mModel.type = ModemMetaModel.TYPE.SENDAT;
            mModel.Data = data;
            return mModel;
        }

        public IMetaModel parseUploadData(byte[] data)
        {
            ModemMetaModel mModel = new ModemMetaModel();
            mModel.type = ModemMetaModel.TYPE.UPLOAD;
            mModel.Data = data;
            return mModel;
        }

        public IMetaModel parseTestData(byte[] data)
        {
            ModemMetaModel mModel = new ModemMetaModel();
            mModel.type = ModemMetaModel.TYPE.TEST;
            mModel.Data = data;
            return mModel;
        }

        private IRequest[] genRead(IDataModel clockModel)
        {
            return new RequestWrapper(Request.createNullRequest()).getRequestArray();
        }

        public IRequest[] genWrite(IDataModel clockModel)
        {
            return new RequestWrapper(Request.createNullRequest()).getRequestArray();
        }

        public override IRequest[] genIdleRequest()
        {
            if (idleMode == IdleMode.SESSION)
            {
                return genOpenSession();
            }
            else if (idleMode == IdleMode.TEST || idleMode == IdleMode.UPLOAD)
            {
                return genTest();
            }
            else
            {
                return base.genIdleRequest();
            }
        }
    }
}
