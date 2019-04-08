using System;
using System.Collections.Generic;
using HospSimWebsite.Databases;
using HospSimWebsite.Databases.HospSimWebsite;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.Repositories.Contexts
{
    public class MySqlPatientContext : IPatientContext
    {
        public List<Patient> GetByName(string name, bool isExact = true)
        {
            try
            {
                var patients = new List<Patient>();

                var userQuery = new List<QueryResult>();

                if (isExact)
                    userQuery = Database.Instance.Query("SELECT * FROM patient WHERE name = ?", name);
                else
                    userQuery = Database.Instance.Query("SELECT * FROM patient WHERE name LIKE ?", $"%{name}%");

                for (var i = 0; i < userQuery.Count; i++)
                {
                    var disease = new DiseaseRepo(new MySqlDiseaseContext()).GetById(Convert.ToInt16(userQuery[i]["disease"]));
                    var patient = new Patient(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(),
                        Convert.ToInt16(userQuery[i]["age"]),
                        disease);
                    patients.Add(patient);
                }

                return patients;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(Patient patient)
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetAll()
        {
            try
            {
                var userQuery = Database.Instance.Query("SELECT * FROM patient GROUP BY name LIMIT ?, ?", 0, 10);
                var patients = new List<Patient>();

                for (var i = 0; i < userQuery.Count; i++)
                {
                    var disease = new DiseaseRepo(new MySqlDiseaseContext()).GetById(Convert.ToInt16(userQuery[i]["disease"]));
                    var patient = new Patient(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(),
                        Convert.ToInt16(userQuery[i]["age"]),
                        disease);
                    patients.Add(patient);
                }

                return patients;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Patient> GetByDisease(Disease disease)
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetByDisease(int id)
        {
            try
            {
                var patients = new List<Patient>();

                var userQuery = Database.Instance.Query("SELECT * FROM patient WHERE patient.disease = ?", id.ToString());

                for (var i = 0; i < userQuery.Count; i++)
                {
                    var disease = new DiseaseRepo(new MySqlDiseaseContext()).GetById(Convert.ToInt16(userQuery[i]["disease"]));
                    var patient = new Patient(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(),
                        Convert.ToInt16(userQuery[i]["age"]),
                        disease);
                    patients.Add(patient);
                }

                return patients;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Patient GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            try
            {
                Database.Instance.Query("DELETE FROM patient WHERE id=?", id.ToString());
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}