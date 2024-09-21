using Clinic_System.BLL.ModelVM.PatientVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.BLL.Service.Implementation;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var patients = _patientService.GetAllPatients();
            return View("GetAllPatients",patients);
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeletePatient(DeletePatientVM deletePatientVM)
        {
            var result = _patientService.Delete(deletePatientVM);
            return Json(new { success = result });
        }

    }
}
