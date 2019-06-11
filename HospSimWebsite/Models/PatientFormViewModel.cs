using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HospSimWebsite.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospSimWebsite.Models
{
    public class PatientsFormViewModel
    {
        [Required(ErrorMessage = "Please insert a valid name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please insert a valid date of birth.")] 
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Something went wrong, please try again later.")]
        public int Disease { get; set; }
        public List<SelectListItem> Diseases { get; set; }
        public string ErrorMessage { get; set; }
    }
}