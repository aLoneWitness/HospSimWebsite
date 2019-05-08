using HospSimWebsite.Model;

namespace HospSimWebsite.Repository.Interfaces
{
    public interface IUserRepo : IRepository<User>
    {
        void Register(User obj, string hPassword);
    }
}