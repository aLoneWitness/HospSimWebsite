using System;
using System.Collections.Generic;
using HospSimWebsite.Logic.Interfaces;
using HospSimWebsite.Model;
using HospSimWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class FormController : Controller
    {
        private readonly IDiseaseLogic _diseaseLogic;
        private readonly IPatientLogic _patientLogic;

        public FormController(IPatientLogic patientLogic, IDiseaseLogic diseaseLogic)
        {
            _patientLogic = patientLogic;
            _diseaseLogic = diseaseLogic;
        }

        public IActionResult Index(PatientFormViewModel viewModel)
        {
            viewModel.Diseases = new List<Disease>();
            viewModel.Diseases = _diseaseLogic.GetAll();

            return View(viewModel);
        }

        public IActionResult Submit(PatientFormViewModel viewModel)
        {
            var age = DateTime.Now.Year - viewModel.Birthday.Year;
            if (DateTime.Now.DayOfYear < viewModel.Birthday.DayOfYear)
                age = age - 1;

            var patient = new Patient(0, viewModel.Name, age, _diseaseLogic.GetById(viewModel.Disease));
            _patientLogic.Insert(patient);

            return View(viewModel);
        }
    }
}