using System;
using Microsoft.AspNetCore.Mvc;
using HospSimWebsite.Models;
using HospSimWebsite.Repositories;

namespace HospSimWebsite.Controllers
{
    public class FormController : Controller
    {
        private PatientRepo _patientRepo;
        
        [HttpPost]
        public IActionResult Submit(FormModel model)
        {
            _patientRepo = new PatientRepo();
            if (model.Name != String.Empty)
            {
                _patientRepo.Insert(new Patient(model.Name, Convert.ToInt16(model.AdressNum)));
            }
            
            return View(model);
        }
    }
}