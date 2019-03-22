using System;
using System.Collections.Generic;
using HospSimWebsite.Databases.HospSimWebsite;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.Databases
{
    public sealed class Database
    {
        private static readonly Lazy<Database> database = new Lazy<Database>(() => new Database());
        private MySqlConnection DatabaseConnection;

        public static Database Instance => database.Value;

        public void SetConnection(string host, string username, string password, string database)
        {
            DatabaseConnection = new MySqlConnection("server=" + host + ";user id=" + username + ";password=" + password + ";database=" + database);
        }

        private void OpenConnection()
        {
            try
            {
                DatabaseConnection.Open();
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
                DatabaseConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Could not disconnect from database");
            }
        }

        public List<QueryResult> Query(string query, string[] parameters)
        {
            List<QueryResult> queryResultList = new List<QueryResult>();
            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(query, DatabaseConnection);
            if (parameters != null)
            {
                for (int index = 1; index < parameters.Length + 1; ++index)
                    mySqlCommand.Parameters.AddWithValue("param" + index, parameters[index - 1]);
            }
            MySqlDataReader DataReader = mySqlCommand.ExecuteReader();
            while (DataReader.Read())
            {
                QueryResult queryResult = new QueryResult(DataReader);
                queryResultList.Add(queryResult);
            }
            CloseConnection();
            return queryResultList;
        }
    }
}