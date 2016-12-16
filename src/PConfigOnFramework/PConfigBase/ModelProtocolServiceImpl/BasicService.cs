using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;
using ConfigFrame.Protocol;
using ConfigFrame.BaseService;

namespace PConfigBase.ModelProtocolServiceImpl
{
    public class BasicService : IModelProtocolService
    {
        public virtual IRequest[] genIdleRequest()
        {
            ProbeInfoService pService = new ProbeInfoService();
            return pService.genRead(null);
        }

        public virtual IRequest[] genRequestByActionName(string action, IDataModel dModel)
        {
            return null;
        }

        public virtual IMetaModel handleResponse(IResponse response)
        {
            return null;
        }
    }
}
