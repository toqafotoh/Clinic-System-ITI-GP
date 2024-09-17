using AutoMapper;
using Clinic_System.DAL.Database;
using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Repo.Implementation
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public DoctorRepo(ApplicationDbContext applicationDb, IMapper mapper)
        {
            _db = applicationDb;
            _mapper = mapper;
        }

        public bool Create(Doctor doctor)
        {
            try
            {
                _db.Users.Add(doctor.User);
                _db.Doctors.Add(doctor);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Doctor doctor)
        {
            try
            {
                var existingDoctor = _db.Doctors.Include(d => d.User)
                                                .FirstOrDefault(d => d.DoctorID == doctor.DoctorID);

                if (existingDoctor is not null)
                {
                    _mapper.Map(doctor, existingDoctor);
                    _db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<Doctor> GetAll()
        {
            return _db.Doctors.Include(d => d.User).ToList();
        }

        public Doctor GetById(int id)
        {
            return _db.Doctors.Include(d => d.User).FirstOrDefault(d => d.DoctorID == id);
        }

        public bool Delete(Doctor doctor)
        {
            try
            {
                var data = _db.Doctors.Include(d => d.User)
                                                      .FirstOrDefault(p => p.DoctorID == doctor.DoctorID);
                if (data != null)
                {
                    data.User.IsDeleted = !data.User.IsDeleted;
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;

            }
        }
    }
}
