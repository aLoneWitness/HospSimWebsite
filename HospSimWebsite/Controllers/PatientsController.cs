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
                ? _patientLogic.GetAll()
                : _patientLogic.GetByName(searchParams, false);

            return View(patientsModel);
        }
        
        public IActionResult RemovePatient(int index)
        {
            _patientLogic.Remove(index);

            return RedirectToAction("Index");
        }
        
        public IActionResult ApprovePatient(int index)
        {
            var patient = _patientLogic.Read(index);
            patient.IsApproved = true;
            _patientLogic.Update(patient);

            return RedirectToAction("Index");
        }
    }
}