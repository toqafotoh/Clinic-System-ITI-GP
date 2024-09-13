using Clinic_System.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Entities
{
    public class Patient:User
    {
        public string Address { get; set; }

        //Navigation Property
        public List<Appointment> Appointments { get; set; }
    }
}
