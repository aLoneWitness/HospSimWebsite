using System;
using System.Collections.Generic;
using System.Linq;
using HospSimWebsite.DAL.Contexts.Interfaces;
using HospSimWebsite.Model;
using Microsoft.Extensions.ObjectPool;

namespace HospSimWebsite.DAL.Contexts.Memory
{
    public class MemoryUserContext : IUserContext
    {
        private List<User> _users;

        public MemoryUserContext()
        {
            _users = new List<User>();
        }
        public void Insert(User obj)
        {
            _users.Insert(obj.Id, obj);
        }

        public bool Update(User obj)
        {
            _users[obj.Id] = obj;
            return true;
        }

        public void Delete(int id)
        {
            _users.RemoveAt(id);
        }

        public User Read(int id)
        {
            return _users[id];
        }

        public int Count()
        {
            return _users.Count;
        }

        public bool Exists(User user)
        {
            return _users.Exists(user1 => user1.Id == user.Id);
        }

        public User Validate(User user)
        {
            return _users.First(user1 => user1.Username == user.Username);
        }
    }
}