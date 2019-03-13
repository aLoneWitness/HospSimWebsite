using System.Collections.Generic;
using HospSimWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class PatientsController : Controller
    {
        // GET
        public IActionResult Index(PatientsModel model)
        {
            model.Patients = new List<Patient>();
            for (int i = 0; i < 10; i++)
            {
                model.Patients.Add(new Patient(i, "harry", i * i));
            }

            return View(model);
        }
    }
}