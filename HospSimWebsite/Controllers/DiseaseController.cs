using HospSimWebsite.Models;
using HospSimWebsite.Repository;
using HospSimWebsite.Repository.Contexts.MySQL;
using HospSimWebsite.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class DiseaseController : Controller
    {
        private readonly IDiseaseRepo _diseaseRepo;
        private readonly IPatientRepo _patientRepo;

        public DiseaseController(IPatientRepo patientRepo, IDiseaseRepo diseaseRepo)
        {
            _diseaseRepo = diseaseRepo;
            _patientRepo = patientRepo;
        }
        // GET
        public IActionResult Index(int id)
        {
            var model = new DiseaseViewModel();
            
            var disease = _diseaseRepo.GetById(id);
            model.Name = disease.Name;
            model.Description = disease.Description;
            model.Patients = _patientRepo.GetByDisease(id);
            
            return View(model);
        }
    }
}