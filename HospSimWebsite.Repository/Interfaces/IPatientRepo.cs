using System.Collections.Generic;
using HospSimWebsite.Model;

namespace HospSimWebsite.Repository.Interfaces
{
    public interface IPatientRepo
    {
        List<Patient> GetByName(string name, bool shouldBeExact = true);
        void Insert(Patient patient);
        List<Patient> GetAll();
        List<Patient> GetByDisease(int id);
        int GetAmount();
        void Remove(int index);
        Patient GetById(int id);
    }
}