using System;
using System.Collections.ObjectModel;

namespace HexEditor.AdditionalClasses
{
    public class DataGridCell
    {
        public ObservableCollection<string> hexlist = new ObservableCollection<string>()
            { "00h","10h","20h","30h","40h","50h","60h","70h","80h","90h","A0h","B0h","C0h","D0h","E0h","F0h" };
        public string celldata { get; set; }

        public string _00 { get; set; }
        public string _01 { get; set; }
        public string _02 { get; set; }
        public string _03 { get; set; }
        public string _04 { get; set; }
        public string _05 { get; set; }
        public string _06 { get; set; }
        public string _07 { get; set; }
        public string _08 { get; set; }
        public string _09 { get; set; }
        public string _0A { get; set; }
        public string _0B { get; set; }
        public string _0C { get; set; }
        public string _0D { get; set; }
        public string _0E { get; set; }
        public string _0F { get; set; }

        public string hex { get; set; }



        public DataGridCell(string data, string oo, string o1, string o2, string o3, string o4, string o5,
            string o6, string o7, string o8, string o9, string oA, string oB, string oC, string oD, string oE,
            string oF, int index)
        {
            if (index < hexlist.Count)
            {
                hex = hexlist[index];
            }
            _00 = oo;
            _01 = o1;
            _02 = o2;
            _03 = o3;
            _04 = o4;
            _05 = o5;
            _06 = o6;
            _07 = o7;
            _08 = o8;
            _09 = o9;
            _0A = oA;
            _0B = oB;
            _0C = oC;
            _0E = oE;
            _0D = oD;
            _0F = oF;

            celldata = data;

        }
        public DataGridCell()
        {

        }

       
    }
}
