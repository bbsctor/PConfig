using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.AppInterface;
using Spring.Context;
using Spring.Context.Support;

namespace PConfigFacade.SpringFacade
{
    public class ContextProvider
    {
        public static IController getControllerByName(string name)
        {
            IApplicationContext context = ContextRegistry.GetContext();
            return (IController)context[name];
        }
    }
}
