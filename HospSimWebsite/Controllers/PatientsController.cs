using System.Collections.Generic;
using HospSimWebsite.Models;
using HospSimWebsite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class PatientsController : Controller
    {
        private PatientRepo _patientRepo;
        // GET
        public IActionResult Index(PatientsModel model)
        {
            _patientRepo = new PatientRepo();
            
            model.Patients = new List<Patient>();
            model.Patients = _patientRepo.GetAll();

            return View(model);
        }
    }
}