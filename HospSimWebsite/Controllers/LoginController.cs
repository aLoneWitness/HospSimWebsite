using Microsoft.AspNetCore.Mvc;

namespace HospSimWebsite.Controllers
{
    public class LoginController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}