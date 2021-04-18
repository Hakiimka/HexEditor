using System.Collections.ObjectModel;

namespace HexEditor.AdditionalClasses
{
    public static class TableToString
    {
        public static string ConvertToString(ObservableCollection<DataGridCell> list)
        {
            string convertedtable = "";
            for (int i = 0; i < list.Count; i++)
            {
                convertedtable += list[i]._00;
                convertedtable += list[i]._01;
                convertedtable += list[i]._02;
                convertedtable += list[i]._03;
                convertedtable += list[i]._04;
                convertedtable += list[i]._05;
                convertedtable += list[i]._06;
                convertedtable += list[i]._07;
                convertedtable += list[i]._08;
                convertedtable += list[i]._09;
                convertedtable += list[i]._0A;
                convertedtable += list[i]._0B;
                convertedtable += list[i]._0C;
                convertedtable += list[i]._0D;
                convertedtable += list[i]._0E;
                convertedtable += list[i]._0F;
            }
            return convertedtable;
        }

    }
}
