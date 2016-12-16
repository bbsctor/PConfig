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
    public class ClockService : BasicService
    {
        static int times = 1;
        public override IRequest[] genRequestByActionName(string action, IDataModel dModel)
        {
            ClockDataModel model = dModel as ClockDataModel;
            switch (action)
            {
                case "read":
                    return genRead(model);
                case "write":
                    return genWrite(model);
                case "queryProbeTime":
                    return genQueryTime();
                case "querySamplingInterval":
                    return genQuerySamplingInterval();
                case "setSamplingInterval":
                    return genSettingSamplingInterval(model);
                    
            }
            return null;
        }

//数据长度	功能码
//01H	    74H
        private IRequest[] genQueryTime()
        {
            //return new RequestWrapper(new Request_74()).getRequestArray();
            return new RequestWrapper(new Request(0x74, null)).getRequestArray();
        }

//数据长度	功能码	数据
//                  Sampling Interval
//05H	    49H	    4Byte
        private IRequest[] genSettingSamplingInterval(ClockDataModel model)
        {
            Request req = new Request();
            req.func = 0x49;
            req.dataLength = 0x05;
            byte[] temp = BitConverter.GetBytes(model.samplingInterval);
            System.Array.Reverse(temp, 0, 4);
            req.Data = temp;
            return new RequestWrapper(req).getRequestArray();
        }

        private IRequest[] genQuerySamplingInterval()
        {
            //return new RequestWrapper(new Request_69()).getRequestArray();
            return new RequestWrapper(new Request(0x69, null)).getRequestArray();
        }

        public override IMetaModel handleResponse(IResponse resp)
        {
            MetaModel model = null;

            if (((Request)(resp.Request)).func == 0x74)
            {
                return parseTimeData((Response)resp);
            }
            else if (((Request)(resp.Request)).func == 0x69)
            {
                return parseIntervalData((Response)resp);
            }

            return model;
        }

        public MetaModel parseTimeData(Response resp)
        {
            ClockMetaModel mModel = new ClockMetaModel();
            mModel.type = ClockMetaModel.TYPE.DATETIME;
            TimeDataModel time = PDTimeConverter.parseTimeData(resp);

            mModel.Data = time;
            return mModel;
        }

        public MetaModel parseIntervalData(Response resp_69)
        {
            ClockMetaModel mModel = new ClockMetaModel();
            mModel.type = ClockMetaModel.TYPE.SAMPLINGINTERVAL;
            ClockDataModel model = new ClockDataModel();
            //byte[] temp = resp_69.getPara("samplingInterval");
            byte[] temp = resp_69.Data;
            System.Array.Reverse(temp, 0, 4);
            uint interval = BitConverter.ToUInt32(temp , 0);
            mModel.Data = interval;
            return mModel;
        }

        private IRequest[] genRead(IDataModel clockModel)
        {
            List<IRequest> reqs = new List<IRequest>();
            reqs.AddRange(genQuerySamplingInterval());
            reqs.AddRange(genQueryTime());
            return reqs.ToArray();
        }

        private IRequest[] genWrite(IDataModel clockModel)
        {
            if (clockModel.Modified == false)
            {
                return new RequestWrapper(Request.createNullRequest()).getRequestArray();
            }
            ClockDataModel model = clockModel as ClockDataModel;
            List<IRequest> reqs = new List<IRequest>();
            if (clockModel.ModifiedFieldList.Contains("samplingInterval") == true)
            {
                reqs.AddRange(genSettingSamplingInterval(model));
            }
            if (clockModel.ModifiedFieldList.Contains("timeModel") == true)
            {
                reqs.AddRange(genSettingTime(model.timeModel));
            }

            return reqs.ToArray();
        }

        private IRequest[] genSettingTime(TimeDataModel time)
        {
            return new RequestWrapper(PDTimeConverter.genSettingTime(time)).getRequestArray();
        }

        public override IRequest[] genIdleRequest()
        {
            return genQueryTime();
        }
    }
}
