using AutoMapper;
using Clinic_System.BLL.ModelVM.PatientVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo patientRepo;
        private readonly IMapper mapper;
        public PatientService(IPatientRepo patientRepo, IMapper mapper)
        {
              this.patientRepo = patientRepo;
            this.mapper = mapper;
        }

        public List<GetAllPatientVM> GetAll()
        {
            var Result = patientRepo.GetAll().ToList();
            var NewData = mapper.Map<List<GetAllPatientVM>>(Result);
            return NewData;
        }

        public bool Create(CreatePatientVM patientVM)
        {
            var Result = mapper.Map<Patient>(patientVM);
            return patientRepo.Create(Result);
        }

        public bool Edit(EditPatientVM patientVM)
        {
            var patient = mapper.Map<Patient>(patientVM);
            return patientRepo.Edit(patient);
        }

        public bool Delete(DeletePatientVM patientVM)
        {
            var patient = mapper.Map<Patient>(patientVM);
            return patientRepo.Delete(patient);
        }

    }
}
