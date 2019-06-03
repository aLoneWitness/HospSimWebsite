using System;
using System.Collections.Generic;
using System.Linq;
using HospSimWebsite.DAL.Contexts.Interfaces;
using HospSimWebsite.Model;

namespace HospSimWebsite.DAL.Contexts.Memory
{
    public class MemoryDiseaseContext : IDiseaseContext
    {
        private readonly List<Disease> _diseases;

        public MemoryDiseaseContext()
        {
            _diseases = new List<Disease>();
        }


        public void Insert(Disease obj)
        {
            _diseases.Insert(obj.Id, obj);
        }

        public bool Update(Disease obj)
        {
            _diseases[obj.Id] = obj;
            return true;
        }

        public void Delete(int id)
        {
            _diseases.RemoveAt(id);
        }

        public Disease Read(int id)
        {
            return _diseases[id];
        }

        public int Count()
        {
            return _diseases.Count();
        }

        public bool Exists(Disease obj)
        {
            return _diseases.Exists(disease => disease.Id == obj.Id);
        }

        public List<Disease> GetAll()
        {
            return _diseases;
        }
    }
}