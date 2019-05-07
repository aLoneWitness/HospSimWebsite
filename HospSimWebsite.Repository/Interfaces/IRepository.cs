using System.Collections.Generic;

namespace HospSimWebsite.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        T Read(int id);
        List<T> GetAll();
        int Count();
    }
}