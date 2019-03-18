using System;
using System.Collections.Generic;
using HospSimWebsite.Interfaces;
using HospSimWebsite.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.Repositories
{
    public class UserRepo : Repo, IUserRepo
    {
        public IHuman GetByName(string name)
        {
            var queryResult = Query("SELECT name FROM doctor WHERE name = ?",new string[]{ name });
            
            try
            {
                return new Player(Convert.ToInt16(queryResult[0]["id"]), queryResult[0]["username"].ToString(), queryResult[0]["name"].ToString());
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<IHuman> GetAll()
        {
            var userQuery = Query("SELECT * FROM user");
            List<IHuman> users = new List<IHuman>();
            
            for (int i = 0; i < userQuery.Count; i++)
            {
                var user = new Player(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["username"].ToString(), userQuery[i]["name"].ToString());
                users.Add(user);
            }

            return users;
        }

        public IHuman GetById(int id)
        {
            var userQuery = Query("SELECT * FROM user WHERE id = ?", new[] { id.ToString() });
            
            return new Player(Convert.ToInt16(userQuery[0]["id"]), userQuery[0]["username"].ToString(), userQuery[0]["name"].ToString());
        }

        public void Insert(string username, string password, Player player)
        {
            Query("INSERT INTO user (name, password, doctorname, highscore) VALUES (?, ?, ?)",new string[] {username, password, player.Name, player.Score.ToString()});
        }

        public void UpdateHighscore(int score)
        {
            Query("UPDATE user SET highscore = ?", new[] { score.ToString() });
        }
    }
}