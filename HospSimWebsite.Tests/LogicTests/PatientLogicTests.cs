using System;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using HospSimWebsite.DAL.Contexts.Memory;
using HospSimWebsite.Logic;
using HospSimWebsite.Logic.Interfaces;
using HospSimWebsite.Model;
using HospSimWebsite.Repository;
using Xunit;
using Xunit.Sdk;

namespace HospSimWebsite.Tests.LogicTests
{
    [ExcludeFromCodeCoverage]
    public class PatientLogicFixture : IDisposable
    {
        public IPatientLogic Logic { get; private set; }
        
        public PatientLogicFixture()
        {
            Logic = null;
            Logic = new PatientLogic(new PatientRepo(new MemoryPatientContext()));
        }

        public void Dispose()
        {
            Logic = null;
        }
    }
    [ExcludeFromCodeCoverage]
    public class PatientLogicTests : IClassFixture<PatientLogicFixture>
    {
        private PatientLogicFixture _fixture;

        public PatientLogicTests(PatientLogicFixture fixture)
        {
            _fixture = fixture;
        }
        
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
            var patient = GenerateValidPatient();
            
            // Act
            var isAccepted =_fixture.Logic.Insert(patient);
            
            // Assert
            Assert.True(isAccepted);
        }

        [Fact]
        public void Insert_NegativeAge_False()
        {
            // Arrange
            var patient = new Patient()
            {
                Name = "Mark",
                Age = -6,
                IsApproved = false
            };
            
            // Act
            var isAccepted = _fixture.Logic.Insert(patient);
            
            // Assert
            Assert.False(isAccepted);
        }

        [Fact]
        public void Insert_NameWhitespace_False()
        {
            // Arrange
            var patient = new Patient
            {
                Name = " ",
                Age = 18,
                IsApproved = false
            };
            
            // Act
            var isAccepted = _fixture.Logic.Insert(patient);
            
            // Assert
            Assert.False(isAccepted);
        }
        
        [Fact]
        public void Update_ValidPatient_True()
        {
            // Arrange
            var existingPatient = GenerateValidPatient();
            var patient = existingPatient;
            
            // Act
            _fixture.Logic.Insert(existingPatient);
            var isAccepted = _fixture.Logic.Update(patient);
            
            // Assert
            Assert.True(isAccepted);
        }

        [Fact]
        public void Update_NegativeAge_False()
        {
            // Arrange
            var existingPatient = GenerateValidPatient();
            var patient = new Patient
            {
                Name = "Mark",
                Age = -6,
                IsApproved = false
            };
            
            // Act
            _fixture.Logic.Insert(existingPatient);
            var isAccepted = _fixture.Logic.Update(patient);
            
            // Assert
            Assert.False(isAccepted);
        }

        [Fact]
        public void Update_NameWhitespace_False()
        {
            // Arrange
            var existingPatient = GenerateValidPatient();
            var patient = new Patient
            {
                Name = " ",
                Age = 18,
                IsApproved = false
            };
            
            // Act
            _fixture.Logic.Insert(existingPatient);
            var isAccepted = _fixture.Logic.Update(patient);
            
            // Assert
            Assert.False(isAccepted);
        }

        [Fact]
        public void Update_PatientDoesNotExist_False()
        {
            // Arrange
            var patient = GenerateValidPatient();
            
            // Act
            var isAccepted = _fixture.Logic.Update(patient);
            
            // Assert
            Assert.False(isAccepted);
        }
    }
}