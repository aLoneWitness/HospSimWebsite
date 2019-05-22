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
            if (_patients.Any(patient => patient.Id == obj.Id))
            {
                _patients[obj.Id] = obj;
                return true;
            }

            return false;
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
    }
}