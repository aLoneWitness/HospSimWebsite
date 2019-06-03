using System.Collections.Generic;
using HospSimWebsite.DAL.Contexts.Memory;
using HospSimWebsite.Logic;
using HospSimWebsite.Logic.Enums;
using HospSimWebsite.Model;
using HospSimWebsite.Repository;
using Xunit;

namespace HospSimWebsite.Tests.IntegrationTests
{
    public class UserLogicTests
    {
        private User GenerateValidUser()
        {
            return new User()
            {
                Id = 0,
                Patients = new List<Patient>(),
                Doctor = new Doctor(),
                Highscore = 10,
                Name = "Mark Sparla",
                Username = "SparlaSparta182",
                Password = "Ikbenookklant"
            };
        }

        [Fact]
        public void Register_UserAlreadyExists_AppropiateEnum()
        {
            // Arrange
            var logic = new UserLogic(new UserRepo(new MemoryUserContext()));
            var user = GenerateValidUser();
            
            // Act
            logic.Register(user);
            var isAccepted = logic.Register(user);
            
            // Assert
            Assert.Equal(RegisterStatus.FailedUsernameTaken, isAccepted);
        }

        [Fact]
        public void Register_NewUser_AppropiateEnum()
        {
            // Arrange
            var logic = new UserLogic(new UserRepo(new MemoryUserContext()));
            var user = GenerateValidUser();
            
            // Act
            var isAccepted = logic.Register(user);
            
            // Assert
            Assert.Equal(RegisterStatus.Success, isAccepted);
        }

        [Fact]
        public void Register_UserNameTooLong_AppopiateEnum()
        {
            var logic = new UserLogic(new UserRepo(new MemoryUserContext()));
            var user = GenerateValidUser();
            user.Username = "fhadsfdfuasddfasdkjfuisdhfjdshfjsdahfjsahfjsfsd";
            
            // Act
            var isAccepted = logic.Register(user);
            
            // Assert
            Assert.Equal(RegisterStatus.FailedUsernameTooLong, isAccepted);
        }
    }
}