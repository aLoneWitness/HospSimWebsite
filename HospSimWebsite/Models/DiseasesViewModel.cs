using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HospSimWebsite.Model;

namespace HospSimWebsite.Models
{
    public class DiseasesViewModel
    {
        [Required] public List<string> Descriptions;

        [Required] public string Name;

        public List<Patient> Patients;
    }
}