using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HospSimWebsite.Model;

namespace HospSimWebsite.Models
{
    public class DiseaseViewModel
    {
        [Required]
        public string Name;
        
        [Required]
        public List<string> Descriptions;

        public List<Patient> Patients;
    }
}