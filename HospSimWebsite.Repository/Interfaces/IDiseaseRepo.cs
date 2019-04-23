using System.Collections.Generic;
using HospSimWebsite.Model;

namespace HospSimWebsite.Repository.Interfaces
{
    public interface IDiseaseRepo
    {
        void Insert(Disease disease);
        Disease GetById(int id);
        List<Disease> GetAll();
        int GetAmount();
    }
}