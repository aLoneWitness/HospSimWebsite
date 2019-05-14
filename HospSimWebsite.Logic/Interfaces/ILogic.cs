using System.Collections.Generic;

namespace HospSimWebsite.Logic.Interfaces
{
    public interface ILogic<T> where T : class
    {
        bool Insert(T entity);
        int Count();
        T Read(int id);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
    }
}