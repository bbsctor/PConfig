using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PConfigUI.UIUtil;

namespace PConfigUI.UIUtil
{
    public class MultiChangeAssistor
    {
        public static void alertChange(Control[] actors, Control listener)
        {
            bool isChanged = false;
            for (int i = 0; i < actors.Length; i++)
            {
                if (actors[i].Text.EndsWith("*") == true)
                {
                    isChanged = true;
                    break;
                }
            }
            if (isChanged == true)
            {
                DecorateTextAssitor.decorateText(listener, System.Drawing.Color.Black);
            }
            else if (isChanged == false)
            {
                DecorateTextAssitor.undecorateText(listener);
            }
        }

        public static void removeChange(Control mainControl, Control[] subControls)
        {
            for (int i = 0; i < subControls.Length; i++)
            {
                SingleChangeAssistor.removeChange(subControls[i]);
            }
            SingleChangeAssistor.removeChange(mainControl);
        }
    }
}
