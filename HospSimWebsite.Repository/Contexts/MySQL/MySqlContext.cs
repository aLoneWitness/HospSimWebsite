using HospSimWebsite.DAL;

namespace HospSimWebsite.Repository.Contexts.MySQL
{
    public class MySqlContext
    {
        protected Database Database;
        protected MySqlContext(string conString)
        {
            Database = new Database();
            Database.SetConnection(conString);
        }
    }
}