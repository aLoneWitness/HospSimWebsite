using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HospSimWebsite.Repositories;


namespace HospSimWebsite.Models
{
    public class PatientsModel
    {
        [Required] 
        public List<Patient> Patients;
    }
}