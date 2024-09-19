using AutoMapper;
using Clinic_System.BLL.ModelVM.Appointment;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepo _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepo appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }


        public IEnumerable<AppointmentVM> GetAppointmentsByDoctor(int doctorId)
        {
            var appointments = _appointmentRepository.GetAppointmentsByDoctor(doctorId);
            return _mapper.Map<IEnumerable<AppointmentVM>>(appointments);
        }
    }
}
