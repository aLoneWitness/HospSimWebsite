using System;
using System.Data;
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

        public void CloseConnection()
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
            OpenConnection();
            var mySqlCommand = new MySqlCommand(query, _databaseConnection);
            if (parameters != null)
            {
                mySqlCommand.Parameters.Clear();
                var i = 0;
                foreach (var param in parameters)
                {
                    mySqlCommand.Parameters.AddWithValue("param" + i, param);
                    i++;
                }
            }

            var dataReader = mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dataReader;
        }

        public MySqlDataReader Procedure(string procedure, params object[] parameters)
        {
            OpenConnection();

            var databaseQuery = new MySqlCommand(procedure, _databaseConnection);
            databaseQuery.CommandType = CommandType.StoredProcedure;

            foreach (var parameter in parameters)
                databaseQuery.Parameters.AddWithValue($"param{(Array.IndexOf(parameters, parameter) + 1).ToString()}",
                    parameter);


            var dataReader = databaseQuery.ExecuteReader(CommandBehavior.CloseConnection);
            return dataReader;
        }
        
    }
}