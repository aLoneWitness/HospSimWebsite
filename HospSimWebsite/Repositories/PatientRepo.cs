using System;
using System.Collections.Generic;
using HospSimWebsite.Interfaces;
using HospSimWebsite.Repositories.Contexts;

namespace HospSimWebsite.Repositories
{
    public class PatientRepo
    {
        private IPatientContext _context;

        public PatientRepo(IPatientContext patientContext)
        {
            _context = patientContext;
        }
        public List<Patient> GetByName(string name, bool shouldBeExact = true)
        {
            return _context.GetByName(name, shouldBeExact);
        }

        public void Insert(IHuman person)
        {
            throw new NotImplementedException();
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

        public IHuman GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int index)
        {
            _context.Remove(index);
        }
    }
}