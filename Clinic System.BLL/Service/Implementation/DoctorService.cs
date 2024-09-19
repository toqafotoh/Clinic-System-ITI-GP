using Clinic_System.BLL.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_System.DAL.Repo.Abstraction;
using Clinic_System.DAL.Repo.Implementation;
using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.DAL.Entities;
using AutoMapper;
using Clinic_System.BLL.ModelVM.PatientVM;
namespace Clinic_System.BLL.Service.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _doctorRepo;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepo doctorRepo, IMapper mapper)
        {
            _doctorRepo = doctorRepo;
            _mapper = mapper;
        }

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
