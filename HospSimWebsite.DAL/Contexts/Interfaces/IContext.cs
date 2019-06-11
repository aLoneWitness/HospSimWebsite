using System.Collections.Generic;

namespace HospSimWebsite.DAL.Contexts.Interfaces
{
    public interface IContext<T> where T : class
    {
        void Insert(T obj);
        bool Update(T obj);
        void Delete(int id);
        T Read(int id);
        int Count();
        bool Exists(T obj);
        List<T> GetAll();
    }
}