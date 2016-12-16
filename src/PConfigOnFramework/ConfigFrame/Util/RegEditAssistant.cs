using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace ConfigFrame.Util
{
    public class RegEditAssistant
    {
        public static RegistryKey createKey(RegistryKey root ,String[] path)
        {
            RegistryKey temp = root;
            if (root != null && path.Length > 0)
            {
                for (int i = 0; i < path.Length; i++)
                {
                    temp = temp.CreateSubKey(path[i]);
                }
                return temp;
            }
            else
            {
                return null;
            }
        }

        public static RegistryKey searchKey(RegistryKey root ,String[] path)
        {
            RegistryKey temp = root;
            if (root != null && path.Length > 0)
            {
                for (int i = 0; i < path.Length; i++)
                {
                    temp = temp.OpenSubKey(path[i]);
                    if (temp == null)
                    {
                        return temp;
                    }
                }
                return temp;
            }
            else
            {
                return null;
            }
        }
    }
}
