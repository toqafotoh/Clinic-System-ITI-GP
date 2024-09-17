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
    }
}
