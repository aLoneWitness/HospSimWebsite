using System.Collections.Generic;

namespace HospSimWebsite.Logic.Interfaces
{
    public interface ILogic<T> where T : class
    {
        bool Insert(T entity);
        List<T> GetAll();
        int GetAmount();
        T GetById(int id);
    }
}