using System;
using System.Collections.Generic;
using System.Configuration;
using Google.Protobuf;
using HospSimWebsite.Databases;
using HospSimWebsite.Databases.HospSimWebsite;
using HospSimWebsite.Interfaces;
using HospSimWebsite.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.Repositories
{
    public abstract class Repo : IRepo
    {
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