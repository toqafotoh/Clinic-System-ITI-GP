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
        public async Task<IActionResult> EditEmail(EditPatientEmailVM model)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>();
                foreach (var error in ViewData.ModelState.Values.SelectMany(v => v.Errors))
                {
                    errors.Add(error.ErrorMessage);
                }
                TempData["ErrorMessage"] = errors;
                return RedirectToAction("Index");
            }

            var result = _patientService.EditPatientEmail(model);

            if (result)
            {
                TempData["SuccessMessage"] = "Email updated successfully";
            }
            else
            {
                TempData["ErrorMessage"] = new List<string> { "Failed to update email" };
            }

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public async Task<IActionResult> DeletePatient(EditPatientEmailVM model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        List<string> errors = new List<string>();
        //        foreach (var error in ViewData.ModelState.Values.SelectMany(v => v.Errors))
        //        {
        //            errors.Add(error.ErrorMessage);
        //        }
        //        TempData["ErrorMessage"] = errors;
        //        return RedirectToAction("Index");
        //    }

        //    var result = _patientService.EditPatientEmail(model);

        //    if (result)
        //    {
        //        TempData["SuccessMessage"] = "Email updated successfully";
        //    }
        //    else
        //    {
        //        TempData["ErrorMessage"] = new List<string> { "Failed to update email" };
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}
