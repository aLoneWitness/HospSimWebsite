using System.Diagnostics;
using HospSimWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using HospSimWebsite.Repository;
using HospSimWebsite.Repository.Contexts.MySQL;
using HospSimWebsite.Repository.Interfaces;

namespace HospSimWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPatientRepo _patientRepo;
        private readonly IDiseaseRepo _diseaseRepo;
        
        public HomeController(IPatientRepo patientRepo, IDiseaseRepo diseaseRepo)
        {
            _patientRepo = patientRepo;
            _diseaseRepo = diseaseRepo;
        }
        public IActionResult Index()
        {
            var model = new HomeViewModel();

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