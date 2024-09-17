using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.DAL.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Abstraction
{
    public interface IDoctorService
    {
        bool Create(CreateDoctorVM doctor);
        bool Edit(UpdateDoctorVM doctor);
        List<GetAllDoctorsVM> GetAllDoctors();
        GetDoctorByIdVM GetDoctorById(int id);
        UpdateDoctorVM ConvertToUpdateDoctorVM(GetDoctorByIdVM doctorByIdVM);
    }
}
