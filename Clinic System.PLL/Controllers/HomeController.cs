using Clinic_System.BLL.ModelVM.FeedBackVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.DAL.Entities;
using Clinic_System.PLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clinic_System.PLL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeedbackService _feedbackService;

        public HomeController(ILogger<HomeController> logger, IFeedbackService feedbackService)
        {
            _logger = logger;
            _feedbackService = feedbackService;
}
            public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }


        [HttpGet]
        public IActionResult FeedBack()
        {
            return View();
        }

        // معالجة البيانات المرسلة من نموذج Create FeedBack
        [HttpPost]
        public IActionResult Feedback(FeedbackVM model)
        {
            // تأكد من صحة البيانات المرسلة
            if (ModelState.IsValid)
            {
                var addedFeedback = _feedbackService.AddFeedback(model); // استخدم الـ feedback اللي اتضاف
                return RedirectToAction("Index");
            }

            return View(model);
        }

            // في حالة عدم صحة البيانات أو حدوث خطأ، رجّع نفس الـ View مع البيانات الحالية
        }


    }
