using HospSimWebsite.Model;

namespace HospSimWebsite.Repository.Interfaces
{
    public interface IUserRepo : IRepository<User>
    {
        User Validate(User user);
        bool Exists(User user);
        User ReadByUsername(string username);
    }
}