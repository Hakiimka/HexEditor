using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;


namespace HexEditor.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        #region
        public event PropertyChangedEventHandler PropertyChanged;
        private AdditionalClasses.DataGridCell cell;
        private AdditionalClasses.DataGridCell secondcell;

        public ObservableCollection<AdditionalClasses.DataGridCell> celllist { get; set; }
        public ObservableCollection<AdditionalClasses.DataGridCell> secondcelllist { get; set; }

        private FileStream stream;
        private byte checksum;
        private byte[] lastbyte;
        private SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        public string hextext = "123";
        private string labeltext="Откройте файл";
        private byte[] bytes;
        private Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

        #endregion // Variables

        #region
        private Nullable<bool> OpenFile()
        {
            try
            {
                dlg.FileName = "HexText";
                dlg.DefaultExt = ".bin";
                dlg.Filter = "Bin files (.bin)|*.bin";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                    stream = new FileStream(filename, FileMode.Open);
                    StreamReader reader = new StreamReader(stream);
                    bytes = Encoding.Default.GetBytes(reader.ReadToEnd());
                    checksum = CheckSum(bytes);
                    hextext = ByteArrayToString(bytes);
                    stream.Close();
                }
                return result;
            }
            catch { MessageBox.Show("Произошла ошибка"); return null; }
        }
        private void SaveFile()
        {
            try
            {
                saveFileDialog1.Filter = "bin files (*.bin)|*.bin";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog1.FileName, AdditionalClasses.TableToString.ConvertToString(secondcelllist));
                }
                MessageBox.Show("Сохранено успешно!");
            }
            catch { MessageBox.Show("Произошла ошибка"); }
        }

        private byte CheckSum(byte[] array)
        {
            byte chksum = 0;
            foreach (byte data in array)
            {
                chksum += data;
            }
            return chksum;
        }



        public string HEX2ASCII(string hex)
        {
            string res = String.Empty;
            for (int a = 0; a < hex.Length; a = a + 2)
            {
                string Char2Convert = hex.Substring(a, 2);
                int n = Convert.ToInt32(Char2Convert, 16);
                char c = (char)n;
                res += c.ToString();
            }
            return res;
        }


        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }


        private void CopyTable()
        {
            for (int i = 0; i < celllist.Count; i++)
            {
                secondcelllist.Add(celllist[i]);
            }
        }
        private void FillFirstTable()
        {
            try
            {
                if (celllist != null || secondcelllist != null)
                {
                    celllist.Clear();
                    secondcelllist.Clear();
                }
                List<string> temp = AdditionalClasses.SplitString.PerformSplit(hextext);
                int div = temp.Count / 15; int step = 15;
                int stop = step * div;
                int hexindex = 0;
                for (int i = 0; i < temp.Count; i++)
                {
                    if (i >= stop - 15) { break; }

                    celllist.Add(new AdditionalClasses.DataGridCell(temp[i], temp[i], temp[i + 1], temp[i + 2], temp[i + 3],
                       temp[i + 4], temp[i + 5], temp[i + 6], temp[i + 7], temp[i + 8], temp[i + 9], temp[i + 10],
                       temp[i + 11], temp[i + 12], temp[i + 13], temp[i + 14]
                       , temp[i + 15], hexindex));

                    i += 15;
                    hexindex++;
                }

                lastbyte = Encoding.Default.GetBytes(celllist[celllist.Count - 1]._0F);
                Label= "Выберите ячейку,значение которой хотите изменить,затем нажмите кнопку \"Сохранить\"";
                MessageBox.Show("Конвертация прошла успешно");
            }
            catch { MessageBox.Show("Произошла ошибка"); }

        }

        private void HexTableToANSI()
        {

            for (int i = 0; i < celllist.Count; i++)
            {
                SecondCellList[i]._00 = HEX2ASCII(secondcelllist[i]._00);
                SecondCellList[i]._01 = HEX2ASCII(secondcelllist[i]._01);
                SecondCellList[i]._02 = HEX2ASCII(secondcelllist[i]._02);
                SecondCellList[i]._03 = HEX2ASCII(secondcelllist[i]._03);
                SecondCellList[i]._04 = HEX2ASCII(secondcelllist[i]._04);
                SecondCellList[i]._05 = HEX2ASCII(secondcelllist[i]._05);
                SecondCellList[i]._06 = HEX2ASCII(secondcelllist[i]._06);
                SecondCellList[i]._07 = HEX2ASCII(secondcelllist[i]._07);
                SecondCellList[i]._08 = HEX2ASCII(secondcelllist[i]._08);
                SecondCellList[i]._09 = HEX2ASCII(secondcelllist[i]._09);
                SecondCellList[i]._0A = HEX2ASCII(secondcelllist[i]._0A);
                SecondCellList[i]._0B = HEX2ASCII(secondcelllist[i]._0B);
                SecondCellList[i]._0C = HEX2ASCII(secondcelllist[i]._0C);
                SecondCellList[i]._0D = HEX2ASCII(secondcelllist[i]._0D);
                SecondCellList[i]._0E = HEX2ASCII(secondcelllist[i]._0E);
                SecondCellList[i]._0F = HEX2ASCII(secondcelllist[i]._0F);
            }

        }
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion // Functions

        #region

        public string Label
        {
            get { return labeltext; }
            set { labeltext = value; OnPropertyChanged("Label"); }
        }

        public string Hex
        {
            get { if (hextext == null) hextext = ByteArrayToString(bytes); return hextext; }
            set { hextext = value; OnPropertyChanged("Hex"); }
        }
        public AdditionalClasses.DataGridCell Cell
        {
            get { return cell; }
            set { cell = value; OnPropertyChanged("Cell"); }
        }
        public AdditionalClasses.DataGridCell SecondCell
        {
            get { return secondcell; }
            set { secondcell = value; OnPropertyChanged("SecondCell"); }
        }
        public ObservableCollection<AdditionalClasses.DataGridCell> CellList
        {
            get { if (celllist == null) { celllist = new ObservableCollection<AdditionalClasses.DataGridCell>(); } return celllist; }
            set { celllist = value; OnPropertyChanged("CellList"); }
        }

        public ObservableCollection<AdditionalClasses.DataGridCell> SecondCellList
        {
            get { if (secondcelllist == null) { secondcelllist = new ObservableCollection<AdditionalClasses.DataGridCell>(); } return secondcelllist; }
            set { secondcelllist = value; OnPropertyChanged("SecondCellList"); }
        }

        public AdditionalClasses.MyCommand OpenFileButton
        {
            get { return new AdditionalClasses.MyCommand((o) => { if ((bool)OpenFile()) { FillFirstTable(); CopyTable(); HexTableToANSI(); } }); }
        }
        public AdditionalClasses.MyCommand CheckButton
        {
            get
            {
                return new AdditionalClasses.MyCommand((o) =>
                {
                    if (lastbyte != null & checksum != 0)
                    {
                        if (lastbyte[0] == checksum && lastbyte != null)
                            MessageBox.Show($"Последний байт и чек сумма равны: {checksum}");
                        else
                            MessageBox.Show($"Последний байт и чек сумма не равны\n пересчет чек суммы: {checksum}");
                    }
                    else { MessageBox.Show("Невозможно посчитать чек сумму"); }
                });
            }
        }
        public AdditionalClasses.MyCommand SaveButton
        {
            get { return new AdditionalClasses.MyCommand((o) => { SaveFile(); }); }
        }
    }
    #endregion // Get/Set/Commands
}
