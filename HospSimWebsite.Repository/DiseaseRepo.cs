using System.Collections.Generic;
using HospSimWebsite.Repository.Contexts;

namespace HospSimWebsite.Repository
{
    public class DiseaseRepo
    {
        private IDiseaseContext _context;

        public DiseaseRepo(IDiseaseContext diseaseContext)
        {
            _context = diseaseContext;
        }
        public void Insert(Disease disease)
        {
            _context.Insert(disease);
        }

        public Disease GetById(int id)
        {
           return  _context.GetById(id);
        }

        public List<Disease> GetAll()
        {
            return _context.GetAll();
        }

        public int GetAmount()
        {
            return _context.GetAmount();
        }
    }
}