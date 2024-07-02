using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.View
{
    public interface ISettingView
    {
        List<string> LocationNames { get; set; }
        string ipaddress { get; set; }
        string portaddress { get; set; }
        string mode { get; set; }

        event EventHandler SelectedIndexChanged;
        event EventHandler SaveIPSettings;
        event EventHandler SavePortSettings;
        event EventHandler LoadIP;
        event EventHandler LoadPort;
        event EventHandler LoadLocation;
        event EventHandler HandleRadioButton;
        event EventHandler SelectedPrinterType;
        event EventHandler LoadPrinterType;

        //void DisplayName(string JPName);
        void DisplayIP(string IPaddress);
        void DisplayPort(int portAddress);
        void DisplaySetting(string locationName);
        void DsiplayPrinterType(string printerType);
    }
}
