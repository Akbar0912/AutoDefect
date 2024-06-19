using AutoDefect._Repositories;
using AutoDefect.Model;
using AutoDefect.Presenter;
using AutoDefect.View;

namespace AutoDefect
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ILoginView loginView = new LoginView();
            ILoginRepository repository = new LoginRepository();
            new LoginPresenter(loginView, repository);
            Application.Run((Form)loginView);
        }
    }
}