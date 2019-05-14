using System;
using System.Collections.Generic;
using System.Data;
using HospSimWebsite.DAL.MySQL.HospSimWebsite;
using Microsoft.EntityFrameworkCore.Internal;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.DAL.MySQL
{
    public class Database
    {
        private MySqlConnection _databaseConnection;
        public void SetConnection(string conString)
        {
            _databaseConnection = new MySqlConnection(conString);
        }

        private void OpenConnection()
        {
            try
            {
                _databaseConnection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Could not connect to database");
            }
        }

        private void CloseConnection()
        {
            try
            {
                _databaseConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Could not disconnect from database");
            }
        }

        public MySqlDataReader Query(string query, params object[] parameters)
        {
            var queryResultList = new List<QueryResult>();
            OpenConnection();
            var mySqlCommand = new MySqlCommand(query, _databaseConnection);
            if (parameters != null)
                foreach (var param in parameters)
                    mySqlCommand.Parameters.AddWithValue("param" + parameters.IndexOf(param), param);
            /* var type = param.GetType().FullName;
                switch (type)
                {
                    case "System.String":
                        mySqlCommand.Parameters.AddWithValue("param" + index, parameters[index - 1], );
                        

                        break;
                    case "System.Integer":
                        mySqlCommand.Parameters.AddWithValue("param" + index, parameters[index - 1]);

                        break;
                    default:
                        break;
                }*/
            var dataReader = mySqlCommand.ExecuteReader();
            CloseConnection();
            return dataReader;
        }

        public MySqlDataReader Procedure(string procedure, params object[] parameters)
        {
            var databaseQuery = new MySqlCommand(procedure, _databaseConnection);
            databaseQuery.CommandType = CommandType.StoredProcedure;

            foreach (var parameter in parameters)
                databaseQuery.Parameters.AddWithValue($"param{(Array.IndexOf(parameters, parameter) + 1).ToString()}",
                    parameter);


            OpenConnection();

            var dataReader = databaseQuery.ExecuteReader();
            CloseConnection();

            return dataReader;

        }
    }
}