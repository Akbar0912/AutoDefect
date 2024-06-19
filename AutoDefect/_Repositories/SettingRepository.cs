using AutoDefect.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect._Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private string DbConnection;
        private int locationId;

        public SettingRepository()
        {
            DbConnection = ConfigurationManager.ConnectionStrings["LSBUDBConnectionCommon"].ConnectionString;
        }

        public List<string> GetData()
        {
            List<string> dataList = new List<string>();

            using (SqlConnection connection = new SqlConnection(DbConnection))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Locations";
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dataList.Add(reader["LocationName"].ToString());
                    }

                    reader.Close();
                }
            }
            return dataList;
        }

        public int GetID(string locationName)
        {
            using (SqlConnection connection = new SqlConnection(DbConnection))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id FROM Locations WHERE LocationName = @LocationName";
                    command.Parameters.AddWithValue("@LocationName", locationName);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        locationId = Convert.ToInt32(reader["Id"]);
                    }

                    reader.Close();
                }
            }
            return locationId;
        }
    }
}
