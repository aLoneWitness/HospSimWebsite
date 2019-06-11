using HospSimWebsite.Model;

namespace HospSimWebsite.DAL.Contexts.Interfaces
{
    public interface IUserContext : IContext<User>
    {
        User Validate(User user);
    }
}