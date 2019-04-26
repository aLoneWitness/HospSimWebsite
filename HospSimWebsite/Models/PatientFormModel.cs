using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HospSimWebsite.Model;

namespace HospSimWebsite.Models
{
    public class PatientFormViewModel
    {
        [Required] public string Name { get; set; }

        [Required] public DateTime Birthday { get; set; }

        [Required] public int Disease { get; set; }

        [Required] public List<Disease> Diseases { get; set; }
    }
}