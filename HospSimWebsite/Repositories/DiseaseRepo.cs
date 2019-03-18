using System;
using System.Collections.Generic;

namespace HospSimWebsite.Repositories
{
    public class DiseaseRepo : Repo
    {
        public void Insert(Disease disease)
        {
            Query("INSERT INTO disease (name, duration, severity ) VALUES (?, ?, ?)",new[] {disease.Name, disease.Duration.ToString(), disease.Severity.ToString()});
        }

        public Disease GetById(int id)
        {
            var userQuery = Query("SELECT * FROM disease WHERE id = ?", new[] { id.ToString() });
            
            return new Disease(Convert.ToInt16(userQuery[0]["id"]), userQuery[0]["name"].ToString(), Convert.ToInt16(userQuery[0]["duration"]), Convert.ToInt16(userQuery[0]["severity"]));
        }
        
        public List<Disease> GetAll()
        {
            var userQuery = Query("SELECT * FROM disease");
            List<Disease> diseases = new List<Disease>();
                
            for (int i = 0; i < userQuery.Count; i++)
            {
                diseases.Add(new Disease(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(), Convert.ToInt16(userQuery[i]["duration"]), Convert.ToInt16(userQuery[i]["severity"])));
            }

            return diseases;
        }
    }
}