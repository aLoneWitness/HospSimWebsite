using System;
using System.Collections.Generic;
using HospSimWebsite.Databases.HospSimWebsite;
using HospSimWebsite.Interfaces;
using HospSimWebsite.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.Repositories
{
    public class PatientRepo : Repo, IUserRepo
    {
        public List<Patient> GetByName(string name, bool shouldBeExact = true)
        {
            try
            {
                List<Patient> patients = new List<Patient>();

                List<QueryResult> userQuery = new List<QueryResult>();
                
                if (shouldBeExact)
                {
                    userQuery = Query("SELECT * FROM patient WHERE name = ?", new[] {name});
                }
                else
                {
                    userQuery = Query("SELECT * FROM patient WHERE name LIKE ?", new[] {$"%{name}%"});
                }

                for (int i = 0; i < userQuery.Count; i++)
                {
                    var disease = new DiseaseRepo().GetById(Convert.ToInt16(userQuery[i]["disease"]));
                    var patient = new Patient(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(), Convert.ToInt16(userQuery[i]["age"]),
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

        public void Insert(IHuman person)
        {
            throw new NotImplementedException();
        }

        public void Insert(Patient patient)
        {
            Query("INSERT INTO patient (name, age, disease) VALUES (?, ?, ?)",new string[] {patient.Name, patient.Age.ToString(), patient.Disease.Id.ToString()});
        }

        public List<Patient> GetAll()
        {
            try
            {
                var userQuery = Query("SELECT * FROM patient");
                List<Patient> patients = new List<Patient>();
            
                for (int i = 0; i < userQuery.Count; i++)
                {
                    var disease = new DiseaseRepo().GetById(Convert.ToInt16(userQuery[i]["disease"]));
                    var patient = new Patient(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(), Convert.ToInt16(userQuery[i]["age"]),
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

        public List<Patient> GetByDisease(int id)
        {
            try
            {
                List<Patient> patients = new List<Patient>();

                List<QueryResult> userQuery;
                
                userQuery = Query("SELECT * FROM patient WHERE disease = ?", new[] {id.ToString()});

                for (int i = 0; i < userQuery.Count; i++)
                {
                    var disease = new DiseaseRepo().GetById(Convert.ToInt16(userQuery[i]["disease"]));
                    var patient = new Patient(Convert.ToInt16(userQuery[i]["id"]), userQuery[i]["name"].ToString(), Convert.ToInt16(userQuery[i]["age"]),
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
        
        public IHuman GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int index)
        {
            try
            {
                Query("DELETE FROM patient WHERE id=?", new string[ ] { index.ToString() } );
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}