using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.DAL.Repo.Abstraction
{
    public interface IPatientRepo
    {
        List<Patient> GetAll();
        Patient GetbyId(int id);
        bool Edit(Patient patient);
        bool Create(Patient patient);
        bool Delete(Patient patient);
    }
}
