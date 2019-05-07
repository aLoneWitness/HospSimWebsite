namespace HospSimWebsite.Repository.Contexts.MySQL
{
    public class MySqlUserContext : MySqlContext, IUserContext
    {
        protected MySqlUserContext(string conString) : base(conString)
        {
            
        }
    }

    public interface IUserContext
    {
    }
}