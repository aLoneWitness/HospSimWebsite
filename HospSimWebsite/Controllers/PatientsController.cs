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

        public IActionResult Index(string searchParams = null)
        {
            var patientsModel = new PatientsViewModel();
            patientsModel.Patients = searchParams == null
                ? _patientLogic.GetAll().Where(patient => patient.IsApproved).ToList()
                : _patientLogic.GetByName(searchParams, false).Where(patient => patient.IsApproved).ToList();

            return View(patientsModel);
        }
        
        public IActionResult RemovePatient(int index)
        {
            _patientLogic.Remove(index);

            return RedirectToAction("Index");
        }
        
        
    }
}