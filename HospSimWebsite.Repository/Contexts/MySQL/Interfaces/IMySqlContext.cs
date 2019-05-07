using System.Collections.Generic;
using HospSimWebsite.Model;

namespace HospSimWebsite.Repository.Contexts.MySQL.Interfaces
{
    public interface IMySqlContext<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        T Read(int id);
        int Count();
        List<T> GetAll();
    }
}