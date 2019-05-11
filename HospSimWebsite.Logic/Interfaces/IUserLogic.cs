using HospSimWebsite.Logic.Enums;
using HospSimWebsite.Model;

namespace HospSimWebsite.Logic.Interfaces
{
    public interface IUserLogic
    {
        RegisterStatus Register(User user);
        bool Validate(User user);
    }
}