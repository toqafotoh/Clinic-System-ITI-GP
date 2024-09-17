using AutoMapper;
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
            CreateMap<Patient, GetAllPatientVM>();
            CreateMap<CreatePatientVM, Patient>();
            CreateMap<EditPatientVM, Patient>();

            // From VM To Entity (Create - Edit - Delete)
            //CreateMap<DepartmentVM, Department>();


        }

    }
}
