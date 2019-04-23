using System;
using System.Collections.Generic;
using HospSimWebsite.Databases;
using HospSimWebsite.Databases.HospSimWebsite;

namespace HospSimWebsite.Repository.Contexts.MySQL
{
    public class MySqlPatientContext : IPatientContext
    {
        public List<Patient> GetByName(string name, bool isExact = true)
        {
            var patients = new List<Patient>();

            List<QueryResult> userQuery;

            if (isExact)
                userQuery = Database.Database.Instance.Query("SELECT * FROM patient WHERE name = ?", name);
            else
                userQuery = Database.Database.Instance.Query("SELECT * FROM patient WHERE name LIKE ?", $"%{name}%");

            for (var i = 0; i < userQuery.Count; i++)
            {
                var disease =
                    new DiseaseRepo(new MySqlDiseaseContext()).GetById(Convert.ToInt16(userQuery[i]["disease"]));
                var patient = new Patient(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(),
                    Convert.ToInt16(userQuery[i]["age"]),
                    disease);
                patients.Add(patient);
            }

            return patients;
        }

        public void Insert(Patient patient)
        {
            Database.Database.Instance.Procedure("AddPatient", patient.Name, patient.Age, patient.Disease.Id);
        }

        public List<Patient> GetAll()
        {
            var userQuery = Database.Database.Instance.Procedure("GetAllPatients");
            var patients = new List<Patient>();

            for (var i = 0; i < userQuery.Count; i++)
            {
                var disease =
                    new DiseaseRepo(new MySqlDiseaseContext()).GetById(Convert.ToInt16(userQuery[i]["disease"]));
                var patient = new Patient(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(),
                    Convert.ToInt16(userQuery[i]["age"]),
                    disease);
                patients.Add(patient);
            }

            return patients;
        }

        public List<Patient> GetByDisease(int id)
        {
            var patients = new List<Patient>();

            var userQuery = Database.Database.Instance.Query("SELECT * FROM patient WHERE patient.disease = ?", id.ToString());

            for (var i = 0; i < userQuery.Count; i++)
            {
                var disease =
                    new DiseaseRepo(new MySqlDiseaseContext()).GetById(Convert.ToInt16(userQuery[i]["disease"]));
                var patient = new Patient(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(),
                    Convert.ToInt16(userQuery[i]["age"]),
                    disease);
                patients.Add(patient);
            }

            return patients;
        }

        public Patient GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            Database.Database.Instance.Query("DELETE FROM patient WHERE id=?", id.ToString());
        }

        public int GetAmount()
        {
            var userQuery = Database.Database.Instance.Query("SELECT COUNT(*) FROM patient");
            var count = Convert.ToInt16(userQuery[0]["COUNT(*)"]);
            return count;
        }
    }
}