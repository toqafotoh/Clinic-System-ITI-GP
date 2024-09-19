using Clinic_System.BLL.ModelVM.DepartmentVM;
using Clinic_System.BLL.ModelVM.DoctorVM;
using Clinic_System.BLL.Service.Abstraction;
using Clinic_System.BLL.Service.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_System.PLL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            ViewBag.Departments = departments;
            return View(new CreateDepartmentVM());
        }

        [HttpPost]
        public IActionResult CreateDepartment(CreateDepartmentVM departmentVM)
        {
            if (ModelState.IsValid)
            {
                var isCreated = _departmentService.Create(departmentVM);
                if (isCreated)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to create department");
            }

            ViewBag.Departments = _departmentService.GetAllDepartments();
            return View("Index", departmentVM);
        }
        [HttpPost]
        public IActionResult DeleteDepartment(DeleteDepartmentVM deleteDepartmentVM)
        {
            var result = _departmentService.Delete(deleteDepartmentVM);
            return Json(new { success = result });
        }
    }
}
