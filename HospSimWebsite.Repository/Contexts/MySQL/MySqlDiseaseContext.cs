using System;
using System.Collections.Generic;
using HospSimWebsite.DAL;
using HospSimWebsite.Model;

namespace HospSimWebsite.Repository.Contexts.MySQL
{
    public class MySqlDiseaseContext : MySqlContext, IDiseaseContext
    {
        public MySqlDiseaseContext(string conString) : base(conString){}
        public void Insert(Disease disease)
        {
            Database.Query(
                "INSERT INTO disease (name, duration, severity, desc1, desc2, desc3 ) VALUES (?, ?, ?, ?, ?, ?)",
                disease.Name,
                disease.Duration.ToString(), disease.Severity.ToString(), disease.Descriptions[0],
                disease.Descriptions[1], disease.Descriptions[2]);
        }

        public int GetAmount()
        {
            var userQuery = Database.Query("SELECT id FROM disease");
            return userQuery.Count;
        }

        public Disease GetById(int id)
        {
            var userQuery = Database.Query("SELECT * FROM disease WHERE id = ?", id.ToString());

            return new Disease(Convert.ToInt16(userQuery[0]["id"]), userQuery[0]["name"].ToString(),
                Convert.ToInt16(userQuery[0]["duration"]), Convert.ToInt16(userQuery[0]["severity"]),
                new List<string>
                {
                    userQuery[0]["desc1"].ToString(), userQuery[0]["desc2"].ToString(), userQuery[0]["desc3"].ToString()
                });
        }

        public List<Disease> GetAll()
        {
            var userQuery = Database.Query("SELECT * FROM disease");
            var diseases = new List<Disease>();

            for (var i = 0; i < userQuery.Count; i++)
                diseases.Add(new Disease(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(),
                    Convert.ToInt16(userQuery[i]["duration"]), Convert.ToInt16(userQuery[i]["severity"]),
                    new List<string>
                    {
                        userQuery[0]["desc1"].ToString(), userQuery[0]["desc2"].ToString(),
                        userQuery[0]["desc3"].ToString()
                    }));

            return diseases;
        }
    }
}