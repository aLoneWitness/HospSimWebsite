using System.Collections.Generic;
using HospSimWebsite.DAL.Contexts.Interfaces;
using HospSimWebsite.Model;
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

        public void Insert(Patient obj)
        {
            _context.Insert(obj);
        }

        public bool Update(Patient obj)
        {
            return _context.Update(obj);
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public Patient Read(int id)
        {
            return _context.Read(id);
        }

        public int Count()
        {
            return _context.Count();
        }

        public List<Patient> GetByName(string name, bool isExact)
        {
            return _context.GetByName(name, isExact);
        }

        public List<Patient> GetByDisease(int id)
        {
            return _context.GetByDisease(id);
        }

        public List<Patient> GetAllUnapproved()
        {
            return _context.GetAllUnapproved();
        }

        public List<Patient> GetAll()
        {
            return _context.GetAll();
        }
    }
}