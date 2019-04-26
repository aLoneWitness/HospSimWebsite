using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HospSimWebsite.Model;

namespace HospSimWebsite.Models
{
    public class PatientsViewModel
    {
        [Required] public List<Patient> Patients;
    }
}