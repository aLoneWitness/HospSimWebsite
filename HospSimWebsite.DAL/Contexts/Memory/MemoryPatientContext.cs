using System;
using System.Collections.Generic;
using System.Linq;
using HospSimWebsite.DAL.Contexts.Interfaces;
using HospSimWebsite.Model;

namespace HospSimWebsite.DAL.Contexts.Memory
{
    public class MemoryPatientContext : IPatientContext
    {
        private List<Patient> _patients;

        public MemoryPatientContext()
        {
            _patients = new List<Patient>();
        }
        public void Insert(Patient obj)
        {
            _patients.Insert(obj.Id, obj);
        }

        public bool Update(Patient obj)
        {
            _patients[obj.Id] = obj; 
            return true;
        }

        public void Delete(int id)
        {
            _patients.RemoveAt(id);
        }

        public Patient Read(int id)
        {
            return _patients[id];
        }

        public int Count()
        {
            return _patients.Count;
        }

        public bool Exists(Patient obj)
        {
            return _patients.Exists(patient => patient.Id == obj.Id);
        }

        public List<Patient> GetByName(string name, bool isExact)
        {
            if (isExact)
            {
                return _patients.Where(patient => patient.Name.Contains(name)).ToList();
            }
            else
            {
                return _patients.Where(patient => patient.Name == name).ToList();
            }
        }

        public List<Patient> GetByDisease(int id)
        {
            return _patients.Where(patient => patient.Disease.Id == id).ToList();
        }

        public List<Patient> GetAll()
        {
            return _patients;
        }

        public List<Patient> GetAllUnapproved()
        {
            return _patients.Where(patient => patient.IsApproved == false).ToList();
        }
    }
}