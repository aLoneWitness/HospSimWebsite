using System.Diagnostics;
using HospSimWebsite.Logic.Interfaces;
using HospSimWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDiseaseLogic _diseaseLogic;
        private readonly IPatientLogic _patientLogic;

        public HomeController(IPatientLogic patientLogic, IDiseaseLogic diseaseLogic)
        {
            _patientLogic = patientLogic;
            _diseaseLogic = diseaseLogic;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();

            model.PatientCount = _patientLogic.GetAmount();
            model.DiseaseCount = _diseaseLogic.GetAmount();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel("The response time of the server took too long, a processing error occured.")
                {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}