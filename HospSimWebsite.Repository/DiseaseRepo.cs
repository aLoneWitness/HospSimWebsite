using System.Collections.Generic;
using HospSimWebsite.DAL.Contexts.Interfaces;
using HospSimWebsite.Model;
using HospSimWebsite.Repository.Interfaces;

namespace HospSimWebsite.Repository
{
    public class DiseaseRepo : IRepository<Disease>
    {
        private readonly IDiseaseContext _context;

        public DiseaseRepo(IDiseaseContext diseaseContext)
        {
            _context = diseaseContext;
        }    
        public void Insert(Disease disease)
        {
            _context.Insert(disease);
        }

        public bool Update(Disease obj)
        {
            return _context.Update(obj);
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public Disease Read(int id)
        {
            return _context.Read(id);
        }

        public List<Disease> GetAll()
        {
            return _context.GetAll();
        }

        public int Count()
        {
            return _context.Count();
        }

        public bool Exists(Disease entity)
        {
            return _context.Exists(entity);
        }
    }
}