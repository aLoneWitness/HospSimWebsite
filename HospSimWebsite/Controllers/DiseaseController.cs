using System;
using HospSimWebsite.Models;
using HospSimWebsite.Repositories;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace HospSimWebsite.Controllers
{
    public class DiseaseController : Controller
    {
        private DiseaseViewModel _model;

        private DiseaseRepo _diseaseRepo;
        // GET
        public IActionResult Index(int id)
        {
            try
            {
                _model = new DiseaseViewModel();
                _diseaseRepo = new DiseaseRepo();
                var disease = _diseaseRepo.GetById(id);

                _model.Name = disease.Name;
                _model.Descriptions = disease.Descriptions;
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