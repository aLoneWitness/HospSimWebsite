using System;
using System.Collections.Generic;
using System.Linq;
using HospSimWebsite.Logic.Interfaces;
using HospSimWebsite.Model;
using HospSimWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class FormController : Controller
    {
        private readonly IDiseaseLogic _diseaseLogic;
        private readonly IPatientLogic _patientLogic;

        public FormController(IPatientLogic patientLogic, IDiseaseLogic diseaseLogic)
        {
            _patientLogic = patientLogic;
            _diseaseLogic = diseaseLogic;
        }

        public IActionResult Index(PatientSubmitViewModel viewModel)
        {
            viewModel.Diseases = new List<Disease>();
            viewModel.Diseases = _diseaseLogic.GetAll();

            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(PatientSubmitViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var age = DateTime.Now.Year - viewModel.Birthday.Year;
                if (DateTime.Now.DayOfYear < viewModel.Birthday.DayOfYear)
                    age = age - 1;

                var patient = new Patient{
                    Name = viewModel.Name, 
                    Age = age, 
                    Disease = _diseaseLogic.Read(viewModel.Disease)
                };
                
                if (_patientLogic.Insert(patient))
                {
                    return View(viewModel);
                }

                return RedirectToAction("Error", "Home", new ErrorViewModel("The patient could not be registered due to an internal error."));

            }
            else
            {
                viewModel.ErrorMessage = ModelState.Values.First().Errors[0].ErrorMessage;
                return RedirectToAction("Index", "Form", viewModel);
            }
        }
    }
}