using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.PatientVM
{
    public class PatientProfileVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string? Image { get; set; }
        public List<Appointment> Appointments { get; set; }
        //public EditEmailVM EditEmail { get; set; }
    }
}
