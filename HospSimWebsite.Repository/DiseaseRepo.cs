using System.Collections.Generic;
using HospSimWebsite.Model;
using HospSimWebsite.Repository.Contexts;
using HospSimWebsite.Repository.Contexts.MySQL.Interfaces;
using HospSimWebsite.Repository.Interfaces;

namespace HospSimWebsite.Repository
{
    public class DiseaseRepo : IRepository<Disease>
    {
        private readonly IMySqlContext<Disease> _context;

        public DiseaseRepo(IMySqlContext<Disease> diseaseContext)
        {
            _context = diseaseContext;
        }

        public void Insert(Disease disease)
        {
            _context.Insert(disease);
        }

        public void Update(Disease obj)
        {
            _context.Update(obj);
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
    }
}