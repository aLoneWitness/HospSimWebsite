using System.Collections.Generic;
using HospSimWebsite.Model;

namespace HospSimWebsite.DAL.MySQL.Contexts.Interfaces
{
    public interface IDiseaseContext : IMySqlContext<Disease>
    {
        List<Disease> GetAll();
    }
}