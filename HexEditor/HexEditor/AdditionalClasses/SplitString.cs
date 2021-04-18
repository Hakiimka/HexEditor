using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexEditor.AdditionalClasses
{
    public static class SplitString
    {

        public static List<string> PerformSplit(string str)
        {
            List<string> list = new List<string>();
            int i = 0;
            while (i < str.Length - 1)
            {
                list.Add(str.Substring(i, 2));
                i += 2;
            }
            for (int j = 0; j < 16; j++)
            {
                list.Add("00");
            }
            return list;
        }
    }
}
