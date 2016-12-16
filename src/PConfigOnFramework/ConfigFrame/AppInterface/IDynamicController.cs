using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.Protocol;

namespace ConfigFrame.AppInterface
{
    public interface IDynamicController:IController
    {
        IRequest[] genIdleRequest();
    }
}
