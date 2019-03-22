using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospSimWebsite.Models
{
    public class DiseaseViewModel
    {
        [Required]
        public string Name;
        
        [Required]
        public List<String> Descriptions;
    }
}