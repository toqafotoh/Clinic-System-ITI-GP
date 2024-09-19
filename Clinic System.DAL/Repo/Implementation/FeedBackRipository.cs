using Clinic_System.DAL.Database;
using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Repo.Implementation
{
    public class FeedBackRipository : IFeedBackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedBackRipository(ApplicationDbContext context)
        {
            _context = context;
        }


        public Feedback Add(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
            return feedback; // رجع الـ feedback اللي اتسجل
        }

     

        //public IEnumerable<FeedBack> GetAllFeedbacks()
        //{
        //    return _context.FeedBacks.ToList();
        //}

        //public FeedBack GetFeedbackById(int id)
        //{
        //    return _context.FeedBacks.Find(id);
        //}

        //public void AddFeedback(FeedBack feedback)
        //{
        //    try
        //    {
        //        _context.FeedBacks.Add(feedback);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        // هنا يمكنك طباعة الرسالة للتأكد من المشكلة
        //        throw new Exception("Error saving feedback: " + ex.Message);
        //    }
        //}


        //public void Save()
        //{
        //    _context.SaveChanges();
        //}
    }

}

