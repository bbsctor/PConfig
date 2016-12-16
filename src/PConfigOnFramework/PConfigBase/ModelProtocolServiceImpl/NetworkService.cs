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
    public class NetworkService : BasicService
    {
        public override IRequest[] genRequestByActionName(string action, IDataModel dModel)
        {
            NetworkDataModel model = dModel as NetworkDataModel;
            switch (action)
            {
                case "read":
                    return genRead(model);
                case "write":
                    return genWrite(model);
            }
            return null;
        }

        private IRequest[] genModify(NetworkDataModel model)
        {
            List<IRequest> reqs = new List<IRequest>();
            if (model.ModifiedFieldList.Contains("userName"))
            {
                reqs.Add(genModifyUserName(model.userName));
            }
            if (model.ModifiedFieldList.Contains("password"))
            {
                reqs.Add(genModifyPassword(model.password));
            }
            if (model.ModifiedFieldList.Contains("init") && model.ModifiedFieldList.Contains("initResp"))
            {
                reqs.Add(genModifyInit(model));
            }
            if (model.ModifiedFieldList.Contains("connect") && model.ModifiedFieldList.Contains("connectResp"))
            {
                reqs.Add(genModifyConnect(model));
            }
            if (model.ModifiedFieldList.Contains("disconnect") && model.ModifiedFieldList.Contains("disconnectResp"))
            {
                reqs.Add(genModifyDisconnect(model));
            }
            if (model.ModifiedFieldList.Contains("dialInEnable") && model.ModifiedFieldList.Contains("dialInEnableResp"))
            {
                reqs.Add(genModifyDialInEnable(model));
            }
            if (model.ModifiedFieldList.Contains("dialInDisable") && model.ModifiedFieldList.Contains("dialInDisableResp"))
            {
                reqs.Add(genModifyDialInDisable(model));
            }
            if (reqs.Count == 0)
            {
                Request req = new Request();
                req.IsNull = true;
                reqs.Add(req);
            }
            return reqs.ToArray();
        }

        private IRequest genModifyCmd(byte[] cmdTag,byte[] send, byte[] recv)
        {
            return new Request(0x4E, cmdTag.Concat(send).Concat(new byte[] { 0x00 }).Concat(recv)
                .Concat(new byte[] { 0x00 }).ToArray());
        }

        private IRequest genModifyInit(NetworkDataModel model)
        {
            return genModifyCmd(new byte[]{0x49, 0x53}, model.init, model.initResp);
        }

        private IRequest genModifyConnect(NetworkDataModel model)//下位机代码实现错误
        {
            return genModifyCmd(new byte[] { 0x43, 0x53 }, model.connect, model.connectResp);
        }

        private IRequest genModifyDisconnect(NetworkDataModel model)
        {
            return genModifyCmd(new byte[] { 0x44, 0x53 }, model.disconnect, model.disconnectResp);
        }

        private IRequest genModifyDialInEnable(NetworkDataModel model)
        {
            return genModifyCmd(new byte[] { 0x54, 0x45 }, model.dialInEnable, model.dialInEnableResp);
        }

        private IRequest genModifyDialInDisable(NetworkDataModel model)
        {
            return genModifyCmd(new byte[] { 0x54, 0x44 }, model.dialInDisable, model.dialInDisableResp);
        }

//数据长度	功能位	类型	        数据	    预留空位
//0AH	    4EH	    用户名(55 53)	修改的数据	00H
        private IRequest genModifyUserName(byte[] data)
        {
            return new Request(0x4E, new byte[] { 0x55, 0x53 }.Concat(data).Concat(new byte[] { 0x00 }).ToArray());
        }

//数据长度	功能位	类型	        数据	    预留空位
//0AH	    4EH	    密码(50 57)	    修改的数据	00H
        private IRequest genModifyPassword(byte[] data)
        {
            return new Request(0x4E, new byte[] { 0x50, 0x57 }.Concat(data).Concat(new byte[] { 0x00 }).ToArray());
        }

//75 73(us，用户名响应帧)
        private IRequest genQueryUserName()
        {
            Request req = new Request();
            req.func = 0x6E;
            req.dataLength = 0x03;
            req.Data = new byte[]{0x75, 0x73};
            return req;
        }

        //70 77(pw，密码响应帧)
        private IRequest genQueryPssword()
        {
            Request req = new Request();
            req.func = 0x6E;
            req.dataLength = 0x03;
            req.Data = new byte[] { 0x70, 0x77 };
            return req;
        }

        //69 73(is，Initializetion命令)
        private IRequest genQueryInitCmd()
        {
            Request req = new Request();
            req.func = 0x6E;
            req.dataLength = 0x03;
            req.Data = new byte[] { 0x69, 0x73 };
            return req;
        }

        //63 73(cs，Connect命令)
        private IRequest genQueryConnectCmd()
        {
            Request req = new Request();
            req.func = 0x6E;
            req.dataLength = 0x03;
            req.Data = new byte[] { 0x63, 0x73 };
            return req;
        }

        //64 73(ts，Disconnect命令)
        private IRequest genQueryDisconnectCmd()
        {
            Request req = new Request();
            req.func = 0x6E;
            req.dataLength = 0x03;
            req.Data = new byte[] { 0x64, 0x73 };
            return req;
        }

        //74 65(te，Dial-in Enable命令)
        private IRequest genQueryDialInEnableCmd()
        {
            Request req = new Request();
            req.func = 0x6E;
            req.dataLength = 0x03;
            req.Data = new byte[] { 0x74, 0x65 };
            return req;
        }

        //74 64(td，Dail-in Disable命令)
        private IRequest genQueryDialInDisableCmd()
        {
            Request req = new Request();
            req.func = 0x6E;
            req.dataLength = 0x03;
            req.Data = new byte[] { 0x74, 0x64 };
            return req;
        }

        public override IMetaModel handleResponse(IResponse response)
        {
            Response resp = (Response)response;
            byte[] data = resp.Data;
            Request request = (Request)resp.Request;
            switch (request.func)
            {
                case 0x6E:
                    switch (request.Data[0])
                    {
                        case 0x75:
                            switch (request.Data[1])
                            {
                                case 0x73:
                                    return parseUserName(data);
                            }
                            break;
                        case 0x70:
                            switch (request.Data[1])
                            {
                                case 0x77:
                                    return parsePassword(data);
                            }
                            break;
                        case 0x69:
                            switch (request.Data[1])
                            {
                                case 0x73:
                                    return parseInitCmd(data);
                            }
                            break;
                        case 0x63:
                            switch (request.Data[1])
                            {
                                case 0x73:
                                    return parseConnectCmd(data);
                            }
                            break;
                        case 0x64:
                            switch (request.Data[1])
                            {
                                case 0x73:
                                    return parseDisconnectCmd(data);
                            }
                            break;
                        case 0x74:
                            switch (request.Data[1])
                            {
                                case 0x65:
                                    return parseDialInEnableCmd(data);
                                case 0x64:
                                    return parseDialInDisableCmd(data);
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 0x4E:
                    switch (request.Data[0])
                    {
                        case 0x55:
                            switch (request.Data[1])
                            {
                                case 0x53:
                                    break;
                            }
                            break;
                        case 0x50:
                            switch (request.Data[1])
                            {
                                case 0x57:
                                    break;
                            }
                            break;
                    }
                    return null;
            }
            return null;
        }

//数据长度	数据
//          用户名、密码	预留空位
//1Byte		                00H

        private IMetaModel parseUserName(byte[] data)
        {
            return parseLoginInfo(NetworkMetaModel.TYPE.USERNAME, data);
        }

        private IMetaModel parsePassword(byte[] data)
        {
            return parseLoginInfo(NetworkMetaModel.TYPE.PASSWORD, data);
        }

        private IMetaModel parseLoginInfo(NetworkMetaModel.TYPE type, byte[] data)
        {
            NetworkMetaModel model = new NetworkMetaModel();
            model.type = type;
            model.Data = data;
            return model;
        }

//数据长度	数据
//          使能命令	预留空位	响应命令	预留空位
//1Byte		            00H		                00H
        private List<byte[]> parseData(byte[] data)
        {
            List<byte[]> result = new List<byte[]>();
            List<byte> temp = new List<byte>();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != 0x00)
                {
                    temp.Add(data[i]);
                }
                else if (data[i] == 0x00)
                {
                    result.Add(temp.ToArray());
                    if (i != data.Length - 1)
                    {
                        temp = new List<byte>();
                    }
                }
            }
            return result;
        }
        private IMetaModel parseConnectCmd(byte[] data)
        {
            return parseCmd(NetworkMetaModel.TYPE.CONNECT, data);
        }

        private IMetaModel parseDisconnectCmd(byte[] data)
        {
            return parseCmd(NetworkMetaModel.TYPE.DISCONNECT, data);
        }

        private IMetaModel parseInitCmd(byte[] data)
        {
            return parseCmd(NetworkMetaModel.TYPE.INIT, data);
        }

        private IMetaModel parseDialInEnableCmd(byte[] data)
        {
            return parseCmd(NetworkMetaModel.TYPE.DIALINENABLE, data);
        }

        private IMetaModel parseDialInDisableCmd(byte[] data)
        {
            return parseCmd(NetworkMetaModel.TYPE.DIALINDISABLE, data);
        }

        private IMetaModel parseCmd(NetworkMetaModel.TYPE type, byte[] data)
        {
            NetworkMetaModel model = new NetworkMetaModel();
            model.type = type;
            List<byte[]> list = parseData(data);
            if (list.Count != 2)
            {
                throw new Exception();
            }
            model.Data = list;
            return model;
        }

//数据长度	功能位	数据
//03	6E	
//75 73(us，用户名响应帧)
//70 77(pw，密码响应帧)
//69 73(is，Initializetion命令)
//63 73(cs，Connect命令)
//64 73(ts，Disconnect命令)
//74 65(te，Dial-in Enable命令)
//74 64(td，Dail-in Disable命令)
        private IRequest[] genRead(IDataModel networkModel)
        {
            Request[] reqs = new Request[7]{
                new Request(0x6E, new byte[]{0x75, 0x73}),
                new Request(0x6E, new byte[]{0x70, 0x77}),
                new Request(0x6E, new byte[]{0x69, 0x73}),
                new Request(0x6E, new byte[]{0x63, 0x73}),
                new Request(0x6E, new byte[]{0x64, 0x73}),
                new Request(0x6E, new byte[]{0x74, 0x65}),
                new Request(0x6E, new byte[]{0x74, 0x64})
            };
            return reqs;
        }

        private IRequest[] genWrite(IDataModel networkModel)
        {
            if (networkModel.Modified == false)
            {
                return new RequestWrapper(Request.createNullRequest()).getRequestArray();
            }
            NetworkDataModel model = networkModel as NetworkDataModel;
            IRequest[] reqs = genModify(model);

            return reqs;
        }

        private MetaModel confirm(byte[] data)
        {
            throw new NotImplementedException();
        }

    }
}
