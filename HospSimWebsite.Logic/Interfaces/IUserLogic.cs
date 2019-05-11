using HospSimWebsite.Model;

namespace HospSimWebsite.Logic.Interfaces
{
    public interface IUserLogic
    {
        bool Register(User user);
        bool Validate(User user);
    }
}