using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.BLL.Service.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_System.PLL.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateDoctor()
        {
            return View(new CreateDoctorVM());
        }

        [HttpPost]
        public IActionResult CreateDoctor(CreateDoctorVM doctorVM)
        {
            if (ModelState.IsValid)
            {
                var isCreated = _doctorService.Create(doctorVM);
                if (isCreated)
                {
                    //return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to create doctor");
            }
            return View(doctorVM);
        }
    }
}
