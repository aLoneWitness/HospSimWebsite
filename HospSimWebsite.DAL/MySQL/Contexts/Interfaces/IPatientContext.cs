using System.Collections.Generic;
using HospSimWebsite.Model;

namespace HospSimWebsite.DAL.MySQL.Contexts.Interfaces
{
    public interface IPatientContext : IMySqlContext<Patient>
    {
        List<Patient> GetByName(string name, bool isExact);
        List<Patient> GetByDisease(int id);
        List<Patient> GetAll();
    }
}