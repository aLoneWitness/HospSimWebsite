using System.Diagnostics.CodeAnalysis;
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
            if (user.Username.Length > 28) return RegisterStatus.FailedUsernameTooLong;
            if (_repo.Exists(user)) return RegisterStatus.FailedUsernameTaken;

            // Makes copy of user, so you dont directly insert the hash onto the User object.
            var insertedUser = new User
            {
                Doctor = user.Doctor,
                Highscore = user.Highscore,
                Id = user.Id,
                Name = user.Name,
                Password = _passwordHasher.HashPassword(user, user.Password),
                Patients = user.Patients,
                Username = user.Username
            };
            
            _repo.Insert(insertedUser);
            return RegisterStatus.Success;
        }

        public bool Validate(User user)
        {
            // TODO: Possible security flaw: Validate retrieves entire user file without password. Then checks it.
            var encryptedUser = _repo.Validate(user);
            var verificationResult = _passwordHasher.VerifyHashedPassword(user, encryptedUser.Password, user.Password);
            
            switch (verificationResult)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    return true;
                default:
                    return false;
            }
        }
    }
}