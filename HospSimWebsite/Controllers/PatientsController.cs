using HospSimWebsite.Models;
using HospSimWebsite.Repository;
using HospSimWebsite.Repository.Contexts.MySQL;
using HospSimWebsite.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientRepo _patientRepo;

        public PatientsController(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public IActionResult Index(string searchParams = null)
        {
            var patientsModel = new PatientsViewModel();
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