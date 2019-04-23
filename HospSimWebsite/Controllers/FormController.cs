using System;
using System.Collections.Generic;
using HospSimWebsite.Models;
using HospSimWebsite.Repository;
using HospSimWebsite.Repository.Contexts.MySQL;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class FormController : Controller
    {
        private readonly PatientRepo _patientRepo;
        private readonly DiseaseRepo _diseaseRepo;

        public FormController()
        {
            _patientRepo = new PatientRepo(new MySqlPatientContext());
            _diseaseRepo = new DiseaseRepo(new MySqlDiseaseContext());
        }
        public IActionResult Index(PatientFormViewModel viewModel)
        {
            viewModel.Diseases = new List<Disease>();
            viewModel.Diseases = _diseaseRepo.GetAll();

            return View(viewModel);
        }
        
        public IActionResult Submit(PatientFormViewModel viewModel)
        {
            var age = DateTime.Now.Year - viewModel.Birthday.Year;
            if (DateTime.Now.DayOfYear < viewModel.Birthday.DayOfYear)  
                age = age - 1;  
            
            var patient = new Patient(0, viewModel.Name, age , _diseaseRepo.GetById(viewModel.Disease));
            _patientRepo.Insert(patient);
            
            return View(viewModel);
        }
    }
}