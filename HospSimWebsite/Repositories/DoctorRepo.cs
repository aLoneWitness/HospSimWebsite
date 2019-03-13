using System;
using HospSimWebsite.Interfaces;
using HospSimWebsite.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.Repositories
{
    public class DoctorRepo : Repo, IUserRepo
    {
        public IHuman GetByName(string name)
        {
            var queryResult = Query("SELECT name FROM doctor WHERE name = ?",new string[]{ name });
            
            try
            {
                return new Doctor(queryResult[0]["name"].ToString(), Convert.ToInt16(queryResult[0]["age"]));
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(IHuman person)
        {
            throw new NotImplementedException();
        }

        // not don
        public void Insert(Doctor doctor)
        {
            Query("INSERT INTO doctor (name, disease) VALUES (?, ?)",new string[] {doctor.Name, "gay"});
        }
    }
}