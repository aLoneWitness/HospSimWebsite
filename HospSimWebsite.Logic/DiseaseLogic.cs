using System.Collections.Generic;
using HospSimWebsite.Logic.Interfaces;
using HospSimWebsite.Model;
using HospSimWebsite.Repository.Interfaces;

namespace HospSimWebsite.Logic
{
    public class DiseaseLogic : IDiseaseLogic
    {
        private readonly IRepository<Disease> _repo;

        public DiseaseLogic(IRepository<Disease> diseaseRepo)
        {
            _repo = diseaseRepo;
        }

        public bool Insert(Disease disease)
        {
            if (disease.Duration < 0 || disease.Severity < 0 || disease.Descriptions.Count != 3) return false;

            _repo.Insert(disease);
            return true;
        }

        public Disease Read(int id)
        {
            return _repo.Read(id);
        }

        public bool Update(Disease disease)
        {
            _repo.Update(disease);
            return true;
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public List<Disease> GetAll()
        {
            return _repo.GetAll();
        }

        public bool Exists(Disease entity)
        {
            return _repo.Exists(entity);
        }

        public int Count()
        {
            return _repo.Count();
        }
    }
}