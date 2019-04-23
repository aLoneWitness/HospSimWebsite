using System;
using System.Collections.Generic;
using System.Linq;
using HospSimWebsite.Models.Interfaces;

namespace HospSimWebsite.Models
{
    public class PatientFormViewModel : IFormViewModel
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Disease { get; set; }
        public List<Disease> Diseases { get; set; }

        public bool HasEmpty()
        {
            return GetType().GetProperties()
                .All(p => p.GetValue(this) != null);
        }
    }
}