using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospSimWebsite.Models;
using System.Text.Encodings.Web;

namespace HospSimWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(FormModel model)
        {
            Database.Instance.SetConnection("studmysql01.fhict.local" ,"dbi407041","wonderworld", "dbi407041");
            var userQuery = Database.Instance.Query("SELECT * FROM disease", new string[]{});
            model.Diseases = new List<Disease>();
            for (int i = 0; userQuery.Count > i; i++)
            {
                model.Diseases.Add(new Disease(userQuery[i]["name"].ToString()));
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
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}