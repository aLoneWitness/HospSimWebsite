using System;
using System.Collections.Generic;
using System.Diagnostics;
using HospSimWebsite.Interfaces;
using HospSimWebsite.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.Repositories
{
    public class PatientRepo : Repo, IUserRepo
    {
        public IHuman GetByName(string name)
        {
            var queryResult = Query("SELECT name FROM patient WHERE name = ?",new string[]{ name });
            try
            {
                var disease = new DiseaseRepo().GetById(Convert.ToInt16(queryResult[0]["disease"]));
                var patient = new Patient(Convert.ToInt16(queryResult[0]["id"]), queryResult[0]["name"].ToString(), Convert.ToInt16(queryResult[0]["age"]), disease);
                return patient;
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