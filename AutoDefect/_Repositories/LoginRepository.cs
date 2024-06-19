using AutoDefect.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AutoDefect._Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private string DbConnectionAuth;

        public LoginRepository()
        {
            DbConnectionAuth = ConfigurationManager.ConnectionStrings["LSBUDBConnectionAuth"].ConnectionString;
        }

        public LoginModel GetUserByUsername(string username)
        {
            using (var connetion = new SqlConnection(DbConnectionAuth))
            using (var command = new SqlCommand())
            {
                connetion.Open();
                command.Connection = connetion;
                command.CommandText = "SELECT PasswordHash, NIK, Name FROM AspNetUsers WHERE NIK = @NIK";
                command.Parameters.Add("@NIK", SqlDbType.Int).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        string Nik = reader["NIK"].ToString();
                        string Name = reader["Name"].ToString();
                        string Password = reader["PasswordHash"].ToString();

                        return new LoginModel { Nik = Nik, Name = Name, Password = Password };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
