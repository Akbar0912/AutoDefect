using AutoDefect.Model;
using AutoDefect.View;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.Presenter
{
    public class LoginPresenter
    {
        ILoginView _loginView;
        ILoginRepository _loginRepository;

        public LoginPresenter(ILoginView view, ILoginRepository repository)
        {
            _loginView = view;
            _loginRepository = repository;
            _loginView.Login += Login;
            this._loginView.Show();
        }

        private void Login(object? sender, EventArgs e)
        {

            string nik = _loginView.Nik;
            string password = _loginView.Password;

            LoginModel user = _loginRepository.GetUserByUsername(nik);


            if (user != null)
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (isPasswordValid)
                {
                    _loginView.CloseView();
                    IMainForm mainForm = MainForm.GetInstance(user);
                    mainForm.Show();
                }
                else
                {
                    _loginView.ShowMessage("Password tidak valid");
                }

            }
            else
            {
                _loginView.ShowMessage("Data pengguna tidak ditemukan");
            }
        }
    }
}
