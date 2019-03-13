using System;
using HospSimWebsite.Repositories.Interfaces;
using LightningORM;
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
    }
}