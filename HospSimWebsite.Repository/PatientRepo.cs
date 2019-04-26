using System.Collections.Generic;
using HospSimWebsite.Model;
using HospSimWebsite.Repository.Contexts;
using HospSimWebsite.Repository.Interfaces;

namespace HospSimWebsite.Repository
{
    public class PatientRepo : IPatientRepo
    {
        private readonly IPatientContext _context;

        public PatientRepo(IPatientContext patientContext)
        {
            _context = patientContext;
        }

        public List<Patient> GetByName(string name, bool shouldBeExact = true)
        {
            return _context.GetByName(name, shouldBeExact);
        }

        public void Insert(Patient patient)
        {
            _context.Insert(patient);
        }

        public List<Patient> GetAll()
        {
            return _context.GetAll();
        }

        public List<Patient> GetByDisease(int id)
        {
            return _context.GetByDisease(id);
        }

        public int GetAmount()
        {
            return _context.GetAmount();
        }

        public void Remove(int index)
        {
            _context.Remove(index);
        }

        public Patient GetById(int id)
        {
            return _context.GetById(id);
        }
    }
}