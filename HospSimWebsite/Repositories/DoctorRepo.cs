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

        public void Insert(string username, string password, Doctor doctor)
        {
            Query("INSERT INTO user (name, password, doctorname, highscore) VALUES (?, ?, ?)",new string[] {username, password, doctor.Name, doctor.Score.ToString()});
        }

        public void UpdateHighscore(Doctor doctor)
        {
            Query("UPDATE user SET highscore = ?", new[] {doctor.Score.ToString()});
        }
    }
}