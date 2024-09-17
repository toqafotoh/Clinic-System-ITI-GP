using Clinic_System.BLL.ModelVM.AppointmentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Abstraction
{
    public interface IAppointmentService
    {
        bool Create(CreateAppointmentVM appointmentVM);
        bool Edit(UpdateAppointmentVM appointmentVM);
        bool BookAppointment(int appointmentId, int patientId);
        List<GetAllAppointmentsVM> GetAllAppointments();
        GetAppointmentByIdVM GetAppointmentById(int id);
        UpdateAppointmentVM ConvertToUpdateAppointmentVM(GetAppointmentByIdVM appointmentByIdVM);
    }
}
