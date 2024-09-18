using AutoMapper;
using Clinic_System.BLL.ModelVM.AppointmentVM;
using Clinic_System.BLL.ModelVM.DepartmentVM;
using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.BLL.ModelVM.PatientVM;
using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {

            //From Entity To VM(Retreive)

            CreateMap<Patient, GetAllPatientVM>().ConstructUsing(patient => new GetAllPatientVM(patient));
            CreateMap<Patient, GetPatientByIdVM>().ConstructUsing(patient => new GetPatientByIdVM(patient));
            CreateMap<DeletePatientVM, Patient>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Age = src.Age,
                    Gender = src.Gender,
                    PhoneNumber = src.PhoneNumber,
                    Email = src.Email,
                    Image = src.Image,
                    IsDeleted=src.IsDeleted
                }));
            CreateMap<Patient, DeletePatientVM>();

            //CreateMap<CreatePatientVM, Patient>();
            //CreateMap<EditPatientVM, Patient>();
            CreateMap<CreateDoctorVM, Doctor>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Age = src.Age,
                    Gender = src.Gender,
                    PhoneNumber = src.PhoneNumber,
                    Email = src.Email,
                    Image = src.Image
                })).ForMember(dest => dest.DeptID, opt => opt.MapFrom(src => src.DepartmentID));


            // From VM To Entity (Create - Edit - Delete)
            //CreateMap<DepartmentVM, Department>();


            //CreateMap<Doctor, Doctor>().ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
            CreateMap<UpdateDoctorVM, Doctor>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Age = src.Age,
                    Gender = src.Gender,
                    PhoneNumber = src.PhoneNumber,
                    Email = src.Email,
                    Image = src.Image
                })).ForMember(dest => dest.DeptID, opt => opt.MapFrom(src => src.DepartmentID));

            CreateMap<Doctor, GetAllDoctorsVM>().ConstructUsing(doctor => new GetAllDoctorsVM(doctor));
            CreateMap<Doctor, GetDoctorByIdVM>().ConstructUsing(doctor => new GetDoctorByIdVM(doctor));
            CreateMap<GetDoctorByIdVM, UpdateDoctorVM>();
            CreateMap<Appointment, CreateAppointmentVM>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentVM>().ReverseMap();
            CreateMap<Appointment, GetAllAppointmentsVM>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.User.FirstName + " " + src.Doctor.User.LastName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Doctor.SessionPrice))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Doctor.Department.Name));

            CreateMap<Appointment, GetAppointmentByIdVM>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.User.FirstName + " " + src.Doctor.User.LastName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Doctor.SessionPrice))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Doctor.Department.Name));
            CreateMap<GetAppointmentByIdVM, UpdateAppointmentVM>();

            CreateMap<Department, GetAllDepartmentsVM>().ReverseMap();
            CreateMap<Department, GetDepartmentByIdVM>().ReverseMap();
            CreateMap<CreateDepartmentVM, Department>().ReverseMap();
            CreateMap<EditDepartmentVM, Department>().ReverseMap();
            CreateMap<DeleteDepartmentVM, Department>().ReverseMap();
        }
    }
}
