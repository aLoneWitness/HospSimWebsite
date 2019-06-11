using System.Collections.Generic;
using HospSimWebsite.Model;

namespace HospSimWebsite.Repository.Interfaces
{
    public interface IPatientRepo : IRepository<Patient>
    {
        List<Patient> GetByName(string name, bool isExact);
        List<Patient> GetByDisease(int id);
        List<Patient> GetAllUnapproved();
        List<Patient> GetAllApproved();
    }
}