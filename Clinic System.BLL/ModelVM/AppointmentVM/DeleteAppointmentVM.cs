using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.ModelVM.AppointmentVM
{
    public class DeleteAppointmentVM
    {
        public int ID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public bool Isbooked { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
        public int DepartmentID { get; set; }
        public int? PatientID { get; set; }
    }
}
