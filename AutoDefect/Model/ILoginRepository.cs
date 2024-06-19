using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.Model
{
    public interface ILoginRepository
    {
        LoginModel GetUserByUsername(string username);
    }
}
