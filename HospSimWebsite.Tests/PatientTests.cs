using System.Collections.Generic;
using HospSimWebsite.Model;

namespace HospSimWebsite.Tests
{
    public class PatientTests
    {
        public void Test_AddValidPatient_ShouldSucceed()
        {
            // Arrange
            var patient = new Patient(0, "Mark Zuckerberg", 28, new Disease(1, "Asthma", 5, 5, new List<string>({"Test", "Test", "Test"}));
            var patient
            // Act
                        
        }

        public void Test_AddInvalidPatient_ShouldFail()
        {
            
        }
    }
}