using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospSimWebsite.DAL.Contexts.Interfaces;
using HospSimWebsite.Model;

namespace HospSimWebsite.DAL.Contexts.MySQL
{
    
    public class MySqlUserContext : MySqlContext, IUserContext
    {
        protected MySqlUserContext(string conString) : base(conString) {}

        public void Insert(User obj)
        {
            Database.Query("INSERT INTO user(name, username, password, doctorname, highscore) VALUES (?, ?, ?, ?, ?)", obj.Name, obj.Username, obj.Password, obj.Doctor.Name, obj.Highscore);
        }

        public bool Update(User obj)
        {
            Database.Query("UPDATE user SET name = ?, doctorname = ?, highscore = ?;", obj.Name, obj.Doctor.Name, obj.Highscore);
            return true;
        }

        public void Delete(int id)
        {
            Database.Query("DELETE FROM user WHERE id = ?", id);
        }

        public User Read(int id)
        {
            var queryResult = Database.Query("SELECT * FROM user WHERE id = ?", id);
            return GetModel(queryResult).First();
        }

        public User Validate(User user)
        {
            var queryResult = Database.Query("SELECT * FROM user WHERE username = ? AND password = ?", user.Username, user.Password);
            return Read(queryResult.GetInt16(0));
        }

        public bool Exists(User user)
        {
            var queryResult = Database.Query("SELECT COUNT(*) FROM user WHERE username = ?", user.Username);
            return (queryResult != null);
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            var userQuery = Database.Query("SELECT COUNT(*) FROM user");
            userQuery.Read();
            var count = userQuery.GetInt16(0);
            userQuery.Close();
            return count;
        }
        
        private List<User> GetModel(IDataReader dataReader)
        {
            var users = new List<User>();
            while (dataReader.Read())
            {
                var user = new User
                {
                    Id = dataReader.GetInt16(0),
                    Name = dataReader.GetString(1),
                    Username = dataReader.GetString(2),
                    Password = dataReader.GetString(3),
                    Doctor = new Doctor{Name = dataReader.GetString(4)},
                    Highscore = dataReader.GetInt16(5)
                };
                users.Add(user);
            }
            
            dataReader.Close();
            return users;
        }
    }
    
}