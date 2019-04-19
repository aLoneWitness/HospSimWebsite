using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HospSimWebsite.Models;
using HospSimWebsite.Models.Interfaces;
using HospSimWebsite.Repositories;
using HospSimWebsite.Repositories.Contexts;
using HospSimWebsite.Repositories.Contexts.MySQL;

namespace HospSimWebsite.Controllers
{
    public class FormController : Controller
    {
        private PatientRepo _patientRepo;
        private DiseaseRepo _diseaseRepo;
    
        public IActionResult Index(PatientFormModel model)
        {
            try
            {
                _diseaseRepo = new DiseaseRepo(new MySqlDiseaseContext());
            
                model.Diseases = new List<Disease>();
                model.Diseases = _diseaseRepo.GetAll();
            }
            catch(Exception e)
            {
                var errorViewModel = new ErrorViewModel($"A database error occured. Please visit later, {e.ToString()}");
                return View("Error", errorViewModel);
            }
            
            

            return View(model);
        }
        
        public IActionResult Submit(PatientFormModel model)
        {
            _patientRepo = new PatientRepo(new MySqlPatientContext());
            _diseaseRepo = new DiseaseRepo(new MySqlDiseaseContext());
            var age = DateTime.Now.Year - model.Birthday.Year;
            if (DateTime.Now.DayOfYear < model.Birthday.DayOfYear)  
                age = age - 1;  
            
            var patient = new Patient(0, model.Name, age , _diseaseRepo.GetById(model.Disease));
            _patientRepo.Insert(patient);
            
            return View(model);
        }
    }
}