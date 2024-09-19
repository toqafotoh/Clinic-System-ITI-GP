using AutoMapper;
using Clinic_System.BLL.ModelVM.Appointment;
using Clinic_System.DAL.Entities;


namespace Clinic_System.BLL.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile() 
        {


            CreateMap<Doctor, DoctorVM>();
            CreateMap<Appointment, AppointmentVM>();


        }

    }
}
