using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Spring.Context.Support;
using PConfigBase.Status;

namespace PConfigFacade.SpringFacade
{
    public class StatusManagerProvider
    {
        public static StatusManager getSatatusManager()
        {
            IApplicationContext context = ContextRegistry.GetContext();
            return (StatusManager)context["statusManager"];
        }
    }
}
