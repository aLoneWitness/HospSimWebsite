using System;
using System.Collections.Generic;
using System.Linq;
using HospSimWebsite.Model;

namespace HospSimWebsite.Repository.Contexts.Memory
{
    public class MemoryPatientContext : IPatientContext
    {
        private List<Patient> _patients;

        public MemoryPatientContext()
        {
            _patients = new List<Patient>();

            for (var i = 0; i < 10; i++)
            {
                _patients.Add(new Patient(i, "Mark", i));
            }
        }

        public List<Patient> GetAll()
        {
            return _patients;
        }

        public List<Patient> GetByDisease(int id)
        {
            return _patients.Where(patient => id == patient.Disease.Id).ToList();
        }

        public Patient GetById(int id)
        {
            return _patients.First(o => id == o.Id);
        }

        public void Remove(int index)
        {
            _patients.RemoveAt(index);
        }

        public int GetAmount()
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetByName(string name, bool isExact)
        {
            if (isExact)
            {
                throw new NotImplementedException();
            }

            return _patients.Where(patient => name == patient.Name).ToList();
        }

        public void Insert(Patient patient)
        {
            _patients.Add(patient);
        }
    }
}