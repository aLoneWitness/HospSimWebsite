using System;
using System.Collections.Generic;
using HospSimWebsite.Databases;
using HospSimWebsite.Databases.HospSimWebsite;
using HospSimWebsite.Interfaces;
using HospSimWebsite.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.Repositories
{
    public abstract class Repo : IRepo
    {
        public Repo()
        {
            try
            {
                SetConnectionString();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        private void SetConnectionString()
        {
            Database.Instance.SetConnection("studmysql01.fhict.local", "dbi407041", "wonderworld", "dbi407041");
        }

        protected List<QueryResult> Query(string query, String[] strings)
        {
            return Database.Instance.Query(query, strings);
        }

        protected List<QueryResult> Query(string query)
        {
            return Database.Instance.Query(query, new String[] { });
        }
    }
}