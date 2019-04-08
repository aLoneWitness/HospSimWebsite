using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HospSimWebsite.Models;
using HospSimWebsite.Repositories;
using HospSimWebsite.Repositories.Contexts;

namespace HospSimWebsite.Controllers
{
    public class FormController : Controller
    {
        private PatientRepo _patientRepo;
        private DiseaseRepo _diseaseRepo;
        
        [HttpPost]
        public IActionResult Submit(FormModel model)
        {
            _patientRepo = new PatientRepo(new MySqlPatientContext());
            _diseaseRepo = new DiseaseRepo(new MySqlDiseaseContext());
            var age = DateTime.Now.Year - model.Birthday.Year;
            if (DateTime.Now.DayOfYear < model.Birthday.DayOfYear)  
                age = age - 1;  
            
            var patient = new Patient(model.Name, age , _diseaseRepo.GetById(model.Disease));
            _patientRepo.Insert(patient);
            
            return View(model);
        }
    }
}