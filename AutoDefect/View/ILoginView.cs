using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.View
{
    public interface ILoginView
    {
        string Name { get; set; }
        string Nik { get; set; }
        string Password { get; set; }
        bool IsLoggedIn { get;}

        event EventHandler Login;

        void ShowMessage (string message);
        void CloseView();
        void Show();


    }
}
