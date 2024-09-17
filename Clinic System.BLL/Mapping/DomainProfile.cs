using AutoMapper;
using Clinic_System.BLL.ModelVM.DoctorVM;
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
                }));
                //.ForMember(dest => dest.Department, opt => opt.MapFrom(src => new Department
                //{
                //    ID = src.Department
                //}));
        }
    }
}
