using System.Collections.Generic;
using HospSimWebsite.Model;

namespace HospSimWebsite.DAL.Contexts.Interfaces
{
    public interface IPatientContext : IContext<Patient>
    {
        List<Patient> GetByName(string name, bool isExact);
        List<Patient> GetByDisease(int id);
        List<Patient> GetAllUnapproved();
    }
}