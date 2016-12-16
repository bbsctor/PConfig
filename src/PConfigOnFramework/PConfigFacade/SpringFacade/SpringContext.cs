using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Spring.Context.Support;
using ConfigFrame.AppInterface;
using ConfigFrame.CommunicationService.SerialPortSupport;
using ConfigFrame.ExceptionHandle;

namespace PConfigFacade.SpringFacade
{
    public class SpringContext
    {
        public static void initContext()
        {
            IApplicationContext context = ContextRegistry.GetContext();
            SerialPortAdapter serial = (SerialPortAdapter)context["serialAdapter"];
            serial.setFrameFormart(new byte[]{0xAA, 0xFF}, new byte[] {0xFF});
            Console.WriteLine("OK!");
        }

        public static void setLocalServerExceptionHandler(ExceptionHandler handler)
        {
            IApplicationContext context = ContextRegistry.GetContext();
            LocalRunningServer server = (LocalRunningServer)context["localRunningServer"];
            server.exceptionHandler = handler;
        }
    }
}
