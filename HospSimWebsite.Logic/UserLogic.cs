using HospSimWebsite.Logic.Interfaces;
using HospSimWebsite.Model;
using HospSimWebsite.Repository.Interfaces;

namespace HospSimWebsite.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepo _repo;

        public UserLogic(IUserRepo repo)
        {
            _repo = repo;
        }

        public bool Register(User user)
        {
            _repo.Insert(user);
            return true;
        }

        public bool Validate(User user)
        {
            var password = user.Password;
            if(_repo.Validate(user))
        }
    }
}