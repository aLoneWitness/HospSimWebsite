using System;
using HospSimWebsite.Models;
using HospSimWebsite.Repositories;
using HospSimWebsite.Repositories.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class DiseaseController : Controller
    {
        private DiseaseViewModel _model;

        private DiseaseRepo _diseaseRepo;
        private PatientRepo _patientRepo;
        
        // GET
        public IActionResult Index(int id)
        {
            try
            {
                _model = new DiseaseViewModel();
                _diseaseRepo = new DiseaseRepo(new MySqlDiseaseContext());
                _patientRepo = new PatientRepo(new MySqlPatientContext());
                
                var disease = _diseaseRepo.GetById(id);

                _model.Name = disease.Name;
                _model.Description = disease.Description;
                _model.Patients = _patientRepo.GetByDisease(id);
            }
            
            catch(Exception e)
            {
                var errorViewModel = new ErrorViewModel($"A database error occured. Please visit later, {e.ToString()}");
                return View("Error", errorViewModel);
            }
            
            
            return View(_model);
        }
    }
}