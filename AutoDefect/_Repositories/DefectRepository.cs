using AutoDefect.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AutoDefect._Repositories
{
    public class DefectRepository : IDefectRepository
    {
        private string DbConnection;
        public DefectRepository()
        {
            DbConnection = ConfigurationManager.ConnectionStrings["LSBUDBConnectionQc"].ConnectionString;
        }

        public void Add(dynamic model)
        {
            using (var connection = new SqlConnection(DbConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = "INSERT INTO Defect_Results (DateTime, SerialNumber, ModelCode, DefectId, InspectorId, ModelNumber, PartId, LocationId) values (@DateTime, @SerialNumber, @ModelCode, @DefectId, @InspectorId, @ModelNumber, @PartId, @LocationId)";
                command.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = model.SerialNumber;
                command.Parameters.Add("@ModelCode", SqlDbType.VarChar).Value = model.ModelCode;
                command.Parameters.Add("@DefectId", SqlDbType.Int).Value = model.DefectId;
                command.Parameters.Add("@InspectorId", SqlDbType.VarChar).Value = model.InspectorId;
                command.Parameters.Add("@ModelNumber", SqlDbType.VarChar).Value = model.ModelNumber;
                command.Parameters.Add("@PartId", SqlDbType.Int).Value = model.PartId;
                command.Parameters.Add("@LocationId", SqlDbType.Int).Value = model.Location;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<DefectModel> GetAll()
        {
            var defectList = new List<DefectModel>();
            using (var connection = new SqlConnection(DbConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT Defect_Names.Id, Parts.Id AS PartId, Parts.PartName, Defect_Names.DefectName " +
                              "FROM Defect_Names " +
                              "INNER JOIN Parts ON Defect_Names.PartId = Parts.Id " +
                                "ORDER BY Priority DESC ,DefectName ASC";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //var defectModel = new DefectModel();
                        //defectModel.Id1 = int.Parse(reader[0].ToString());
                        //defectModel.PartId1 = reader[1].ToString();
                        //defectModel.DefectName1 = reader[2].ToString();
                        //defectList.Add(defectModel);
                        var defectModel = new DefectModel
                        {
                            Id1 = int.Parse(reader["Id"].ToString()),
                            PartId1 = int.Parse(reader["PartId"].ToString()),
                            PartName1 = reader["PartName"].ToString(),
                            DefectName1 = reader["DefectName"].ToString()
                        };
                        defectList.Add(defectModel);
                    }

                }
            }

            return defectList;
        }

        public IEnumerable<DefectResultModel> GetAllResult()
        {
            var resultList = new List<DefectResultModel>();
            using (var connection = new SqlConnection(DbConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText =
                    "SELECT " +
                    "    DR.Id, " +
                    "    DN.Id AS DefectId, " +
                    "    DR.DateTime, " +
                    "    DR.ModelNumber, " +
                    "    DR.ModelCode, " +
                    "    DR.SerialNumber, " +
                    "    P.PartName AS PartId, " +
                    "    L.LocationName AS LocationId, " +
                    "    DN.DefectName, " +
                    "    U.Name AS InspectorName " +
                    "FROM " +
                    "    Defect_Results DR " +
                    "INNER JOIN " +
                    "    LSBU_Auth.dbo.AspNetUsers U ON DR.InspectorId = U.NIK " +
                    "INNER JOIN " +
                    "   Parts P ON DR.PartId = P.Id " +
                    "INNER JOIN " +
                    "   LSBU_Common.dbo.Locations L ON DR.LocationId = L.Id " +
                    "INNER JOIN " +
                    "    Defect_Names DN ON DR.DefectId = DN.Id " +
                    "WHERE " +
                    "    CONVERT(date, DR.DateTime) = CONVERT(date, GETDATE())" +
                    "ORDER BY " +
                    "    DR.Id DESC";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dateTime = (DateTime)reader["DateTime"];
                        var resultModel = new DefectResultModel
                        {
                            Id = reader["Id"].ToString(),
                            Defect = reader["DefectName"].ToString(),
                            Date = dateTime.ToString("yyyy-MM-dd"),
                            Time = dateTime.ToString("HH:mm:ss"),
                            ModelNumber = reader["ModelNumber"].ToString(),
                            ModelCode = reader["ModelCode"].ToString(),
                            SerialNumber = reader["SerialNumber"].ToString(),
                            PartName = reader["PartId"].ToString(),
                            LocationId = reader["LocationId"].ToString(),
                            Inspector = reader["InspectorName"].ToString()
                        };
                        resultList.Add(resultModel);
                    }
                }
            }

            return resultList;
        }

        public IEnumerable<DefectModel> GetByValue(string value)
        {
            var defectList = new List<DefectModel>();
            int defectId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string defectName = value;
            using (var connection = new SqlConnection(DbConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * from Defect_Names 
                                        WHERE Id = @Id OR DefectName like @DefectName+'%'
                                        ORDER BY Id desc";
                command.Parameters.Add("@Id", SqlDbType.Int).Value = defectId;
                command.Parameters.Add("@DefectName", SqlDbType.VarChar).Value = defectName;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var defectModel = new DefectModel();
                        defectModel.Id1 = (int)reader[0];
                        defectModel.PartId1 = int.Parse(reader[1].ToString());
                        defectModel.DefectName1 = reader[2].ToString();
                        defectList.Add(defectModel);
                    }

                }
            }

            return defectList;
        }

        public IEnumerable<DefectModel> GetFilter(int id)
        {
            var defectList = new List<DefectModel>();
            using (var connection = new SqlConnection(DbConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT Defect_Names.Id, Parts.Id AS PartId, Parts.PartName, Defect_Names.DefectName " +
                              "FROM Defect_Names " +
                              "INNER JOIN Parts ON Defect_Names.PartId = Parts.Id " +
                               "WHERE Parts.ChartId = @selectedId " + "ORDER BY Parts.PartName ASC, Priority DESC";
                command.Parameters.AddWithValue("@selectedId", id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var defectModel = new DefectModel
                        {
                            Id1 = int.Parse(reader["Id"].ToString()),
                            PartId1 = int.Parse(reader["PartId"].ToString()),
                            PartName1 = reader["PartName"].ToString(),
                            DefectName1 = reader["DefectName"].ToString()
                        };
                        defectList.Add(defectModel);
                    }

                }
            }

            return defectList;
        }

        public IEnumerable<DefectResultModel> GetFilterResult(string defectName, DateTime selectedDate)
        {
            var resultList = new List<DefectResultModel>();
            using (var connection = new SqlConnection(DbConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText =
                    "SELECT " +
                    "    DR.Id, " +
                    "    DN.Id AS DefectId, " +
                    "    DR.DateTime, " +
                    "    DR.ModelNumber, " +
                    "    DR.ModelCode, " +
                    "    DR.SerialNumber, " +
                    "    P.PartName AS PartId, " +
                    "    L.LocationName AS LocationId, " +
                    "    DN.DefectName, " +
                    "    U.Name AS InspectorName " +
                    "FROM " +
                    "    Defect_Results DR " +
                    "INNER JOIN " +
                    "    LSBU_Auth.dbo.AspNetUsers U ON DR.InspectorId = U.NIK " +
                    "INNER JOIN " +
                    "   Parts P ON DR.PartId = P.Id " +
                    "INNER JOIN " +
                    "   LSBU_Common.dbo.Locations L ON DR.LocationId = L.Id " +
                    "INNER JOIN " +
                    "    Defect_Names DN ON DR.DefectId = DN.Id " +
                    "WHERE " +
                    "    DefectName LIKE @DefectName AND CAST(DR.DateTime AS DATE) = @SelectedDate " +
                    "ORDER BY " +
                    "    DR.Id DESC";
                command.Parameters.Add("@DefectName", SqlDbType.VarChar).Value = "%" + defectName + "%";
                command.Parameters.Add("@SelectedDate", SqlDbType.Date).Value = selectedDate.Date;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dateTime = (DateTime)reader["DateTime"];
                        var resultModel = new DefectResultModel
                        {
                            Id = reader["Id"].ToString(),
                            Defect = reader["DefectName"].ToString(),
                            Date = dateTime.ToString("yyyy-MM-dd"),
                            Time = dateTime.ToString("HH:mm:ss"),
                            ModelNumber = reader["ModelNumber"].ToString(),
                            ModelCode = reader["ModelCode"].ToString(),
                            SerialNumber = reader["SerialNumber"].ToString(),
                            LocationId = reader["LocationId"].ToString(),
                            PartName = reader["PartId"].ToString(),
                            Inspector = reader["InspectorName"].ToString()
                        };
                        resultList.Add(resultModel);
                    }
                }
            }

            return resultList;
        }
    }
}
