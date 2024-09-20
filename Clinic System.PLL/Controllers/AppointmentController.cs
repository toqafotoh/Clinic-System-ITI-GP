using Clinic_System.BLL.ModelVM.AppointmentVM;
using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.BLL.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_System.PLL.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var appointments = _appointmentService.GetAllAppointments();
            var doctors = _doctorService.GetAllDoctors();

            ViewBag.Appointments = appointments;
            ViewBag.Doctors = doctors;
            return View(new CreateAppointmentVM());
        }

        [HttpPost]
        public IActionResult CreateAppointment(CreateAppointmentVM appointmentVM)
        {
            if (ModelState.IsValid)
            {
                var isCreated = _appointmentService.Create(appointmentVM);
                if (isCreated)
                {
                    
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to create appointment");
            }
            ViewBag.Doctors = _doctorService.GetAllDoctors();
            ViewBag.Appointments = _appointmentService.GetAllAppointments();

            return View("Index", appointmentVM);
        }

        [HttpGet]
        public IActionResult EditAppointment(int id)
        {
            var appointmentVM = _appointmentService.GetAppointmentById(id);
            if (appointmentVM is null)
            {
                return RedirectToAction("Index");
            }
            var updateAppointmentVM = _appointmentService.ConvertToUpdateAppointmentVM(appointmentVM);
            ViewBag.Doctors = _doctorService.GetAllDoctors();
            return View(updateAppointmentVM);
        }

        [HttpPost]
        public IActionResult EditAppointment(UpdateAppointmentVM appointmentVM)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = _appointmentService.Edit(appointmentVM);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to update appointment");
            }
            ViewBag.Doctors = _doctorService.GetAllDoctors();
            return View(appointmentVM);
        }

        [HttpPost]
        public IActionResult BookAppointment(int appointmentId, int patientId)
        {
            var isBooked = _appointmentService.BookAppointment(appointmentId, patientId);
            if (isBooked)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Failed to book appointment");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteAppointment(DeleteAppointmentVM deleteAppointmentVM)
        {
            var result = _appointmentService.Delete(deleteAppointmentVM);
            return Json(new { success = result });
        }
    }
}
