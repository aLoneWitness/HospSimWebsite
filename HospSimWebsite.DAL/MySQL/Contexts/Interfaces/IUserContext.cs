using HospSimWebsite.Model;

namespace HospSimWebsite.DAL.MySQL.Contexts.Interfaces
{
    public interface IUserContext : IMySqlContext<User>
    {
        void Register(User obj, string hPassword);
        User Validate(User user);
        bool Exists(User user);
        User ReadByUsername(string username);
    }
}