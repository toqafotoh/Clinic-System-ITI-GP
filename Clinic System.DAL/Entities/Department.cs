using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Entities
{
    public class Department
    {
        [Key] 
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Doctor> Doctors { get; set; }
        public List <Appointment> Appointments { get; set; }
    }
}
