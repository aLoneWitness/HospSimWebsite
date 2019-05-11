using System;
using HospSimWebsite.Logic.Enums;
using HospSimWebsite.Logic.Interfaces;
using HospSimWebsite.Model;
using HospSimWebsite.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HospSimWebsite.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepo _repo;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserLogic(IUserRepo repo)
        {
            _repo = repo;
            _passwordHasher = new PasswordHasher<User>();
        }

        public RegisterStatus Register(User user)
        {
            if (_repo.Exists(user)) return RegisterStatus.FailedUsernameTaken;
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            _repo.Insert(user);
            return RegisterStatus.Success;
        }

        public bool Validate(User user)
        {
            var encryptedUser = _repo.ReadByUsername(user.Username);
            var verificationResult = _passwordHasher.VerifyHashedPassword(user, encryptedUser.Password, user.Password);
            switch (verificationResult)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    return true;
            }

            return false;
        }
    }
}