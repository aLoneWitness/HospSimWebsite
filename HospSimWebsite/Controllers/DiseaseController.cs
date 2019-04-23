using HospSimWebsite.Models;
using HospSimWebsite.Repository;
using HospSimWebsite.Repository.Contexts.MySQL;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class DiseaseController : Controller
    {
        private readonly DiseaseRepo _diseaseRepo;
        private readonly PatientRepo _patientRepo;

        public DiseaseController()
        {
            _diseaseRepo = new DiseaseRepo(new MySqlDiseaseContext());
            _patientRepo = new PatientRepo(new MySqlPatientContext());
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