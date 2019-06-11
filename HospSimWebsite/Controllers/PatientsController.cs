using System;
using System.Collections.Generic;
using System.Linq;
using HospSimWebsite.Logic.Interfaces;
using HospSimWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientLogic _patientLogic;

        public PatientsController(IPatientLogic patientLogic)
        {
            _patientLogic = patientLogic;
        }

        public IActionResult Index(string searchParams = "")
        {
            var patientsModel = new PatientsViewModel();
            patientsModel.Patients = new List<PatientViewModel>();

            foreach (var patient in _patientLogic.GetByName(searchParams, false).Where(patient => patient.IsApproved))
            {
                patientsModel.Patients.Add(new PatientViewModel
                {
                    Id = patient.Id,
                    Name = patient.Name,
                    Age = patient.Age,
                    Disease = new DiseaseViewModel
                    {
                        Id = patient.Disease.Id
                    }
                });
            }

            return View(patientsModel);
        }
        
        public IActionResult RemovePatient(int index)
        {
            _patientLogic.Remove(index);

            return RedirectToAction("Index");
        }
        
        
    }
}