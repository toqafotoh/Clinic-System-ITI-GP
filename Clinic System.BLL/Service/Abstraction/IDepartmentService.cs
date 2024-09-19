using Clinic_System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Service.Abstraction
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();

    }
}
