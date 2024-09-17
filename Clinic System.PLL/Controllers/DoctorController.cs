using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.BLL.Service.Implementation;
using Clinic_System.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

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
            var doctors = _doctorService.GetAllDoctors();
            return View("GetAllDoctors", doctors);
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
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to create doctor");
            }
            return View(doctorVM);
        }

        [HttpGet]
        public IActionResult EditDoctor(int id)
        {
            var doctorVM = _doctorService.GetDoctorById(id); 
            if (doctorVM is null)
            {
                return RedirectToAction("Index");
            }
            var updateDoctorVM = _doctorService.ConvertToUpdateDoctorVM(doctorVM);
            return View(updateDoctorVM);
        }

        [HttpPost]
        public IActionResult EditDoctor(UpdateDoctorVM doctorVM)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = _doctorService.Edit(doctorVM);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to update doctor");
            }
            return View(doctorVM);
        }
    }
}
