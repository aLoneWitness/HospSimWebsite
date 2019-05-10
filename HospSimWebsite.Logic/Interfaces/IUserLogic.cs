using HospSimWebsite.Model;

namespace HospSimWebsite.Logic.Interfaces
{
    public interface IUserLogic : ILogic<User>
    {
        bool Register(User user);
        bool ValidateUser(User user);
    }
}