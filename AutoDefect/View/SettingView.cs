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
            //Load += (sender, e) => LoadLocation?.Invoke(sender, e);
            Load += SettingView_Load;
        }

        private void LoadRadioSettings()
        {
            btnOn.Checked = Properties.Settings.Default.Mode == "on";
            btnOff.Checked = Properties.Settings.Default.Mode == "off";
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
            btnClose.Click += delegate
            {
                this.Close();
            };
        }

        private void SettingView_Load(object sender, EventArgs e)
        {
            isInitializing = true;
            LoadLocation?.Invoke(this, EventArgs.Empty);
            LoadIP?.Invoke(this, EventArgs.Empty);
            LoadPort?.Invoke(this, EventArgs.Empty);
            isInitializing = false;
        }
    }
}
