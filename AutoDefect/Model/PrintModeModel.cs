using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.Model
{
    public class PrintModeModel
    {
        public void SaveData(string data)
        {
            Properties.Settings.Default.Mode = data;
            Properties.Settings.Default.Save();
        }

        public string GetMode()
        {
            return Properties.Settings.Default.Mode;
        }
    }
}
