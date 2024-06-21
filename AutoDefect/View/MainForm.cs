using AutoDefect._Repositories;
using AutoDefect.Model;
using AutoDefect.Presenter;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AutoDefect.View
{
    public partial class MainForm : Form, IMainForm
    {
        private static MainForm instance;
        public LoginModel _user;
        private TabControlPresenter tabControlPresenter;
        private TCPConnection connection;
        private TabControlView tabControlView;


        public MainForm(LoginModel user)
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            _user = user;
            InitializeTabControl();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnHome.Click += delegate
            {
                int selectedTabPageIndex = 0;
                tabControlPresenter.ChangeTabPage(selectedTabPageIndex);
                btnHome.BackColor = Color.FromArgb(77, 134, 156);
                btnRePrint.BackColor = Color.Teal;
            };

            btnSetting.Click += delegate
            {

                ISettingView settingView = SettingView.GetInstance();
                SettingPresenter settingPresenter = new SettingPresenter(settingView, new SettingModel());
                (settingView as Form)?.Show();
            };

            btnRePrint.Click += delegate
            {
                int selectedTabPageIndex = 1;
                tabControlPresenter.ChangeTabPage(selectedTabPageIndex);
                btnRePrint.BackColor = Color.FromArgb(77,134,156);
                btnHome.BackColor = Color.Teal;
            };

            btnLogOut.Click += delegate
            {
                connection.CloseConnection();

                tabControlPresenter.UnassociateViewEvents();
                //ResetBinding();

                this.Close();

                ILoginView loginView = new LoginView();
                LoginPresenter loginPresenter = new LoginPresenter(loginView, new LoginRepository());
                (loginView as Form)?.Show();
            };
        }

        //private void ResetBinding()
        //{
        //    tabControlPresenter.ResetDataBinding();
        //}

        private void InitializeTabControl()
        {
            if (tabControlPresenter != null)
            {
                tabControlPresenter.UnassociateViewEvents(); // Tambahkan ini untuk menghapus event handler yang ada
            }

            tabControlView = new TabControlView(); // Create the user control instance
            TabControlDataPresenter presenterData = new TabControlDataPresenter(tabControlView, new DefectRepository(), _user); // Inisialisasi variabel instance
            tabControlPresenter = new TabControlPresenter(presenterData);
            splitContainer1.Panel2.Controls.Add(tabControlView);
            tabControlView.Dock = DockStyle.Fill;
            connection = new TCPConnection(tabControlView.UpdateCodeBox, tabControlView.UpdateSerialBox);
        }

        public static MainForm GetInstance(LoginModel loginModel)
        {
            if (instance == null || instance.IsDisposed)
                instance = new MainForm(loginModel);
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
                instance._user = loginModel; // Set new user
                instance.InitializeTabControl();
            }
            return instance;
        }
    }
}
