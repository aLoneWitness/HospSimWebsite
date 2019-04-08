using System;
using System.Collections.Generic;
using HospSimWebsite.Repositories.Contexts;

namespace HospSimWebsite.Repositories
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
    }
}