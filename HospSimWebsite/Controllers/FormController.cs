using System;
using System.Collections.Generic;
using System.Linq;
using HospSimWebsite.Logic.Interfaces;
using HospSimWebsite.Model;
using HospSimWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult Index(PatientsFormViewModel viewModel)
        {
            if (viewModel == null)
            {
                viewModel = new PatientsFormViewModel();
            }
            
            viewModel.Diseases = new List<SelectListItem>();
            
            foreach (var disease in _diseaseLogic.GetAll())
            {
                viewModel.Diseases.Add(new SelectListItem {Text = disease.Name, Value = disease.Id.ToString()});
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(PatientsFormViewModel viewModel)
        {
            
            if (ModelState.IsValid)
            {
                var age = DateTime.Now.Year - viewModel.Birthday.Value.Year;
                if (DateTime.Now.DayOfYear < viewModel.Birthday.Value.DayOfYear)
                    age = age - 1;

                var patient = new Patient{
                    Name = viewModel.Name, 
                    Age = age, 
                    Disease = _diseaseLogic.Read(viewModel.Disease.Value)
                };
                
                if (_patientLogic.Insert(patient))
                {
                    return View(viewModel);
                }

                return RedirectToAction("Error", "Home", new ErrorViewModel("The patient could not be registered due to an internal error."));
            }
            return RedirectToAction("Index", "Form", viewModel);
        }
    }
}