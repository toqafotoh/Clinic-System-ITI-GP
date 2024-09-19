﻿using AutoMapper;
using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.BLL.ModelVM.PatientVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Repo.Abstraction;
using Clinic_System.DAL.Repo.Implementation;
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

        public List<GetAllPatientVM> GetAllPatients()
        {
            var Result = patientRepo.GetAll().ToList();
            var NewData = mapper.Map<List<GetAllPatientVM>>(Result);
            return NewData;
        }

        public GetPatientByIdVM GetPatientById(int id)
        {
            var patient = patientRepo.GetById(id);
            return mapper.Map<GetPatientByIdVM>(patient);
        }

        public bool DeletePatientById(DeletePatientVM deletePatientVM)
        {
            var patient = patientRepo.GetById(deletePatientVM.PatientID);

            if (patient == null || deletePatientVM.IsDeleted == true)
            {
                return false; // Patient not found or already deleted
            }

            // Use AutoMapper to map DeletePatientVM to Patient entity
            var patientEntity = mapper.Map<Patient>(deletePatientVM);
            patientEntity.User.IsDeleted = true; // Mark as deleted (soft delete)

            patientRepo.Delete(patientEntity);
            patientRepo.SaveChanges();

            return true;
        }
        public bool Delete(DeletePatientVM patientVM)
        {
            if (patientVM is not null)
            {
                var patient = mapper.Map<Patient>(patientVM);
                return patientRepo.Delete(patient);
            }
            return false;
        }


        public bool Create(CreatePatientVM patientVM)
        {
            if(patientVM is not null)
            {
                var Result = mapper.Map<Patient>(patientVM);
                return patientRepo.Create(Result);
            }
            return false;

            
        }

        public bool Edit(EditPatientVM patientVM)
        {
           if(patientVM is not null)
            {
                var patient = mapper.Map<Patient>(patientVM);
                return patientRepo.Edit(patient);
            }
            return false;
        }
        public DeletePatientVM ConvertToDeletePatientVM(GetPatientByIdVM patientByIdVM)
        {
            var deletePatientVM = mapper.Map<DeletePatientVM>(patientByIdVM);
            return deletePatientVM;
        }

    }
}
