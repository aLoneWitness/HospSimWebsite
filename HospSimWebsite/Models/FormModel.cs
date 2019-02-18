using System;
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
        public string Disease { get; set; }

 
    }
}