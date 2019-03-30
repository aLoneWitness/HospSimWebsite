using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace HospSimWebsite.Models
{
    public class FormModel
    {
        public string Name { get; set; }

        public DateTime Birthday { get; set; }
        public int Disease { get; set; }
        public List<Disease> Diseases { get; set; }

        public bool HasEmpty()
        {
            bool hasEmpty = false;

            if (string.IsNullOrWhiteSpace(Name))
            {
                hasEmpty = true;
            }
            else if(Birthday == null)
            {
                hasEmpty = true;
            }

            return hasEmpty;
        }
    }
}