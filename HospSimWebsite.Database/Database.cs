using System;
using System.Collections.Generic;
using System.Data;
using HospSimWebsite.Databases.HospSimWebsite;
using Microsoft.EntityFrameworkCore.Internal;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.Database
{
    public sealed class Database
    {
        private static readonly Lazy<Database> database = new Lazy<Database>(() => new Database());
        private MySqlConnection _databaseConnection;

        public static Database Instance => database.Value;

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

        public List<QueryResult> Query(string query, params object[] parameters)
        {
            List<QueryResult> queryResultList = new List<QueryResult>();
            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(query, _databaseConnection);
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
            MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                QueryResult queryResult = new QueryResult(dataReader);
                queryResultList.Add(queryResult);
            }
            CloseConnection();
            return queryResultList;
        }
        
        public List<QueryResult> Procedure(string procedure, params object[] parameters)
        {
            var results = new List<QueryResult>();
            var databaseQuery = new MySqlCommand(procedure, _databaseConnection);
            databaseQuery.CommandType = CommandType.StoredProcedure;

            foreach (var parameter in parameters)
            {  
                databaseQuery.Parameters.AddWithValue($"param{(Array.IndexOf(parameters, parameter) + 1).ToString()}", parameter);
            }
            
            
            OpenConnection();

            try
            {
                var dataReader = databaseQuery.ExecuteReader();
                while (dataReader.Read())
                {
                    var result = new QueryResult(dataReader);
                    results.Add(result);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                CloseConnection();
            }
            
            return results;
        }
    }
}