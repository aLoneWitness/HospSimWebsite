using HospSimWebsite.Models;
using HospSimWebsite.Repository;
using HospSimWebsite.Repository.Contexts.MySQL;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class PatientsController : Controller
    {
        private readonly PatientRepo _patientRepo;

        public PatientsController()
        {
            _patientRepo = new PatientRepo(new MySqlPatientContext());
        }

        public IActionResult Index(string searchParams = null)
        {
            var patientsModel = new PatientsModel();
            patientsModel.Patients = searchParams == null ? _patientRepo.GetAll() : _patientRepo.GetByName(searchParams, false);
            
            return View(patientsModel);
        }
        
        public IActionResult RemovePatient(int index)
        {
            _patientRepo.Remove(index);

            return RedirectToAction("Index");
        }

    }
}