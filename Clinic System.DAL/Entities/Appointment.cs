using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Entities
{
    public class Appointment
    {
        [Required]
        public int ID { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        [Required]
        public bool Isbooked { get; set; }

        //Navigation Property
        [ForeignKey("Doctor")]
        public int? DoctorID { get; set; }
        [ForeignKey("Department")]
        public int? DeptID { get; set; }
        [ForeignKey("Patient")]
        public int? PatientID { get; set; }
        public List<Payment> payments { get; set; }

    }
}
