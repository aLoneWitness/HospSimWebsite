using HospSimWebsite.Interfaces;

namespace HospSimWebsite.Repositories.Interfaces
{
    public interface IUserRepo
    {
        IHuman GetByName(string name);

        IHuman GetById(int id);

    }
}