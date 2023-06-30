using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_API.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
