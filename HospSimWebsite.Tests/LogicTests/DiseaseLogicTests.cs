using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using HospSimWebsite.DAL.Contexts.Memory;
using HospSimWebsite.Logic;
using HospSimWebsite.Model;
using HospSimWebsite.Repository;
using Xunit;


namespace HospSimWebsite.Tests.LogicTests
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
            var logic = new DiseaseLogic(new DiseaseRepo(new MemoryDiseaseContext()));
            var disease = GenerateValidDisease();
            
            // Act
            disease.Duration = -1;
            var isAccepted = logic.Insert(disease);
            
            // Assert
            Assert.False(isAccepted);
        }

        [Fact]
        public void Insert_SeverityNegative_False()
        {
            var logic = new DiseaseLogic(new DiseaseRepo(new MemoryDiseaseContext()));
            var disease = GenerateValidDisease();
            
            // Act
            disease.Severity = -1;
            var isAccepted = logic.Insert(disease);
            
            // Assert
            Assert.False(isAccepted);
        }

        [Fact]
        public void Insert_NotThreeDescriptions_False()
        {
            var logic = new DiseaseLogic(new DiseaseRepo(new MemoryDiseaseContext()));
            var disease = GenerateValidDisease();
            
            // Act
            disease.Descriptions = new List<string>
            {
                "Mark",
                "Zucc"
            };
            var isAccepted = logic.Insert(disease);
            
            // Assert
            Assert.False(isAccepted);
        }
    }
}