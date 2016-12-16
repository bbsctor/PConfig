using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PConfigUI.UIUtil
{
    class DecorateTextAssitor
    {
        public static void decorateText(Control control, System.Drawing.Color foreColor)
        {
            if (control.Text.EndsWith("*") == false)
            {
                control.ForeColor = foreColor;
                control.Text = control.Text + "*";
            }
        }

        public static void undecorateText(Control control)
        {
            if (control.ForeColor == System.Drawing.Color.Red || control.Text.EndsWith("*") == true)
            {
                control.ForeColor = System.Drawing.Color.Black;
                control.Text = control.Text.Substring(0, control.Text.Length - 1);
            }
        }
    }
}
