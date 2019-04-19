using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using HospSimWebsite.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace HospSimWebsite.Models
{
    public class PatientFormModel : IFormModel
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