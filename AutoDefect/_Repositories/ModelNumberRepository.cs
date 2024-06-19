using AutoDefect.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect._Repositories
{
    public class ModelNumberRepository : IModelNumberRepository
    {
        private string DbConnection;

        public ModelNumberRepository()
        {
            DbConnection = ConfigurationManager.ConnectionStrings["LSBUDBConnectionCommon"].ConnectionString;
        }

        public ModelCode GetModelNumber(ModelCode model)
        {
            ModelCode modelCode = null;

            using (var connection = new SqlConnection(DbConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM GlobalModelCodes WHERE modelCodeId = @modelCode";
                command.Parameters.Add("@modelCode", SqlDbType.VarChar).Value = model.modelCode1;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        modelCode = new ModelCode();
                        modelCode.ModelNumber = reader["ModelNumber"].ToString();
                        modelCode.modelCode1 = reader["modelCodeId"].ToString();
                    }
                }
            }

            return modelCode;
        }
    }
}
