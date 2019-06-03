using HospSimWebsite.Model;

namespace HospSimWebsite.DAL.Contexts.Interfaces
{
    public interface IUserContext : IMySqlContext<User>
    {
        User Validate(User user);
    }
}