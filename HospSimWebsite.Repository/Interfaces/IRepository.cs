using System.Collections.Generic;
using HospSimWebsite.Model;

namespace HospSimWebsite.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Insert(T obj);
        bool Update(T obj);
        void Delete(int id);
        T Read(int id);
        List<T> GetAll();
        int Count();
        bool Exists(T entity);
    }
}