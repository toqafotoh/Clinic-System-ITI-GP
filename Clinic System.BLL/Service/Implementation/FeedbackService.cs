using Clinic_System.BLL.ModelVM.FeedBackVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Implementation
{
    public class FeedbackService:IFeedbackService
    {
        private readonly IFeedBackRepository _feedbackRepository;

        public FeedbackService(IFeedBackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

     

        public Feedback AddFeedback(FeedbackVM model)
        {
            var feedback = new Feedback
            {
                Name = model.Name,
                Content = model.Content,
                Email = model.Email
            };

            return _feedbackRepository.Add(feedback);
        }

    }
}
