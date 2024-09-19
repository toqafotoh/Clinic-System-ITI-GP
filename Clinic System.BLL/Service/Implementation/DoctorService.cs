using AutoMapper;
using Clinic_System.BLL.ModelVM;
using Clinic_System.BLL.ModelVM.Appointment;
using Clinic_System.BLL.Service.Abstraction;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_System.DAL.Repo.Abstraction;
using Clinic_System.DAL.Repo.Implementation;
using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.DAL.Entities;
using Clinic_System.BLL.ModelVM.PatientVM;

namespace Clinic_System.BLL.Service.Implementation
{
    public class DoctorService : IDoctorService
    {
        // private readonly IDoctorRepository _doctorRepo;

        private readonly IDoctorRepo _doctorRepo;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepo doctorRepo, IMapper mapper)
        {
            _doctorRepo = doctorRepo;
            _mapper = mapper;
        }

//         public List<DoctorVM> GetDoctorsByDepartment(int departmentId)
//         {
//             var doctors = _doctorRepo.GetAll()
//                 .Include(c => c.User)
//                 .Include(d => d.Department)
//                 .Where(d => d.DeptID == departmentId)
//                 .ToList();

//             return _mapper.Map<List<DoctorVM>>(doctors);
//         }

//         public List<DoctorVM> SearchDoctorsByName(string doctorName)
//         {
//             var allDoctors = _doctorRepo.GetAll()
//                 .Include(d => d.User)
//                 .Include(d => d.Department)
//                 .ToList();

//             var filteredDoctors = allDoctors
//                 .Where(d => d.User.FirstName.Contains(doctorName, System.StringComparison.OrdinalIgnoreCase) ||
//                             d.User.LastName.Contains(doctorName, System.StringComparison.OrdinalIgnoreCase))
//                 .ToList();

//             return _mapper.Map<List<DoctorVM>>(filteredDoctors);
//         }

//         public List<DoctorVM> GetAllDoctors()
//         {
//             var doctors = _doctorRepo.GetAll()
//                 .Include(d => d.User)
//                 .Include(d => d.Department)
//                 .ToList();

//             return _mapper.Map<List<DoctorVM>>(doctors).ToList();
//         }
//     }
        public bool Create(CreateDoctorVM doctorVM)
        {
            if (doctorVM is not null)
            {
                var doctorEntity = _mapper.Map<Doctor>(doctorVM);
                return _doctorRepo.Create(doctorEntity);
            }
            return false;
        }

        public bool Edit(UpdateDoctorVM doctorVM)
        {
           if(doctorVM is not null)
            {
                var doctorEntity = _mapper.Map<Doctor>(doctorVM);
                return _doctorRepo.Edit(doctorEntity);
            }
            return false;
        }
        public List<GetAllDoctorsVM> GetAllDoctors()
        {
            var doctors = _doctorRepo.GetAll();
            var doctorVMs = _mapper.Map<List<GetAllDoctorsVM>>(doctors);

            return doctorVMs;
        }
        public GetDoctorByIdVM GetDoctorById(int id)
        {
            var doctor = _doctorRepo.GetById(id);
            return _mapper.Map<GetDoctorByIdVM>(doctor); 
        }
        public UpdateDoctorVM ConvertToUpdateDoctorVM(GetDoctorByIdVM doctorByIdVM)
        {
            var updateDoctorVM = _mapper.Map<UpdateDoctorVM>(doctorByIdVM);
            return updateDoctorVM;
        }
        public bool Delete(DeleteDoctorVM doctorVM)
        {
            if (doctorVM is not null)
            {
                var doctor = _mapper.Map<Doctor>(doctorVM);
                return _doctorRepo.Delete(doctor);
            }
            return false;
        }
    }
}
