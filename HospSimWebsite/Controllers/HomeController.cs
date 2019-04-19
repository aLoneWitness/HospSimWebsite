using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HospSimWebsite.Models;
using HospSimWebsite.Repositories;
using HospSimWebsite.Repositories.Contexts;
using HospSimWebsite.Repositories.Contexts.MySQL;

namespace HospSimWebsite.Controllers
{
    public class HomeController : Controller
    {
        private PatientRepo _patientRepo;
        private DiseaseRepo _diseaseRepo;
        public IActionResult Index()
        {
            var model = new HomeViewModel();
            _patientRepo = new PatientRepo(new MySqlPatientContext());
            _diseaseRepo = new DiseaseRepo(new MySqlDiseaseContext());

            model.PatientCount = _patientRepo.GetAmount();
            model.DiseaseCount = _diseaseRepo.GetAmount();
            
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel("The response time of the server took too long, a processing error occured.") {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        
    }
}