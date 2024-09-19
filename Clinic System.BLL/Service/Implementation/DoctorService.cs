using AutoMapper;
using Clinic_System.BLL.ModelVM;
using Clinic_System.BLL.ModelVM.Appointment;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Clinic_System.BLL.Service.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepo;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepo, IMapper mapper)
        {
            _doctorRepo = doctorRepo;
            _mapper = mapper;
        }

        public List<DoctorVM> GetDoctorsByDepartment(int departmentId)
        {
            var doctors = _doctorRepo.GetAll()
                .Include(c => c.User)
                .Include(d => d.Department)
                .Where(d => d.DeptID == departmentId)
                .ToList();

            return _mapper.Map<List<DoctorVM>>(doctors);
        }

        public List<DoctorVM> SearchDoctorsByName(string doctorName)
        {
            var allDoctors = _doctorRepo.GetAll()
                .Include(d => d.User)
                .Include(d => d.Department)
                .ToList();

            var filteredDoctors = allDoctors
                .Where(d => d.User.FirstName.Contains(doctorName, System.StringComparison.OrdinalIgnoreCase) ||
                            d.User.LastName.Contains(doctorName, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            return _mapper.Map<List<DoctorVM>>(filteredDoctors);
        }

        public List<DoctorVM> GetAllDoctors()
        {
            var doctors = _doctorRepo.GetAll()
                .Include(d => d.User)
                .Include(d => d.Department)
                .ToList();

            return _mapper.Map<List<DoctorVM>>(doctors).ToList();
        }
    }
}
