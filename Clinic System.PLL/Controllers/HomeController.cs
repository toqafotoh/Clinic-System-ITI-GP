using Clinic_System.PLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clinic_System.PLL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        { 
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }

    }
}
