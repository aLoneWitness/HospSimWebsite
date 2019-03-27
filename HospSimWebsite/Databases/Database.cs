using System;
using System.Collections.Generic;
using HospSimWebsite.Databases.HospSimWebsite;
using Microsoft.EntityFrameworkCore.Internal;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.Databases
{
    public sealed class Database
    {
        private static readonly Lazy<Database> database = new Lazy<Database>(() => new Database());
        private MySqlConnection DatabaseConnection;

        public static Database Instance => database.Value;

        public void SetConnection(string conString)
        {
            DatabaseConnection = new MySqlConnection(conString);
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

        public List<QueryResult> Query(string query, params object[] parameters)
        {
            List<QueryResult> queryResultList = new List<QueryResult>();
            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(query, DatabaseConnection);
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
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
                }
                
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