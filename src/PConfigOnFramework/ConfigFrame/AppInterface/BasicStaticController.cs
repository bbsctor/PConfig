using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseService;
using ConfigFrame.Protocol;
using ConfigFrame.BaseModel;
using ConfigFrame.CommunicationService;

namespace ConfigFrame.AppInterface
{
    public class BasicStaticController : BasicController, IStaticController
    {

        protected ICommunicationService cService;

        public ICommunicationService CommService
        {
            get { return cService; }
            set { this.cService = value; }
        }

        public override void execute(string action)
        {
            base.execute(action);
            IRequest[] reqs = ModelProtocolService.
                        genRequestByActionName(Target, Model);
            IResponse[] resp = cService.processRequestBatch(reqs);

            for (int i = 0; i < resp.Length; i++)
            {
                IMetaModel model = ModelProtocolService.handleResponse(resp[i]);
                handleResult(model);
            }
        }

        public override void sendOnly(string action)
        {
            IRequest[] reqs = ModelProtocolService.
                        genRequestByActionName(Target, Model);
            cService.sendOnly(reqs);
        }
    }
}
