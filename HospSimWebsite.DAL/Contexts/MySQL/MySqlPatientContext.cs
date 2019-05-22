using System.Collections.Generic;
using System.Data;
using System.Linq;
using HospSimWebsite.DAL.Contexts.Interfaces;
using HospSimWebsite.Model;

namespace HospSimWebsite.DAL.Contexts.MySQL
{
    public class MySqlPatientContext : MySqlContext, IPatientContext
    {
        public MySqlPatientContext(string conString) : base(conString){}
        public List<Patient> GetByName(string name, bool isExact = true)
        {
            var patientQuery = isExact ? Database.Query("SELECT patient.*, disease.* FROM patient INNER JOIN disease ON patient.disease = disease.id WHERE patient.name = ?", name) : Database.Query("SELECT patient.*, disease.* FROM patient INNER JOIN disease ON patient.disease = disease.id WHERE patient.name LIKE ?", $"%{name}%");
            return GetModel(patientQuery);
        }

        public void Insert(Patient patient)
        {
            Database.Procedure("AddPatient", patient.Name, patient.Age, patient.Disease.Id);
            Database.CloseConnection();
        }

        public bool Update(Patient obj)
        {
            Database.Query("UPDATE patient SET patient.name = ?, patient.age = ?, patient.disease = ?, patient.isApproved = ? WHERE id = ?", obj.Name, obj.Age, obj.Disease.Id, obj.IsApproved, obj.Id);
            Database.CloseConnection();
            return true;
        }

        public List<Patient> GetAll()
        {
            var patientQuery = Database.Procedure("GetAllPatients");
            return GetModel(patientQuery);
        }

        public List<Patient> GetByDisease(int id)
        {
            var patientQuery = Database.Query("SELECT patient.*, disease.* FROM patient INNER JOIN disease ON patient.disease = disease.id WHERE patient.disease = ?", id.ToString());
            return GetModel(patientQuery);
        }

        public Patient Read(int id)
        {
            var patientQuery =
                Database.Query("SELECT patient.*, disease.* FROM patient INNER JOIN disease ON patient.disease = disease.id WHERE patient.id = ?", id.ToString());

            return GetModel(patientQuery).First();
        }

        public void Delete(int id)
        {
            Database.Query("DELETE FROM patient WHERE id=?", id.ToString());
            Database.CloseConnection();
        }

        public int Count()
        {
            var userQuery = Database.Query("SELECT COUNT(*) FROM patient");
            userQuery.Read();
            var count = userQuery.GetInt16(0);
            userQuery.Close();
            return count;
        }
        
        private List<Patient> GetModel(IDataReader dataReader)
        {
            var patients = new List<Patient>();
            while (dataReader.Read())
            {
                var patient = new Patient
                {
                    Id = dataReader.GetInt16(0),
                    IsApproved = dataReader.GetBoolean(1),
                    Name = dataReader.GetString(2),
                    Age = dataReader.GetInt16(3),
                    Disease = new Disease
                    {
                        Id = dataReader.GetInt16(6),
                        Name = dataReader.GetString(7),
                        Duration = dataReader.GetInt16(8),
                        Severity = dataReader.GetInt16(9),
                        Descriptions = new List<string>
                        {
                            dataReader.GetString(10),
                            dataReader.GetString(11),
                            dataReader.GetString(12)
                        }
                    }
                };
                
                patients.Add(patient);

            }
            
            dataReader.Close();
            return patients;
        }
    }
}