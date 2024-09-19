using Clinic_System.BLL.ModelVM.Appointment;
using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Abstraction
{
    public interface IDoctorService
    {
        List<DoctorVM> GetDoctorsByDepartment(int departmentId);
        List<DoctorVM> SearchDoctorsByName(string doctorName);
        List<DoctorVM> GetAllDoctors();

    }
}
