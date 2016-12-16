using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PConfigUI.UIUtil
{
    public class SingleChangeAssistor
    {
        public static bool alertChange(Control actor, Control listener, string origin)
        {
            if (actor.Text != "" && actor.Text.Equals(origin) == false)
            {
                DecorateTextAssitor.decorateText(listener, System.Drawing.Color.Red);
                return true;
            }
            else if (actor.Text != "" && actor.Text.Equals(origin) == true)
            {
                DecorateTextAssitor.undecorateText(listener);
                return false;
            }
            return false;
        }

        public static void removeChange(Control control)
        {
            if (control.ForeColor == System.Drawing.Color.Red || control.Text.EndsWith("*"))
            {
                control.ForeColor = System.Drawing.Color.Black;
                control.Text = control.Text.Substring(0, control.Text.Length - 1);
            }
        }
    }
}
