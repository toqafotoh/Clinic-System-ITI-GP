using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Entities
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        //Navigation Property
        public List<Doctor> Doctors { get; set; }
        public Doctor Doctor { get; set; }
        public List <Appointment> Appointments { get; set; }
       
    }
}
