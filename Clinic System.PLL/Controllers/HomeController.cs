using Clinic_System.BLL.ModelVM.FeedBackVM;
using Clinic_System.BLL.Service.Abstraction;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Clinic_System.DAL.Entities;
using Clinic_System.BLL.ModelVM.Appointment;
using AutoMapper;
using Clinic_System.DAL.Repo.Implementation;
using Clinic_System.BLL.Service.Implementation;
using System.Security.Claims;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFeedbackService _feedbackService;
    private readonly IDoctorService _doctorService; 
    private readonly IDepartmentService _departmentService;
    private readonly IAppointmentService _appointmentService;
    private readonly IPatientService _patientService;
    private readonly IMapper _mapper;



    public HomeController(ILogger<HomeController> logger,IPatientService patientService, IFeedbackService feedbackService, IAppointmentService appointmentService, IDoctorService doctorService, IDepartmentService departmentService , IMapper mapper)
    {
        _logger = logger;
        _feedbackService = feedbackService;
        _doctorService = doctorService; 
        _departmentService = departmentService;
        _appointmentService = appointmentService;
        _patientService = patientService;
        _mapper = mapper;

    }

    public IActionResult Index()
    {
        var departments = _departmentService.GetDepartments(); 
        ViewBag.Departments = new SelectList(departments, "ID", "Name"); 
        return View();
    }

    [HttpGet]
    public IActionResult Search()
    {
        var model = new SearchVM
        {
            Doctors = _doctorService.GetDoctors() // تأكد من جلب الأطباء بشكل صحيح
        };


        return View(model);
    }

    [HttpPost]
    public IActionResult Search(SearchVM model)
    {
        var departments = _departmentService.GetDepartments();
        ViewBag.Departments = new SelectList(departments, "ID", "Name");

        List<DoctorVM> doctors;

        if (model.DepartmentId.HasValue && !string.IsNullOrEmpty(model.DoctorName))
        {
            doctors = _doctorService.SearchDoctorsByName(model.DoctorName);
        }
        else if (model.DepartmentId.HasValue)
        {
            doctors = _doctorService.GetDoctorsByDepartment(model.DepartmentId.Value);
        }
        else if (!string.IsNullOrEmpty(model.DoctorName))
        {
            doctors = _doctorService.SearchDoctorsByName(model.DoctorName);
        }
        else
        {
            doctors = _doctorService.GetDoctors().ToList();
        }

        foreach (var doctor in doctors)
        {
            var appointments = _appointmentService.GetAppointmentsByDoctor(doctor.DoctorID);
            doctor.Appointments = appointments.ToList();  
        }


        model.Doctors = doctors;

        return View(model);
    }


    public IActionResult BookAppointment(int appointmentId)
    {
        Console.WriteLine($"Appointment ID: {appointmentId}");
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var patient = _patientService.GetAllPatients().Where(a => a.User.Id == userId).FirstOrDefault();
        var isBooked = _appointmentService.BookAppointment(appointmentId ,patient.PatientID);
        if (isBooked)
        {
            return RedirectToAction("BookAppointment");
        }
        ModelState.AddModelError("", "Failed to book appointment");
        return RedirectToAction("BookAppointment");
    }




    [HttpGet]
    public IActionResult FeedBack()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Feedback(string Name, string Email, string Content)
    {
        var feedback = new FeedbackVM
        {
            Name = Name,
            Email = Email,
            Content = Content
        };
        
        var addedFeedback = _feedbackService.AddFeedback(feedback);
        return Ok();
    }
}