﻿using Clinic_System.DAL.Database;
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

        public DoctorRepo(ApplicationDbContext applicationDb)
        {
            _db = applicationDb;
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

        public bool Delete(Doctor doctor)
        {
            try
            {
                var data = _db.Doctors.Include(d => d.User)
                                      .FirstOrDefault(d => d.DoctorID == doctor.DoctorID);
                if (data is not null)
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

        public bool Edit(Doctor doctor)
        {
            try
            {
                var existingDoctor = _db.Doctors.Include(d => d.User)
                                                .FirstOrDefault(d => d.DoctorID == doctor.DoctorID);

                if (existingDoctor is not null)
                {
                    existingDoctor.Department = doctor.Department;
                    existingDoctor.User.FirstName = doctor.User.FirstName;
                    existingDoctor.User.LastName = doctor.User.LastName;
                    existingDoctor.User.Age = doctor.User.Age;
                    existingDoctor.User.Gender = doctor.User.Gender;
                    existingDoctor.User.PhoneNumber = doctor.User.PhoneNumber;
                    existingDoctor.User.Email = doctor.User.Email;
                    existingDoctor.SessionPrice = doctor.SessionPrice;
                    existingDoctor.Shift = doctor.Shift;
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
