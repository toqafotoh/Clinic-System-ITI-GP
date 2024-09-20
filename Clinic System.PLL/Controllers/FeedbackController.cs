using Clinic_System.BLL.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_System.PLL.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
                
        }
        public IActionResult Index()
        {
            var feedbacks=_feedbackService.GetAllFeedbacks();
            return View("GetAllFeedbacks",feedbacks);
        }
        
       
    }
}
