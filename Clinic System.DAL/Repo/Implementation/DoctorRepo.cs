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
    public class DoctorRepo:IDoctorRepo
    {
        private readonly ApplicationDbContext _db;
        public DoctorRepo(ApplicationDbContext applicationDb)
        {
            _db = applicationDb;
        }
        public bool Create(Doctor doctor)
        {
            try
            {
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
                var existedDoctor = _db.Doctors.Include(d => d.User)
                                                          .FirstOrDefault(p => p.DoctorID == doctor.DoctorID);
                if (doctor != null)
                {
                    existedDoctor.Shift = doctor.Shift;
                    existedDoctor.SessionPrice = doctor.SessionPrice;
                    existedDoctor.Description = doctor.Description;
                    existedDoctor.User.Image = doctor.User.Image;
                    existedDoctor.User.FirstName = doctor.User.FirstName;
                    existedDoctor.User.LastName = doctor.User.LastName;
                    existedDoctor.User.Age = doctor.User.Age;
                    existedDoctor.User.Gender = doctor.User.Gender;
                    existedDoctor.User.PhoneNumber = doctor.User.PhoneNumber;
                    existedDoctor.User.Email = doctor.User.Email;
                    existedDoctor.User.PasswordHash = doctor.User.PasswordHash;
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
        public bool Delete(Doctor doctor)
        {
            try
            {
                var data = _db.Doctors.Include(d => d.User)
                                                      .FirstOrDefault(p => p.DoctorID == doctor.DoctorID);
                if (data!=null)
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
        public List<Doctor> GetAll()
        {
            return _db.Doctors.Include(d => d.User).ToList();
        }
        public Doctor GetById(int id)
        {
            return _db.Doctors.Include(d => d.User).FirstOrDefault(d => d.DoctorID == id);
        }

    }
}
