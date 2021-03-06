using System.Collections.Generic;
using HospSimWebsite.Model;

namespace HospSimWebsite.Logic.Interfaces
{
    public interface IPatientLogic : ILogic<Patient>
    {
        List<Patient> GetByName(string name, bool isExact = true);
        List<Patient> GetByDisease(int id);
        void Remove(int index);
        List<Patient> GetAllUnapproved();
    }
}