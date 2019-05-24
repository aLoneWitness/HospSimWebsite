using HospSimWebsite.Logic.Interfaces;
using HospSimWebsite.Model;
using HospSimWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class QueueController : Controller
    {
        private IPatientLogic _patientLogic;

        public QueueController(IPatientLogic patientLogic)
        {
            _patientLogic = patientLogic;
        }
        
        public IActionResult Index()
        {
            var model = new QueueViewModel
            {
                Patient = _patientLogic.GetAllUnapproved()
            };

            return Json(model);
        }
        
        [HttpPost]
        public void ApprovePatient(Patient patient)
        {
            var approvedPatient = _patientLogic.Read(patient.Id);
            approvedPatient.IsApproved = true;
            _patientLogic.Update(approvedPatient);
        }

        [HttpPost]
        public void DenyPatient(Patient patient)
        {
            _patientLogic.Delete(patient.Id);
        }
    }
}