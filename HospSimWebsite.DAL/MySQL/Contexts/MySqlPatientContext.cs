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

            foreach (var queryResult in userQuery)
            {
                var diseaseQuery = Database.Query("SELECT * FROM disease WHERE id = ?", queryResult["disease"].ToString());

                var disease = new Disease{
                    Id = Convert.ToInt16(diseaseQuery[0]["id"]), 
                    Name = userQuery[0]["name"].ToString(),
                    Duration = Convert.ToInt16(diseaseQuery[0]["duration"]), 
                    Severity = Convert.ToInt16(diseaseQuery[0]["severity"]),
                    Descriptions = new List<string>
                    {
                        diseaseQuery[0]["desc1"].ToString(), diseaseQuery[0]["desc2"].ToString(), diseaseQuery[0]["desc3"].ToString()
                    }};

                patients.Add(new Patient
                {
                    Id = Convert.ToInt16(queryResult["id"]),
                    Name = queryResult["name"].ToString(),
                    Age = Convert.ToInt16(queryResult["age"]),
                    Disease = disease
                });
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

            foreach (var queryResult in userQuery)
            {
                var diseaseQuery = Database.Query("SELECT * FROM disease WHERE id = ?", queryResult["disease"].ToString());

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
                    Id = Convert.ToInt16(queryResult["id"]),
                    Name = queryResult["name"].ToString(),
                    Age = Convert.ToInt16(queryResult["age"]),
                    Disease = disease
                });
            }

            return patients;
        }

        public List<Patient> GetByDisease(int id)
        {
            var patients = new List<Patient>();

            var userQuery =
                Database.Query("SELECT * FROM patient WHERE patient.disease = ?", id.ToString());

            foreach (var queryResult in userQuery)
            {
                var diseaseQuery = Database.Query("SELECT * FROM disease WHERE id = ?", queryResult["disease"].ToString());

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
                    Id = Convert.ToInt16(queryResult["id"]),
                    Name = queryResult["name"].ToString(),
                    Age = Convert.ToInt16(queryResult["age"]),
                    Disease = disease
                });
            }

            return patients;
        }

        public Patient Read(int id)
        {
            var patientQuery =
                Database.Query("SELECT * FROM patient WHERE patient.id = ?", id.ToString());
            
            var diseaseQuery = Database.Query("SELECT * FROM disease WHERE disease.id = ?", patientQuery[0]["disease"].ToString());
            
            var disease = new Disease{
                Id = Convert.ToInt16(diseaseQuery[0]["id"]), 
                Name = diseaseQuery[0]["name"].ToString(),
                Duration = Convert.ToInt16(diseaseQuery[0]["duration"]), 
                Severity = Convert.ToInt16(diseaseQuery[0]["severity"]),
                Descriptions = new List<string>
                {
                    diseaseQuery[0]["desc1"].ToString(), diseaseQuery[0]["desc2"].ToString(), diseaseQuery[0]["desc3"].ToString()
                }};

            var patient = new Patient
            {
                Id = Convert.ToInt16(patientQuery[0]["id"]),
                Name = patientQuery[0]["name"].ToString(),
                Age = Convert.ToInt16(patientQuery[0]["age"]),
                Disease = disease
            };

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