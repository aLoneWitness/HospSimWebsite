using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;

namespace HospSimWebsite
{
    public sealed class Database
    {

        private static readonly Lazy<Database> database = new Lazy<Database>(() => new Database());

        public static Database Instance { get { return database.Value; } }

        private MySqlConnection _databaseConnection;

        static Database()
        {
            
        }

        public void SetConnection(string host, string username, string password, string database)
        {
            _databaseConnection = new MySqlConnection("server=" + host + ";user id=" + username + ";password=" + password + ";database=" + database);
        }

        private void OpenConnection()
        {
            try
            {
                _databaseConnection.Open();                
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                throw new Exception("Could not connect to database");
            }
        }

        private void CloseConnection()
        {
            try
            {
                _databaseConnection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw new Exception("Could not disconnect from database");
            }
        }

        public List<QueryResult> Query(string query, string[] parameters)
        {
            List<QueryResult> results = new List<QueryResult>();
            OpenConnection();
            MySqlCommand databaseQuery = new MySqlCommand(query, _databaseConnection);

            if (parameters != null)
            {
                for (var i = 1; i < parameters.Length + 1; i++)
                {
                    databaseQuery.Parameters.AddWithValue("param" + i, parameters[i - 1]);
                }
            }

           
            var dataReader = databaseQuery.ExecuteReader();

            while (dataReader.Read())
            {
                QueryResult result = new QueryResult(dataReader);
                results.Add(result);
            }
            CloseConnection();
            return results;
        }
    }

}