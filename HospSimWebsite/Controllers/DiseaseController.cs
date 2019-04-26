using HospSimWebsite.Logic.Interfaces;
using HospSimWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class DiseaseController : Controller
    {
        private readonly IDiseaseLogic _diseaseLogic;
        private readonly IPatientLogic _patientLogic;

        public DiseaseController(IPatientLogic patientLogic, IDiseaseLogic diseaseLogic)
        {
            _patientLogic = patientLogic;
            _diseaseLogic = diseaseLogic;
        }

        // GET
        public IActionResult Index(int id)
        {
            var model = new DiseaseViewModel();

            var disease = _diseaseLogic.GetById(id);
            model.Name = disease.Name;
            model.Descriptions = disease.Descriptions;
            model.Patients = _patientLogic.GetByDisease(disease);

            return View(model);
        }
    }
}