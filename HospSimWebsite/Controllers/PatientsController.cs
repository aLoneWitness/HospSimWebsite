using System.Collections.Generic;
using HospSimWebsite.Models;
using HospSimWebsite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class PatientsController : Controller
    {
        private PatientRepo _patientRepo;

        private PatientsModel _patientsModel;
        // GET
        public IActionResult Index()
        {
            _patientRepo = new PatientRepo();
            _patientsModel = new PatientsModel();
            _patientsModel.Patients = _patientRepo.GetAll();
               
            return View(_patientsModel);
        }
        
        public IActionResult RemovePatient()
        {
            _patientRepo = new PatientRepo();
            
            //_patientRepo.Remove(index);
            
            return RedirectToAction("Index", new {});
        }
        [HttpGet]
        public IActionResult RemovePatient(int index)
        {
            _patientRepo = new PatientRepo();
            
            _patientRepo.Remove(index);

            return RedirectToAction("Index");
        }
    }
}