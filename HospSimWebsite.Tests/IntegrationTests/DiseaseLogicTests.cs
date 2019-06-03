using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using HospSimWebsite.DAL.Contexts.Memory;
using HospSimWebsite.Logic;
using HospSimWebsite.Model;
using HospSimWebsite.Repository;
using Xunit;

namespace HospSimWebsite.Tests.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    public class DiseaseLogicTests
    {
        private Disease GenerateValidDisease()
        {
            return new Disease
            {
                Id = 0,
                Name = "Asthma",
                Duration = 15,
                Severity = 5,
                Descriptions = new List<string>{
                    "Hey",
                    "Dey",
                    "Mey"
            }};
        }
        
        [Fact]
        public void Insert_ValidDisease_True()
        {
            // Arrange
            var logic = new DiseaseLogic(new DiseaseRepo(new MemoryDiseaseContext()));
            var disease = GenerateValidDisease();
            
            // Act
            var isAccepted = logic.Insert(disease);
            
            // Assert
            Assert.True(isAccepted);
        }

        [Fact]
        public void Insert_DurationNegative_False()
        {
            // Arrange
            var logic = new DiseaseLogic(new DiseaseRepo(new MemoryDiseaseContext()));
            var disease = GenerateValidDisease();
            disease.Duration = -1;

            // Act
            var isAccepted = logic.Insert(disease);
            
            // Assert
            Assert.False(isAccepted);
        }

        [Fact]
        public void Insert_SeverityNegative_False()
        {
            // Arrange
            var logic = new DiseaseLogic(new DiseaseRepo(new MemoryDiseaseContext()));
            var disease = GenerateValidDisease();
            disease.Severity = -1;

            // Act
            var isAccepted = logic.Insert(disease);
            
            // Assert
            Assert.False(isAccepted);
        }

        [Fact]
        public void Insert_NotThreeDescriptions_False()
        {
            // Arrange
            var logic = new DiseaseLogic(new DiseaseRepo(new MemoryDiseaseContext()));
            var disease = GenerateValidDisease();
            disease.Descriptions = new List<string>
            {
                "Mark",
                "Zucc"
            };
            
            // Act
            var isAccepted = logic.Insert(disease);
            
            // Assert
            Assert.False(isAccepted);
        }

        [Fact]
        public void Update_ExistingObject_True()
        {
            // Arrange
            var logic = new DiseaseLogic(new DiseaseRepo(new MemoryDiseaseContext()));
            var disease = GenerateValidDisease();
            var updatedDisease = disease;
            disease.Name = "UpdatedName";
            
            // Act
            logic.Insert(disease);
            var isAccepted = logic.Update(updatedDisease);
            
            // Assert
            Assert.True(isAccepted);
        }

        [Fact]
        public void Insert_AlreadyExistsInContext_False()
        {
            // Arrange
            var logic = new DiseaseLogic(new DiseaseRepo(new MemoryDiseaseContext()));
            var disease = GenerateValidDisease();
            
            // Act
            logic.Insert(disease);
            var isAccepted = logic.Insert(disease);
            
            // Assert
            Assert.False(isAccepted);
        }

        [Fact]
        public void Update_NotExistingObject_False()
        {
            // Arrange
            var logic = new DiseaseLogic(new DiseaseRepo(new MemoryDiseaseContext()));
            var disease = GenerateValidDisease();
            
            // Act
            var isAccepted = logic.Update(disease);
            
            // Assert
            Assert.False(isAccepted);
        }
    }
}