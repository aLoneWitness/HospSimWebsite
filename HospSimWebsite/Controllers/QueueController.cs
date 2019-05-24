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
                Patients = _patientLogic.GetAllUnapproved()
            };

            return View(model);
        }
        
        [HttpPost]
        public void ApprovePatient(int id)
        {
            var approvedPatient = _patientLogic.Read(id);
            approvedPatient.IsApproved = true;
            _patientLogic.Update(approvedPatient);
        }

        [HttpPost]
        public void DenyPatient(int id)
        {
            _patientLogic.Delete(id);
        }
    }
}