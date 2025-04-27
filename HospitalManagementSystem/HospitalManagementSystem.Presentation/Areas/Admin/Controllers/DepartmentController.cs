using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Presentation.Areas.Admin.Models;
using HospitalManagementSystem.Services.Helpers;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<IActionResult> AllDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            var departmentsList = new List<DepartmentVM>();
            foreach (var department in departments)
            {
                var departmentVM = new DepartmentVM()
                {
                    Name = department.Name,
                    DepartmentID = department.DepartmentID,
                    Description = department.Description

                };
                departmentsList.Add(departmentVM);
            }
            return View(departmentsList);
        }
        [HttpGet]
        public  IActionResult AddDepartment()
        {
            return View(new DepartmentVM());
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentVM departmentVm)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentVm);
            }


            var department = new Department()
            {
                Name = departmentVm.Name,
                Description = departmentVm.Description

            };
            await _departmentService.AddDepartmentAsync(department);

            return RedirectToAction(nameof(AllDepartments));
        }

        [HttpGet]
        public async Task<IActionResult> EditDepartment(int id)
        {

            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
                return NotFound();

            var departmentVM = new DepartmentVM()
            {
                Name = department.Name,
                DepartmentID = department.DepartmentID,
                Description = department.Description

            };
            return View(departmentVM);
        }
        [HttpPost]
        public async Task<IActionResult> EditDepartment(DepartmentVM departmentVm)
        {
            if (!ModelState.IsValid)
                return View(departmentVm);

            var oldDepartment = await _departmentService.GetDepartmentByIdAsync(departmentVm.DepartmentID);
            if (oldDepartment == null)
                return NotFound();

            oldDepartment.Name = departmentVm.Name;
            oldDepartment.Description = departmentVm.Description;
            
            await _departmentService.UpdateDepartmentAsync(oldDepartment);
            return RedirectToAction(nameof(AllDepartments));
        }
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department != null)
            {
                await _departmentService.DeleteDepartmentAsync(id);
                TempData["SuccessMessage"] = "Department deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Department not found!";
            }

            return RedirectToAction(nameof(AllDepartments));
        }

    }
}
