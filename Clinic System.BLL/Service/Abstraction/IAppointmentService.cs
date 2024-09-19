using Clinic_System.BLL.ModelVM.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Abstraction
{
    public interface IAppointmentService 
    {
        IEnumerable<AppointmentVM> GetAppointmentsByDoctor(int doctorId);

    }
}
