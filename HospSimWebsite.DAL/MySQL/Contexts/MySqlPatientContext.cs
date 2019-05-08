using System;
using System.Collections.Generic;
using HospSimWebsite.DAL.MySQL.Contexts.Interfaces;
using HospSimWebsite.DAL.MySQL.HospSimWebsite;
using HospSimWebsite.Model;

namespace HospSimWebsite.DAL.MySQL.Contexts
{
    public class MySqlPatientContext : MySqlContext, IPatientContext
    {
        public MySqlPatientContext(string conString) : base(conString){}
        public List<Patient> GetByName(string name, bool isExact = true)
        {
            var patients = new List<Patient>();

            List<QueryResult> userQuery;

            if (isExact)
                userQuery = Database.Query("SELECT * FROM patient WHERE name = ?", name);
            else
                userQuery = Database.Query("SELECT * FROM patient WHERE name LIKE ?", $"%{name}%");

            for (var i = 0; i < userQuery.Count; i++)
            {
                var diseaseQuery = Database.Query("SELECT * FROM disease WHERE id = ?", userQuery[i]["disease"].ToString());

                var disease = new Disease(Convert.ToInt16(diseaseQuery[0]["id"]), diseaseQuery[0]["name"].ToString(),
                    Convert.ToInt16(diseaseQuery[0]["duration"]), Convert.ToInt16(diseaseQuery[0]["severity"]),
                    new List<string>
                    {
                        diseaseQuery[0]["desc1"].ToString(), diseaseQuery[0]["desc2"].ToString(), diseaseQuery[0]["desc3"].ToString()
                    });
                    
                var patient = new Patient(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(),
                    Convert.ToInt16(userQuery[i]["age"]),
                    disease);
                patients.Add(patient);
            }

            return patients;
        }

        public void Insert(Patient patient)
        {
            Database.Procedure("AddPatient", patient.Name, patient.Age, patient.Disease.Id);
        }

        public void Update(Patient obj)
        {
            Database.Query("UPDATE patient SET name = ?, age = ?, disease = ?;", obj.Name.ToString(), obj.Age, obj.Disease.Id);
        }

        public List<Patient> GetAll()
        {
            var userQuery = Database.Procedure("GetAllPatients");
            var patients = new List<Patient>();

            for (var i = 0; i < userQuery.Count; i++)
            {
                var diseaseQuery = Database.Query("SELECT * FROM disease WHERE id = ?", userQuery[i]["disease"].ToString());

                var disease = new Disease(Convert.ToInt16(diseaseQuery[0]["id"]), diseaseQuery[0]["name"].ToString(),
                    Convert.ToInt16(diseaseQuery[0]["duration"]), Convert.ToInt16(diseaseQuery[0]["severity"]),
                    new List<string>
                    {
                        diseaseQuery[0]["desc1"].ToString(), diseaseQuery[0]["desc2"].ToString(), diseaseQuery[0]["desc3"].ToString()
                    });
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

            var userQuery =
                Database.Query("SELECT * FROM patient WHERE patient.disease = ?", id.ToString());

            for (var i = 0; i < userQuery.Count; i++)
            {
                var diseaseQuery = Database.Query("SELECT * FROM disease WHERE id = ?", userQuery[i]["disease"].ToString());

                var disease = new Disease(Convert.ToInt16(diseaseQuery[0]["id"]), diseaseQuery[0]["name"].ToString(),
                    Convert.ToInt16(diseaseQuery[0]["duration"]), Convert.ToInt16(diseaseQuery[0]["severity"]),
                    new List<string>
                    {
                        diseaseQuery[0]["desc1"].ToString(), diseaseQuery[0]["desc2"].ToString(), diseaseQuery[0]["desc3"].ToString()
                    });
                var patient = new Patient(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(),
                    Convert.ToInt16(userQuery[i]["age"]),
                    disease);
                patients.Add(patient);
            }

            return patients;
        }

        public Patient Read(int id)
        {
            var patientQuery =
                Database.Query("SELECT * FROM patient WHERE patient.id = ?", id.ToString());
            
            var diseaseQuery = Database.Query("SELECT * FROM disease WHERE disease.id = ?", patientQuery[0]["disease"].ToString());
            
            var disease = new Disease(Convert.ToInt16(diseaseQuery[0]["id"]), diseaseQuery[0]["name"].ToString(),
                Convert.ToInt16(diseaseQuery[0]["duration"]), Convert.ToInt16(diseaseQuery[0]["severity"]),
                new List<string>
                {
                    diseaseQuery[0]["desc1"].ToString(), diseaseQuery[0]["desc2"].ToString(), diseaseQuery[0]["desc3"].ToString()
                });
            
            var patient = new Patient(Convert.ToInt16(patientQuery[0]["id"]), patientQuery[0]["name"].ToString(),
                Convert.ToInt16(patientQuery[0]["age"]),
                disease);

            return patient;
        }

        public void Delete(int id)
        {
            Database.Query("DELETE FROM patient WHERE id=?", id.ToString());
        }

        public int Count()
        {
            var userQuery = Database.Query("SELECT COUNT(*) FROM patient");
            var count = Convert.ToInt16(userQuery[0]["COUNT(*)"]);
            return count;
        }
    }
}