using System.Collections.Generic;
using System.Linq;

namespace HospSimWebsite.Repository.Contexts.Memory
{
    public class MemoryDiseaseContext : IDiseaseContext
    {
        private List<Disease> _diseases;
        public MemoryDiseaseContext()
        {
            _diseases = new List<Disease>();
            
            for(int i = 0; i < 10; i++)
            {
                _diseases.Add(new Disease(i, $"Disease{i}", i * 2,4 ,"I am disease" ));
            }
        }

        public List<Disease> GetAll()
        {
            return _diseases;
        }

        public Disease GetById(int id)
        {
            return _diseases.First(o => id == o.Id);
        }

        public void Insert(Disease disease)
        {
            _diseases.Add(disease);
        }

        public int GetAmount()
        {
            throw new System.NotImplementedException();
        }
    }
}