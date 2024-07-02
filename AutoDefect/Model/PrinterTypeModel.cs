using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.Model
{
    public class PrinterTypeModel
    {
        public void SaveData(string data)
        {
            Properties.Settings.Default.PrinterType = data;
            Properties.Settings.Default.Save();
        }

        public string GetPrinterType()
        {
            return Properties.Settings.Default.PrinterType;
        }
    }
}
