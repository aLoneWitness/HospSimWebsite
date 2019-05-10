using HospSimWebsite.Repository.Interfaces;

namespace HospSimWebsite.Logic
{
    public class UserLogic
    {
        private readonly IUserRepo _repo;

        public UserLogic(IUserRepo repo)
        {
            _repo = repo;
        }
    }
}