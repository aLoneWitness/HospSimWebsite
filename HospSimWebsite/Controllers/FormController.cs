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
    public class FormController : Controller
    {
        [HttpPost]
        public IActionResult Submit(FormModel model)
        {
            if (model.Name != String.Empty)
            {
                Database.Instance.Query("INSERT INTO patient (name, disease) VALUES (?, ?)",
                    new string[] {model.Name, model.Disease});
            }
            return View(model);
        }
    }
}