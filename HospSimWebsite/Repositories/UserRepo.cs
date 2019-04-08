using System;
using System.Collections.Generic;
using HospSimWebsite.Interfaces;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.Repositories
{
    /*
    public class UserRepo
    {
        public IHuman GetByName(string name)
        {
            var queryResult = Query("SELECT name FROM doctor WHERE name = ?", name);

            try
            {
                return new Player(Convert.ToInt16(queryResult[0]["id"]), queryResult[0]["username"].ToString(),
                    queryResult[0]["name"].ToString());
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
            var users = new List<IHuman>();

            for (var i = 0; i < userQuery.Count; i++)
            {
                var user = new Player(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["username"].ToString(),
                    userQuery[i]["name"].ToString());
                users.Add(user);
            }

            return users;
        }

        public IHuman GetById(int id)
        {
            var userQuery = Query("SELECT * FROM user WHERE id = ?", id.ToString());

            return new Player(Convert.ToInt16(userQuery[0]["id"]), userQuery[0]["username"].ToString(),
                userQuery[0]["name"].ToString());
        }

        public void Insert(string username, string password, Player player)
        {
            Query("INSERT INTO user (name, password, doctorname, highscore) VALUES (?, ?, ?)", username, password,
                player.Name, player.Score.ToString());
        }

        public void UpdateHighscore(int score)
        {
            Query("UPDATE user SET highscore = ?", score.ToString());
        }
    }
    */
}