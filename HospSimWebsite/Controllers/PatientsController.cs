using System.Collections.Generic;
using System.Text.Encodings.Web;
using HospSimWebsite.Databases;
using HospSimWebsite.Models;
using HospSimWebsite.Repositories;
using HospSimWebsite.Repositories.Contexts;
using HospSimWebsite.Repositories.Contexts.MySQL;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class PatientsController : Controller
    {
        private PatientRepo _patientRepo;

        private PatientsModel _patientsModel;
        // GET
        public IActionResult Index(string searchParams = null)
        {
            _patientRepo = new PatientRepo(new MySqlPatientContext());
            _patientsModel = new PatientsModel();
            
            if (searchParams == null)
            {
                _patientsModel.Patients = _patientRepo.GetAll();
            }
            else
            {
                _patientsModel.Patients = _patientRepo.GetByName(searchParams, false);
            }
            
            
            return View(_patientsModel);
        }
        
        public IActionResult RemovePatient()
        {
            _patientRepo = new PatientRepo(new MySqlPatientContext());
            
            //_patientRepo.Remove(index);
            
            return RedirectToAction("Index", new {});
        }
        [HttpGet]
        public IActionResult RemovePatient(int index)
        {
            _patientRepo = new PatientRepo(new MySqlPatientContext());
            
            _patientRepo.Remove(index);

            return RedirectToAction("Index");
        }

    }
}