using System.Diagnostics.CodeAnalysis;
using HospSimWebsite.DAL.Contexts.Memory;
using HospSimWebsite.Logic;
using HospSimWebsite.Model;
using HospSimWebsite.Repository;
using Xunit;

namespace HospSimWebsite.Tests.LogicTests
{
    /*[ExcludeFromCodeCoverage]
    public class PatientLogicFixture : IDisposable
    {
        public IPatientLogic Logic;
        
        public PatientLogicFixture()
        {
            Logic = null;
            Logic = new PatientLogic(new PatientRepo(new MemoryPatientContext()));
        }

        public void Dispose()
        {
            Logic = null;

            /*
            var patients = Logic.GetAll().ToList();
            foreach (var patient in patients)
            {
                Logic.Delete(patient.Id);
            }

            Logic = new PatientLogic(new PatientRepo(new MemoryPatientContext()));
            #1#
        }
    }*/
    
    [ExcludeFromCodeCoverage]
    public class PatientLogicTests
    {
        private Patient GenerateValidPatient()
        {
            return new Patient
            {
                Name = "Mark",
                IsApproved = false,
                Disease = new Disease
                {
                    Name = "Asthma",
                    Duration = 5,
                    Severity = 5
                },
                Age = 18
            };
        }
        
        [Fact]
        public void Insert_ValidPatient_True()
        {
            // Arrange
            var logic = new PatientLogic(new PatientRepo(new MemoryPatientContext()));
            var patient = GenerateValidPatient();
            
            // Act
            var isAccepted = logic.Insert(patient);
            
            // Assert
            Assert.True(isAccepted);
        }

        [Fact]
        public void Insert_NegativeAge_False()
        {
            // Arrange
            var logic = new PatientLogic(new PatientRepo(new MemoryPatientContext()));
            var patient = new Patient()
            {
                Name = "Mark",
                Age = -6,
                IsApproved = false
            };
            
            // Act
            var isAccepted = logic.Insert(patient);
            
            // Assert
            Assert.False(isAccepted);
        }

        [Fact]
        public void Insert_NameWhitespace_False()
        {
            // Arrange
            var logic = new PatientLogic(new PatientRepo(new MemoryPatientContext()));
            var patient = new Patient
            {
                Name = " ",
                Age = 18,
                IsApproved = false
            };
            
            // Act
            var isAccepted = logic.Insert(patient);
            
            // Assert
            Assert.False(isAccepted);
        }
        
        [Fact]
        public void Update_ValidPatient_True()
        {
            // Arrange
            var logic = new PatientLogic(new PatientRepo(new MemoryPatientContext()));
            var existingPatient = GenerateValidPatient();
            var patient = existingPatient;
            
            // Act
            logic.Insert(existingPatient);
            var isAccepted = logic.Update(patient);
            
            // Assert
            Assert.True(isAccepted);
        }

        [Fact]
        public void Update_NegativeAge_False()
        {
            // Arrange
            var logic = new PatientLogic(new PatientRepo(new MemoryPatientContext()));
            var existingPatient = GenerateValidPatient();
            var patient = new Patient
            {
                Name = "Mark",
                Age = -6,
                IsApproved = false
            };
            
            // Act
            logic.Insert(existingPatient);
            var isAccepted = logic.Update(patient);
            
            // Assert
            Assert.False(isAccepted);
        }

        [Fact]
        public void Update_NameWhitespace_False()
        {
            // Arrange
            var logic = new PatientLogic(new PatientRepo(new MemoryPatientContext()));
            var existingPatient = GenerateValidPatient();
            var patient = new Patient
            {
                Name = " ",
                Age = 18,
                IsApproved = false
            };
            
            // Act
            logic.Insert(existingPatient);
            var isAccepted = logic.Update(patient);
            
            // Assert
            Assert.False(isAccepted);
        }
        
        /// <summary>
        /// For some reason de memorycontext wilt niet clearen.
        /// </summary>
        [Fact]
        public void Update_PatientDoesNotExist_False()
        {
            // Arrange
            var logic = new PatientLogic(new PatientRepo(new MemoryPatientContext()));
            var patient = GenerateValidPatient();
            
            // Act
            var isAccepted = logic.Update(patient);
            
            // Assert
            Assert.False(isAccepted);
        }
    }
}