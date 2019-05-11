using HospSimWebsite.Model;

namespace HospSimWebsite.Repository.Interfaces
{
    public interface IUserRepo : IRepository<User>
    {
        User Validate(User user);
    }
}