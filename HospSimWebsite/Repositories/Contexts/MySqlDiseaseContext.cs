using System;
using System.Collections.Generic;
using HospSimWebsite.Databases;

namespace HospSimWebsite.Repositories.Contexts
{
    public class MySqlDiseaseContext : IDiseaseContext
    {
        public void Insert(Disease disease)
        {
            Database.Instance.Query("INSERT INTO disease (name, duration, severity, description ) VALUES (?, ?, ?, ?)", disease.Name,
                disease.Duration.ToString(), disease.Severity.ToString(), disease.Description);
        }

        public Disease GetById(int id)
        {
            var userQuery = Database.Instance.Query("SELECT * FROM disease WHERE id = ?", id.ToString());

            return new Disease(Convert.ToInt16(userQuery[0]["id"]), userQuery[0]["name"].ToString(),
                Convert.ToInt16(userQuery[0]["duration"]), Convert.ToInt16(userQuery[0]["severity"]),
                userQuery[0]["description"].ToString());
        }

        public List<Disease> GetAll()
        {
            var userQuery = Database.Instance.Query("SELECT * FROM disease");
            var diseases = new List<Disease>();

            for (var i = 0; i < userQuery.Count; i++)
                diseases.Add(new Disease(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(),
                    Convert.ToInt16(userQuery[i]["duration"]), Convert.ToInt16(userQuery[i]["severity"]),
                    userQuery[i]["description"].ToString()));

            return diseases;
        }
    }
}