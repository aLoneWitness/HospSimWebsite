using System;
using System.Collections.Generic;
using HospSimWebsite.DAL.MySQL.Contexts.Interfaces;
using HospSimWebsite.Model;

namespace HospSimWebsite.DAL.MySQL.Contexts
{
    public class MySqlUserContext : MySqlContext, IUserContext
    {
        protected MySqlUserContext(string conString) : base(conString) {}

        public void Register(User obj, string hPassword)
        {
            Database.Query("INSERT INTO user(name, username, password, doctorname, highscore) VALUES (?, ?, ?, ?, ?)", obj.Name, obj.Username, hPassword, obj.Doctor.Name, obj.Highscore);
        }

        public void Insert(User obj)
        {
            throw new NotImplementedException("Insert is not allowed for default operations, Please refer to the register func.");
        }

        public void Update(User obj)
        {
            Database.Query("UPDATE user SET name = ?, doctorname = ?, highscore = ?;", obj.Name, obj.Doctor.Name, obj.Highscore);
        }

        public void Delete(int id)
        {
            Database.Query("DELETE FROM user WHERE id=?", id);
        }

        public User Read(int id)
        {
            var userQuery = Database.Query("SELECT * FROM user WHERE id = ?", id);
            
            var patients = new List<Patient>();
            var patientsQuery = Database.Query("SELECT patient.* FROM userpatients INNER JOIN patient ON userpatients.patientid = patient.id WHERE userpatients.userid = ?;", id.ToString());
            
            foreach (var patient in patientsQuery)
            {
                var diseaseQuery = Database.Query("SELECT * FROM disease WHERE id = ?", patient["disease"].ToString());
                var disease = new Disease(Convert.ToInt16(diseaseQuery[0]["id"]), diseaseQuery[0]["name"].ToString(),
                    Convert.ToInt16(diseaseQuery[0]["duration"]), Convert.ToInt16(diseaseQuery[0]["severity"]), new List<string>
                    {
                        diseaseQuery[0]["desc1"].ToString(), diseaseQuery[0]["desc2"].ToString(),
                        diseaseQuery[0]["desc3"].ToString()
                    });
                
                patients.Add(new Patient(Convert.ToInt16(patient["id"]), patient["name"].ToString(), Convert.ToInt16(patient["age"]), disease));
            }
            
            return new User(Convert.ToInt16(userQuery[0]["id"]), userQuery[0]["name"].ToString(), userQuery[0]["username"].ToString(), patients, new Doctor(userQuery[0]["doctorname"].ToString()));
        }

        public int Count()
        {
            var userQuery = Database.Query("SELECT COUNT(*) FROM user");
            return Convert.ToInt16(userQuery[0]["COUNT(*)"]);
        }
    }
}