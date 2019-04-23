using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospSimWebsite.Models
{
    public class PatientsModel
    {
        [Required] 
        public List<Patient> Patients;
    }
}