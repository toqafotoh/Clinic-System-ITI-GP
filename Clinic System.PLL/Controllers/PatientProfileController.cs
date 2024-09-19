using Clinic_System.BLL.ModelVM.PatientVM;
using Clinic_System.BLL.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_System.PLL.Controllers
{
    public class PatientProfileController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientProfileController(IPatientService patientService)
        {
            this._patientService = patientService;
        }


        //after log in redirect here .... not direct access
        [HttpGet]
        public async Task<IActionResult> Index(int id = 1)
        {
            var patientVM = _patientService.GetPatientById(id);
            return View(patientVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmail(EditPatientVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", await GetPatientViewModel());
            }

            var userId = 1;//_authService.GetCurrentUserId();
            var result =  _patientService.Edit(model);

            if (result)
            {
                TempData["SuccessMessage"] = "Email updated successfully";
            }
            else
            {
                ModelState.AddModelError("", "Failed to update email");
            }

            return RedirectToAction("Index");
        }

        private async Task<PatientProfileVM> GetPatientViewModel()
        {
            var patientId = 1;///_authService.GetCurrentUserId();
            return /*await*/ _patientService.GetPatientById(patientId);
        }
    }
}
