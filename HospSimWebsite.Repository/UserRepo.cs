using System.Collections.Generic;
using HospSimWebsite.Model;
using HospSimWebsite.Repository.Interfaces;

namespace HospSimWebsite.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly IUserRepo _context;
        
        public UserRepo(IUserRepo context)
        {
            _context = context;
        }
        public void Insert(User obj)
        {
            _context.Insert(obj);
        }

        public void Update(User obj)
        {
            _context.Update(obj);
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public User Read(int id)
        {
            return _context.Read(id);
        }

        public List<User> GetAll()
        {
            return _context.GetAll();
        }

        public int Count()
        {
            return _context.Count();
        }

        public void Register(User obj, string hPassword)
        {
            _context.Register(obj, hPassword);
        }
    }
}