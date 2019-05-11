using System.Collections.Generic;
using HospSimWebsite.DAL.MySQL.Contexts.Interfaces;
using HospSimWebsite.Model;
using HospSimWebsite.Repository.Interfaces;

namespace HospSimWebsite.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly IUserContext _context;
        
        public UserRepo(IUserContext context)
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
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            return _context.Count();
        }

        public User Validate(User user)
        {
            return _context.Validate(user);
        }

        public bool Exists(User user)
        {
            return _context.Exists(user);
        }

        public User ReadByUsername(string username)
        {
            return _context.ReadByUsername(username);
        }
    }
}