using Microsoft.AspNetCore.Mvc;

namespace Clinic_System.PLL.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
