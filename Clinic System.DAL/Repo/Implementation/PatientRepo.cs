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
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        public bool Create(Patient patient)
        {
            try
            {
                context.Patients.Add(patient);
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Patient patient)
        {
            try
            {
                var data = context.Patients.Where(a => a.ID == patient.ID).FirstOrDefault();
                data.IsDeleted = !data.IsDeleted;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }

        public bool Edit(Patient patient)
        {
            try
            {
                var patient1 = context.Patients.Where(a => a.ID == patient.ID).FirstOrDefault();
                patient1.FirstName = patient.FirstName;
                patient1.LastName = patient.LastName;
                patient1.Age=patient.Age;
                patient1.Gender=patient.Gender;
                patient1.phoneNumber = patient.phoneNumber;
                patient1.Email=patient.Email;
                patient1.Password=patient.Password;
                patient1.IsDeleted=patient.IsDeleted;
                patient1.Address=patient.Address;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<Patient> GetAll() => context.Patients.ToList();

        public Patient GetbyId(int id) => context.Patients.Where(a => a.ID == id).FirstOrDefault();
    }
}
