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
        public string Submit(FormModel model)
        {
            return model.InputName;
        }
    }
}