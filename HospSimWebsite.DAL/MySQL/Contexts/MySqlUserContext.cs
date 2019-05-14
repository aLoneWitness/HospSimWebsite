using System;
using System.Collections.Generic;
using System.Linq;
using HospSimWebsite.DAL.MySQL.Contexts.Interfaces;
using HospSimWebsite.Model;
using MySql.Data.MySqlClient;

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
            throw new NotImplementedException();
        }

        public User Validate(User user)
        {
            var queryResults = Database.Query("SELECT * FROM user WHERE username = ? AND password = ?", user.Username, user.Password);
            if (queryResults.Count != 1) throw new Exception("A authentication problem has occured, please try again later.");
            return Read(Convert.ToInt16(queryResults.First()["id"]));
        }

        public bool Exists(User user)
        {
            var queryResults = Database.Query("SELECT COUNT(*) FROM user WHERE username = ?", user.Username);
            return queryResults.Any();
        }

        public User ReadByUsername(string username)
        {
            var userQuery = Database.Query("SELECT * FROM user WHERE username = ?", username);
            
            var patients = new List<Patient>();
            var patientsQuery = Database.Query("SELECT patient.* FROM userpatients INNER JOIN patient ON userpatients.patientid = patient.id WHERE userpatients.userid = ?;", userQuery[0]["id"]);
            
            foreach (var patient in patientsQuery)
            {
                var diseaseQuery = Database.Query("SELECT * FROM disease WHERE id = ?", patient["disease"].ToString());
                var disease = new Disease{
                    Id = Convert.ToInt16(diseaseQuery[0]["id"]), 
                    Name = diseaseQuery[0]["name"].ToString(),
                    Duration = Convert.ToInt16(diseaseQuery[0]["duration"]), 
                    Severity = Convert.ToInt16(diseaseQuery[0]["severity"]),
                    Descriptions = new List<string>
                    {
                        diseaseQuery[0]["desc1"].ToString(), diseaseQuery[0]["desc2"].ToString(), diseaseQuery[0]["desc3"].ToString()
                    }};
                
                patients.Add(new Patient
                {
                    Id = Convert.ToInt16(patient["id"]), 
                    Name = patient["name"].ToString(), 
                    Age = Convert.ToInt16(patient["age"]), 
                    Disease = disease,
                    IsApproved = Convert.ToBoolean(patient["isApproved"])
                });
            }
            
            return new User{
                Id = Convert.ToInt16(userQuery[0]["id"]),
                Name = userQuery[0]["name"].ToString(), 
                Username = userQuery[0]["username"].ToString(), 
                Patients = patients, 
                Doctor = new Doctor{ Name = userQuery[0]["doctorname"].ToString()}
            };
        }

        public int Count()
        {
            var userQuery = Database.Query("SELECT COUNT(*) FROM user");
            return Convert.ToInt16(userQuery[0]["COUNT(*)"]);
        }
    }
}