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
        public string AdressText { get; set; }
        public string AdressNum { get; set; }
        public int Disease { get; set; }
        public List<Disease> Diseases { get; set; }

        public bool HasEmpty()
        {
            bool hasEmpty = false;

            if (string.IsNullOrWhiteSpace(Name))
            {
                hasEmpty = true;
            }
            else if(string.IsNullOrWhiteSpace(AdressText))
            {
                hasEmpty = true;
            }
            else if(string.IsNullOrWhiteSpace(AdressNum))
            {
                hasEmpty = true;
            }

            return hasEmpty;
        }
    }
}