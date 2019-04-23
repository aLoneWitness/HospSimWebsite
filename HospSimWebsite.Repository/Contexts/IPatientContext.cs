using System.Collections.Generic;

namespace HospSimWebsite.Repository.Contexts
{
    public interface IPatientContext
    {
        List<Patient> GetByName(string name, bool isExact);
        void Insert(Patient patient);
        List<Patient> GetAll();
        List<Patient> GetByDisease(int id);
        Patient GetById(int id);
        void Remove(int index);
        int GetAmount();
    }
}