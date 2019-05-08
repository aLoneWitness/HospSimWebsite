namespace HospSimWebsite.DAL.MySQL.Contexts.Interfaces
{
    public interface IMySqlContext<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        T Read(int id);
        int Count();
    }
}