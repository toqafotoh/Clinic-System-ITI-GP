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
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly ApplicationDbContext _db;
        public AppointmentRepo(ApplicationDbContext applicationDb)
        {
            _db = applicationDb;
        }
        public bool Create(Appointment appointment)
        {
            try
            {
                _db.Appointments.Add(appointment);
                _db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Appointment appointment)
        {
            try
            {
                var data = _db.Appointments.Where(a => a.ID == appointment.ID).FirstOrDefault();
                if (data is not null)
                {
                    data.IsDeleted = !data.IsDeleted;
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

        public bool Edit(Appointment appointment)
        {
            try
            {
                var existingAppointment = _db.Appointments.Where(a => a.ID == appointment.ID).FirstOrDefault();

                if (existingAppointment is not null)
                {
                    existingAppointment.Date=appointment.Date;
                    existingAppointment.IsDeleted = appointment.IsDeleted;
                    existingAppointment.Isbooked = appointment.Isbooked;
                    
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

        public List<Appointment> GetAll()
        {
            return _db.Appointments.ToList();
        }

        public Appointment GetbyId(int id)
        {
            return _db.Appointments.Where(a => a.ID == id).FirstOrDefault();
        }

    }
}
