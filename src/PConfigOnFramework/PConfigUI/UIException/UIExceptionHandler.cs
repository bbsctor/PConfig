using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ConfigFrame.ExceptionHandle;

namespace PConfigUI.UIException
{
    public class UIExceptionHandler:ExceptionHandler
    {
        public static MainFrame frame;
        public UIExceptionHandler(MainFrame mframe)
        {
            frame = mframe;
            handle = handleException;
        }
        private static void handleException(Exception e)
        {
            if (e.GetType() == typeof(TimeoutException))
            {
                MessageBox.Show("连接超时!");
            }
            else if (e.GetType() == typeof(ThreadAbortException))
            {

            }
            else
            {
                MessageBox.Show("未知错误！");
            }
        }
    }
}
