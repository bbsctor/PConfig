using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.AppInterface;
using ConfigFrame.BaseModel;
using ConfigFrame.BaseService;
using ConfigFrame.Protocol;

namespace ConfigFrame.AppInterface
{
    public class BasicController
    {
        protected Type modelType;
        protected IDataModel model;
        protected IModelProtocolService dService;
        protected string target;

        public Type ModelType
        {
            get { return modelType; }
            set { this.modelType = value; }
        }

        public IDataModel Model
        {
            get { return model; }
            set { this.model = value; }
        }

        public IModelProtocolService ModelProtocolService
        {
            get { return dService; }
            set { this.dService = value; }
        }

        public string Target
        {
            get { return target; }
            set { this.target = value; }
        }

        public void resetDataModel()
        {
            this.model = (IDataModel)ModelRepository.getModelByType(modelType);
        }

        public void setType(Type type)
        {
            this.modelType = type;
        }

        public virtual void execute(string action)
        {
            resetDataModel();
            this.target = action;
        }

        public virtual void sendOnly(string action)
        {

        }

        public virtual void handleResult(IMetaModel dModel)
        {

        }
    }
}
