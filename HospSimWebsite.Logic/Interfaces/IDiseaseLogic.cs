using HospSimWebsite.Model;

namespace HospSimWebsite.Logic.Interfaces
{
    public interface IDiseaseLogic : ILogic<Disease>
    {
        Disease GetById(int id);
    }
}