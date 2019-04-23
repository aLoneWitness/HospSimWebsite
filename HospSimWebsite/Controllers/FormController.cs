using System;
using System.Collections.Generic;
using HospSimWebsite.Model;
using HospSimWebsite.Models;
using HospSimWebsite.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class FormController : Controller
    {
        private readonly IPatientRepo _patientRepo;
        private readonly IDiseaseRepo _diseaseRepo;

        public FormController(IPatientRepo patientRepo, IDiseaseRepo diseaseRepo)
        {

            _patientRepo = patientRepo;
            _diseaseRepo = diseaseRepo;
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