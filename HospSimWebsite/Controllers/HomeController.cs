using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HospSimWebsite.Models;
using HospSimWebsite.Repositories;

namespace HospSimWebsite.Controllers
{
    public class HomeController : Controller
    {
        private DiseaseRepo _diseaseRepo;
        public IActionResult Index(FormModel model)
        {
            try
            {
                _diseaseRepo = new DiseaseRepo();
            
                model.Diseases = new List<Disease>();
                model.Diseases = _diseaseRepo.GetAll();
            }
            catch(Exception e)
            {
                var errorViewModel = new ErrorViewModel($"A database error occured. Please visit later, {e.ToString()}");
                return View("Error", errorViewModel);
            }
            
            

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel("The response time of the server took too long, a processing error occured.") {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        
    }
}