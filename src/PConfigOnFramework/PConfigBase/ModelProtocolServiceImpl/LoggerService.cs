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
    public class LoggerService : BasicService
    {
        public override IRequest[] genRequestByActionName(string action, IDataModel dModel)
        {
            LoggerDataModel model = dModel as LoggerDataModel;
            switch (action)
            {
                case "read":
                    return genRead(model);
                case "write":
                    return genWrite(model);
                case "deleteReading":
                    return genDelReading();
            }
            return null;
        }

//数据长度	功能位	参数类型	数据
//                              波特率	待定	校验方式	待定
//06H	    42H	    02H	        1Byte	01H	    1Byte	    03H
        private IRequest genModifyModem(LoggerDataModel model)
        {
            Request req = Request.createNullRequest() ;
            if (model.ModifiedFieldList.Contains("baudRate") || model.ModifiedFieldList.Contains("parity"))
            {
                req = new Request();
                req.func = 0x42;
                req.dataLength = 0x06;

                byte[] data = new byte[5];
                data[0] = 0x02;
                data[1] = model.baudRate;
                data[2] = 0x01;
                data[3] = model.parity;
                data[4] = 0x03;

                req.Data = data;
            }
            
            return req;
        }

//数据长度	功能位	参数类型	    数据
//05H-35H	55H	    1、2、3、4Byte	要修改的参数信息
        private IRequest[] genModifyNoModem(LoggerDataModel model)
        {
            List<IRequest> reqs = new List<IRequest>();
            if (model.ModifiedFieldList.Contains("loggerID"))
            {
                reqs.Add(genModifyLoggerID(LoggerDataModel.loggerID.LoggerID));
            }
            if (model.ModifiedFieldList.Contains("connectOut"))
            {
                reqs.Add(genModifyConnectTimeOut(model.connectOut));
            }
            if (model.ModifiedFieldList.Contains("responseOut"))
            {
                reqs.Add(genModifyResponseTimeOut(model.responseOut));
            }
            if (model.ModifiedFieldList.Contains("url"))
            {
                reqs.Add(genModifyURL(model.destURL.Url));
            }
            if (model.ModifiedFieldList.Contains("sampleCount"))
            {
                reqs.Add(genModifySampleCount(model.sampleCount));
            }
            if (model.ModifiedFieldList.Contains("dialInTime"))
            {
                reqs.Add(genModifyDialInUpTime(model.dialInTime));
            }
            if (model.ModifiedFieldList.Contains("sampleOrigin"))
            {
                reqs.Add(genModifySampleOriginTime(model.sampleOrigin));
            }
            if (reqs.Count == 0)
            {
                reqs.Add(Request.createNullRequest());
            }
            return reqs.ToArray();
        }

        private IRequest genModifySampleOriginTime(TimeDataModel tModel)
        {
            byte[] temp = BitConverter.GetBytes(tModel.year);
            System.Array.Reverse(temp, 0, 2);
            return new Request(0x55, new byte[] { 0x50, 0x53 }.Concat(temp).
                Concat(new byte[]{tModel.month, tModel.day, tModel.hour, tModel.minute, tModel.second}).ToArray());
        }

        private IRequest genModifyLoggerID(byte[] loggerID)
        {
            ProbeInfoService.loggerID = loggerID;
            return new Request(0x55, new byte[]{0x4E, 0x4D}.Concat(loggerID).ToArray());
        }

        private IRequest genModifyURL(byte[] url)
        {
            return new Request(0x55, new byte[] {0x52, 0x4C, 0x00, 0x00 }.Concat(url).ToArray());
        }

        private IRequest genModifySampleCount(ushort sCount)
        {
            byte[] temp = BitConverter.GetBytes(sCount);
            System.Array.Reverse(temp, 0, 2);
            return new Request(0x55, new byte[] { 0x50, 0x4C}.Concat(temp).ToArray());
        }

        private IRequest genModifyDialInUpTime(uint upTime)
        {
            byte[] temp = BitConverter.GetBytes(upTime);
            System.Array.Reverse(temp, 0, 4);
            return new Request(0x55, new byte[] { 0x50, 0x44 }.Concat(temp).ToArray());
        }

        private IRequest genModifyConnectTimeOut(uint cTimeout)
        {
            byte[] temp = BitConverter.GetBytes(cTimeout);
            System.Array.Reverse(temp, 0 , 4);
            return new Request(0x55, new byte[] { 0x52, 0x54, 0x63 }.Concat(temp).ToArray());
        }

        private IRequest genModifyResponseTimeOut(uint cTimeout)
        {
            byte[] temp = BitConverter.GetBytes(cTimeout);
            System.Array.Reverse(temp, 0, 4);
            return new Request(0x55, new byte[] { 0x52, 0x54, 0x72 }.Concat(temp).ToArray());
        }

//75	6E 6D(nm,Logger_ID)
        private IRequest genQueryLoggerID()
        {
            Request req = new Request();
            req.func = 0x75;
            req.dataLength = 0x03;
            req.Data = new byte[]{0x6E, 0x6D};
            return req;
        }

        //75	72 74(rt,Connection Timeout)
        private IRequest genQueryConnectTimeout()
        {
            Request req = new Request();
            req.func = 0x75;
            req.dataLength = 0x03;
            req.Data = new byte[]{0x75, 0x74};
            return req;
        }

        //75	72 74(rt,Response Timeout)
        private IRequest genQueryResponseTimeout()
        {
            Request req = new Request();
            req.func = 0x75;
            req.dataLength = 0x03;
            req.Data = new byte[] { 0x72, 0x74 };
            return req;
        }

        //75	72 6C(rl,URL)
        private IRequest genQueryURL()
        {
            Request req = new Request();
            req.func = 0x75;
            req.dataLength = 0x03;
            req.Data = new byte[] { 0x72, 0x6C };
            return req;
        }

        //62	02(Modem)
        private IRequest genQueryModem()
        {
            Request req = new Request();
            req.func = 0x62;
            req.dataLength = 0x02;
            req.Data = new byte[] { 0x02 };
            return req;
        }

        //75	70 6C(pl,Sample Count)
        private IRequest genQuerySampleCount()
        {
            Request req = new Request();
            req.func = 0x75;
            req.dataLength = 0x03;
            req.Data = new byte[] { 0x70, 0x6C };
            return req;
        }

        //75	70 64(pd,Dail In Time)
        private IRequest genQueryDialInTime()
        {
            Request req = new Request();
            req.func = 0x75;
            req.dataLength = 0x03;
            req.Data = new byte[] { 0x70, 0x64 };
            return req;
        }

        //75	70 73(ps,Sample Origin)
        private IRequest genQuerySampleOrigin()
        {
            Request req = new Request();
            req.func = 0x75;
            req.dataLength = 0x03;
            req.Data = new byte[] { 0x70, 0x73 };
            return req;
        }

        public override IMetaModel handleResponse(IResponse response)
        {
            Response resp = (Response)response;
            byte[] data = resp.Data;
            MetaModel model = null;
            Request request = (Request)(resp.Request);
            if (data != null)
            {
                switch (request.func)
                {
                    case 0x75:
                        switch (request.Data[0])
                        {
                            case 0x72:
                                switch (request.Data[1])
                                {
                                    case 0x65:
                                        return parseConnectStatus(data);
                                    case 0x74:
                                        switch (request.Data[2])
                                        {
                                            case 0x63:
                                                return parseConnectTimeout(data);
                                            case 0x72:
                                                return parseResponseTimeout(data);
                                        }
                                        break;
                                    case 0x6C:
                                        return parseURL(data);
                                }
                                break;
                            case 0x70:
                                switch (request.Data[1])
                                {
                                    case 0x73:
                                        return parseSampleOrigin(data);
                                    case 0x6C:
                                        return parseSampleCount(data);
                                    case 0x64:
                                        return parseDialInTime(data);
                                }
                                break;
                            case 0x6E:
                                switch (request.Data[1])
                                {
                                    case 0x6D:
                                        return parseLoggerID(data);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case 0x62:
                        return parseModemData(data);
                    case 0x55:
                        return model;
                    case 0x42:
                        return model;
                    default:
                        return model;
                }
            }
            return model;
        }

//“ftp://	             用户名	 ：	  密码	      @	    ftp服务器地址	路径	”
//22 66 74 70 3A 2F 2F		     3AH		      40H			                    22H
        private IMetaModel parseURL(byte[] data)
        {
            LoggerMetaModel model = new LoggerMetaModel();
            model.type = LoggerMetaModel.TYPE.DESTURL;
            model.Data = data;
            return model;
        }

//数据长度	数据
//04H	    4Byte
        private IMetaModel parseConnectTimeout(byte[] data)
        {
            LoggerMetaModel model = new LoggerMetaModel();
            model.type = LoggerMetaModel.TYPE.CONNECTOUT;
            System.Array.Reverse(data, 0, 4);
            model.Data = BitConverter.ToUInt32(data, 0);
            return model;
        }

        private IMetaModel parseConnectStatus(byte[] data)
        {
            LoggerMetaModel model = new LoggerMetaModel();
            model.type = LoggerMetaModel.TYPE.CONNECTSTATUS;
            model.Data = data;
            return model;
        }

        private IMetaModel parseResponseTimeout(byte[] data)
        {
            LoggerMetaModel model = new LoggerMetaModel();
            model.type = LoggerMetaModel.TYPE.RESPONSEOUT;
            System.Array.Reverse(data, 0, 4);
            model.Data = BitConverter.ToUInt32(data, 0);
            return model;
        }

//数据长度	时间
//          年	月	日	时	分	秒
//07H	    2Byte	1Byte	1Byte	1Byte	1Byte	1Byte
        private IMetaModel parseSampleOrigin(byte[] data)
        {
            LoggerMetaModel model = new LoggerMetaModel();
            model.type = LoggerMetaModel.TYPE.SAMPLEORIGIN;
            model.Data = (Object)TimeParser.parseTimeData(data);
            return model;
        }

        private IMetaModel parseSampleCount(byte[] data)
        {
            LoggerMetaModel model = new LoggerMetaModel();
            model.type = LoggerMetaModel.TYPE.SAMPLECOUNT;
            System.Array.Reverse(data, 0, 2);
            model.Data = (ushort)BitConverter.ToUInt16(data, 0);
            return model;
        }

        private IMetaModel parseDialInTime(byte[] data)
        {
            LoggerMetaModel model = new LoggerMetaModel();
            model.type = LoggerMetaModel.TYPE.DAILINTIME;

            System.Array.Reverse(data, 0, 4);
            model.Data = BitConverter.ToUInt32(data, 0);
            return model;
        }

//数据长度	数据
//0AH	    22 … 22
        private IMetaModel parseLoggerID(byte[] data)
        {
            LoggerMetaModel model = new LoggerMetaModel();
            model.type = LoggerMetaModel.TYPE.LOGGERID;
            model.Data = data;
            return model;
        }

        private IMetaModel parseModemData(byte[] data)
        {
            LoggerMetaModel model = new LoggerMetaModel();
            model.type = LoggerMetaModel.TYPE.MODEM;
            ModemDataModel modem = new ModemDataModel();
            modem.baudRate = data[0];
            modem.parity = data[2];
            model.Data = modem;
            return model;
        }

//63	61 6E(an,无数据响应帧)
//50	00(无数据响应帧)
//75	72 65(re,连接状态响应帧)
//75	6E 6D(nm,Logger_ID)
//75	72 74(rt,Connection Timeout)
//75	72 74(rt,Response Timeout)
//75	72 6C(rl,URL)
//62	02(Modem)
//75	70 6C(pl,Sample Count)
//75	70 64(pd,Dail In Time)
//75	70 73(ps,Sample Origin)

        private IRequest[] genRead(IDataModel model)
        {
            Request[] reqs = new Request[11]{
                new Request(0x63, new byte[]{0x61, 0x6E}),
                new Request(0x50, new byte[]{0x00}),
                new Request(0x75, new byte[]{0x72, 0x65}),
                new Request(0x75, new byte[]{0x6E, 0x6D}),
                new Request(0x75, new byte[]{0x72, 0x74, 0x63}),
                new Request(0x75, new byte[]{0x72, 0x74, 0x72}),
                new Request(0x75, new byte[]{0x72, 0x6C}),
                new Request(0x62, new byte[]{0x02}),
                new Request(0x75, new byte[]{0x70, 0x6C}),
                new Request(0x75, new byte[]{0x70, 0x64}),
                new Request(0x75, new byte[]{0x70, 0x73})
            };
            return reqs;
        }

        private IRequest[] genWrite(IDataModel loggerModel)
        {
            if (loggerModel.Modified == false)
            {
                return new RequestWrapper(Request.createNullRequest()).getRequestArray();
            }
            List<IRequest> reqs = new List<IRequest>();
            reqs.AddRange(genModifyNoModem((LoggerDataModel)loggerModel));
            reqs.Add(genModifyModem((LoggerDataModel)loggerModel));
            return reqs.ToArray();
        }

        //AA FF(10) 00 7D DF 04 00 00 01 03 31 E7 C1 00 05 75 70 66 00 00 16 6E FF
        private IRequest[] genDelReading()
        {
            return new RequestWrapper(new Request(0x75, new byte[]{0x70, 0x66, 0x00, 0x00})).getRequestArray();
        }
    }
}
