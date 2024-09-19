using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.DAL.Entities;
using Clinic_System.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Implementation
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepo;

        public DepartmentService(IDepartmentRepository departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public List<Department> GetDepartments()
        {
            return _departmentRepo.GetAll().ToList();
        }
    }
}
