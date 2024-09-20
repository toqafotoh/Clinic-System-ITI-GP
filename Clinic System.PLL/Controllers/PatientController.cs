using Clinic_System.BLL.ModelVM.PatientVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.BLL.Service.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_System.PLL.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public IActionResult Index()
        {
            var patients = _patientService.GetAllPatients();
            return View("GetAllPatients",patients);
        }

        [HttpGet]
        public IActionResult DeletePatient(int id)
        {
            var PatientVM = _patientService.GetPatientById(id);
            if (PatientVM is null)
            {
                return RedirectToAction("Index");
            }
            var deletePatientVM = _patientService.ConvertToDeletePatientVM(PatientVM);
            return View(deletePatientVM);
        }

        [HttpPost]
        public IActionResult DeletePatient(DeletePatientVM deletePatientVM)
        {
            var result = _patientService.Delete(deletePatientVM);
            return Json(new { success = result });
        }

        //after log in redirect here .... not direct access
        [HttpGet]
        public async Task<IActionResult> Profile(int id = 1)
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
