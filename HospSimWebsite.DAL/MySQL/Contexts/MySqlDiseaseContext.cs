using System.Collections.Generic;
using System.Linq;
using HospSimWebsite.DAL.MySQL.Contexts.Interfaces;
using HospSimWebsite.Model;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.DAL.MySQL.Contexts
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
            Database.CloseConnection();
        }

        public void Update(Disease disease)
        {
            Database.Query(
                "UPDATE disease SET name = ?, duration = ?, severity = ?, desc1 = ?, desc2 = ?, desc3 = ? WHERE id = ?",
                disease.Name,
                disease.Duration.ToString(), disease.Severity.ToString(), disease.Descriptions[0],
                disease.Descriptions[1], disease.Descriptions[2], disease.Id.ToString());
            Database.CloseConnection();
        }

        public void Delete(int id)
        {
            Database.Query("DELETE FROM patient WHERE id=?", id.ToString());
            Database.CloseConnection();
        }

        public Disease Read(int id)
        {
            var dataReader = Database.Query("SELECT * FROM disease WHERE id = ?", id.ToString());

            return GetModel(dataReader).First();
        }

        public int Count()
        {
            var userQuery = Database.Query("SELECT COUNT(*) FROM disease");
            userQuery.Read();
            var count = userQuery.GetInt16(0);
            userQuery.Close();
            return count;
        }
        /*

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
        
        */
        public List<Disease> GetAll()
        {
            var userQuery = Database.Query("SELECT * FROM disease");
            return GetModel(userQuery);
        }
        
        private List<Disease> GetModel(MySqlDataReader dataReader)
        {
            var diseases = new List<Disease>();
            while(dataReader.Read())
            {
                var disease = new Disease
                {
                    Id = dataReader.GetInt16(0),
                    Name = dataReader.GetString(1),
                    Duration = dataReader.GetInt16(2),
                    Severity = dataReader.GetInt16(3),
                    Descriptions = new List<string>
                    {
                        dataReader.GetString(4),
                        dataReader.GetString(5),
                        dataReader.GetString(6)
                    }
                };
                
                diseases.Add(disease);

            } 
            
            dataReader.Close();

            return diseases;
        }
    }
}