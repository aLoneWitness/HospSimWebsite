using System.Collections.Generic;
using HospSimWebsite.Model;

namespace HospSimWebsite.Repository.Contexts
{
    public interface IDiseaseContext
    {
        List<Disease> GetAll();
        Disease GetById(int id);
        void Insert(Disease disease);
        int GetAmount();
    }
}