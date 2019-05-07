using System.Collections.Generic;
using HospSimWebsite.Logic.Interfaces;
using HospSimWebsite.Model;
using HospSimWebsite.Repository.Interfaces;

namespace HospSimWebsite.Logic
{
    public class PatientLogic : IPatientLogic
    {
        private readonly IPatientRepo _repo;

        public PatientLogic(IPatientRepo patientRepo)
        {
            _repo = patientRepo;
        }

        public List<Patient> GetByName(string name, bool isExact = true)
        {
            return _repo.GetByName(name, isExact);
        }

        public bool Insert(Patient patient)
        {
            if (patient.Age < 0) return false;

            _repo.Insert(patient);
            return true;
        }

        public List<Patient> GetAll()
        {
            return _repo.GetAll();
        }

        public List<Patient> GetByDisease(int id)
        {
            return _repo.GetByDisease(id);
        }

        public int Count()
        {
            return _repo.Count();
        }

        public Patient Read(int id)
        {
            return _repo.Read(id);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public void Remove(int index)
        {
            _repo.Delete(index);
        }
    }
}