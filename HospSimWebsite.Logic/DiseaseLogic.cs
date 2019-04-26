using System.Collections.Generic;
using HospSimWebsite.Logic.Interfaces;
using HospSimWebsite.Model;
using HospSimWebsite.Repository.Interfaces;

namespace HospSimWebsite.Logic
{
    public class DiseaseLogic : IDiseaseLogic
    {
        private readonly IDiseaseRepo _repo;

        public DiseaseLogic(IDiseaseRepo diseaseRepo)
        {
            _repo = diseaseRepo;
        }

        public bool Insert(Disease disease)
        {
            if (disease.Duration < 0 || disease.Severity < 0 || disease.Descriptions.Count != 3) return false;

            _repo.Insert(disease);
            return true;
        }

        public Disease GetById(int id)
        {
            return _repo.GetById(id);
        }

        public List<Disease> GetAll()
        {
            return _repo.GetAll();
        }

        public int GetAmount()
        {
            return _repo.GetAmount();
        }
    }
}