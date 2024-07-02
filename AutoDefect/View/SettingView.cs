using AutoDefect.Model;
using AutoDefect.Presenter;
using AutoDefect._Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace AutoDefect.View
{
    public partial class SettingView : Form, ISettingView
    {
        private static SettingView instance;
        private bool isInitializing;
        private string lastMode = "";
        private readonly IMainForm mainForm;
        private readonly PrintModeModel _printMode;

        public SettingView()
        {
            InitializeComponent();
            InitializeEventHandler();
            _printMode = new PrintModeModel();
            LoadRadioSettings();
            Load += SettingView_Load;
            LoadPrinters();
        }

        private void LoadPrinters()
        {
            try
            {
                // Clear existing items
                printerBox.Items.Clear();

                // Get the list of installed printers and add them to the ComboBox
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    printerBox.Items.Add(printer);
                }

                // Optionally set the selected item to the default printer
                PrinterSettings settings = new PrinterSettings();
                if (printerBox.Items.Contains(settings.PrinterName))
                {
                    printerBox.SelectedItem = settings.PrinterName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading printers: " + ex.Message);
            }
        }

        private void LoadRadioSettings()
        {
            btnOn.Checked = Properties.Settings.Default.Mode == "on";
            btnOff.Checked = Properties.Settings.Default.Mode == "off";
            btnPreview.Checked = Properties.Settings.Default.Mode == "preview";
        }

        public List<string> LocationNames
        {
            get => locationBox.DataSource as List<string>;
            set => locationBox.DataSource = value;
        }
        public string ipaddress
        {
            get => textBoxIP.Text;
            set => textBoxIP.Text = value;
        }
        public string portaddress
        {
            get => textBoxPort.Text;
            set => textBoxPort.Text = value;
        }
        public string mode
        {
            get;
            set;
        }

        public event EventHandler SelectedIndexChanged;
        public event EventHandler SaveIPSettings;
        public event EventHandler SavePortSettings;
        public event EventHandler LoadIP;
        public event EventHandler LoadPort;
        public event EventHandler LoadLocation;
        public event EventHandler HandleRadioButton;
        public event EventHandler SelectedPrinterType;
        public event EventHandler LoadPrinterType;

        public void DisplayIP(string IPaddress)
        {
            textBoxIP.Text = IPaddress;
        }

        public void DisplayPort(int portAddress)
        {
            textBoxPort.Text = portAddress.ToString();
        }

        public void DisplaySetting(string locationName)
        {
            locationBox.Text = locationName;
        }

        public static SettingView GetInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new SettingView();
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        private void InitializeEventHandler()
        {
            locationBox.SelectedIndexChanged += (sender, e) =>
            {
                if (!isInitializing)
                {
                    SelectedIndexChanged?.Invoke(sender, e);
                }
            };

            textBoxIP.TextChanged += (sender, e) =>
            {
                SaveIPSettings?.Invoke(this, EventArgs.Empty);
            };

            textBoxPort.TextChanged += (sender, e) =>
            {
                SavePortSettings?.Invoke(this, EventArgs.Empty);
            };

            btnConnect.Click += delegate
            {
                this.Close();
                ILoginView loginView = new LoginView();
                LoginPresenter loginPresenter = new LoginPresenter(loginView, new LoginRepository());
                (loginView as Form)?.Show();
            };

            btnOn.CheckedChanged += (sender, e) =>
            {
                if (btnOn.Checked && lastMode != "on")
                {
                    mode = "on";
                    lastMode = "on";
                    HandleRadioButton?.Invoke(sender, e);
                }
            };

            btnOff.CheckedChanged += (sender, e) =>
            {
                if (btnOff.Checked && lastMode != "off")
                {
                    mode = "off";
                    lastMode = "off";
                    HandleRadioButton?.Invoke(sender, e);
                }
            };

            btnPreview.CheckedChanged += (sender, e) =>
            {
                if (btnPreview.Checked && lastMode != "preview")
                    mode = "preview";
                lastMode = "preview";
                HandleRadioButton?.Invoke(sender, e);
            };

            btnClose.Click += delegate
            {
                this.Close();
            };

            printerBox.SelectedIndexChanged += (sender, e) =>
            {
                if(!isInitializing)
                {
                    SelectedPrinterType?.Invoke(sender, e);
                }
            };
        }

        private void SettingView_Load(object sender, EventArgs e)
        {
            isInitializing = true;
            LoadLocation?.Invoke(this, EventArgs.Empty);
            LoadIP?.Invoke(this, EventArgs.Empty);
            LoadPort?.Invoke(this, EventArgs.Empty);
            LoadPrinterType?.Invoke(this, EventArgs.Empty);
            isInitializing = false;
        }

        public void DsiplayPrinterType(string printerType)
        {
            printerBox.Text = printerType;
        }
    }
}
