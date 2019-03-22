using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HospSimWebsite.Models;
using HospSimWebsite.Repositories;

namespace HospSimWebsite.Controllers
{
    public class FormController : Controller
    {
        private PatientRepo _patientRepo;
        private DiseaseRepo _diseaseRepo;
        
        [HttpPost]
        public IActionResult Submit(FormModel model)
        {
            _patientRepo = new PatientRepo();
            _diseaseRepo = new DiseaseRepo();
            if (model.Name != String.Empty)
            {
                var patient = new Patient(model.Name, Convert.ToInt16(model.AdressNum), _diseaseRepo.GetById(model.Disease));
                _patientRepo.Insert(patient);
            }
            
            return View(model);
        }
    }
}