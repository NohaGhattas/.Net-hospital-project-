using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Presentation.Areas.Admin.Models;
using HospitalManagementSystem.Presentation.ViewModels;
using HospitalManagementSystem.Services.Helpers;
using HospitalManagementSystem.Services.Services;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IDepartmentService _departmentService;

        public DoctorController(IDoctorService doctorService, IDepartmentService departmentService)
        {
            _doctorService = doctorService;
            _departmentService = departmentService;
        }
       
        [HttpGet]
        public async Task<IActionResult> AllDoctors() {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            var doctorsList = new List<DoctorVM>();
            foreach (var doctor in doctors)
            {
                var doctorVM = new DoctorVM()
                {
                    Id = doctor.DoctorID,
                    Name = doctor.Name,
                    Phone = doctor.Phone,
                    ImageURL = doctor.ImageURL,
                    Status = doctor.Status,
                    Specialization = doctor.Specialization,
                    DepartmentId = doctor.DepartmentID,
                    SpecialityLevel = doctor.SpecialtyLevel

                };
                doctorsList.Add(doctorVM);
            }
            return View(doctorsList);
        }
        [HttpGet]
        public async Task<IActionResult> AddDoctor()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            var model = new DoctorVM()
            {
                Departments = departments.Select(d => new SelectListItem
                {
                    Value = d.DepartmentID.ToString(),
                    Text = d.Name
                }).ToList()
            };
            
            return  View(model);
        }
        public async Task<IActionResult> AddDoctor(DoctorVM doctorVm)
        {
            if (!ModelState.IsValid)
            {
                doctorVm.Departments = (await _departmentService.GetAllDepartmentsAsync())
                    .Select(d => new SelectListItem { Value = d.DepartmentID.ToString(), Text = d.Name })
                    .ToList();
                return View(doctorVm);
            }

            doctorVm.ImageURL = DocumentHelper.UploadFile(doctorVm.Image, "images","doctor");

            var doctor = new Doctor()
            {
                Name = doctorVm.Name,
                Specialization = doctorVm.Specialization,
                Status = doctorVm.Status,
                ImageURL = doctorVm.ImageURL,
                Phone = doctorVm.Phone,
                DepartmentID = doctorVm.DepartmentId.Value,
                SpecialtyLevel = doctorVm.SpecialityLevel
            };

            await _doctorService.AddDoctorAsync(doctor);

            return RedirectToAction(nameof(AllDoctors));
        }

        [HttpGet]
        public async Task<IActionResult> EditDoctor(int id)
        {

            var doctor = await _doctorService.GetDoctorByIdAsync(id);
        
            if (doctor == null)
            {
                return NotFound();
            }

            var departments =(await _departmentService.GetAllDepartmentsAsync()).Select(d => new SelectListItem
                                     {
                                         Value = d.DepartmentID.ToString(),
                                         Text = d.Name
                                     }).ToList();

            var model = new EditDoctorVM
            {
                Id = doctor.DepartmentID,
                Name = doctor.Name,
                Specialization = doctor.Specialization,
                Status = doctor.Status,
                Phone = doctor.Phone,
                SpecialityLevel = doctor.SpecialtyLevel,
                Departments = departments
            };

            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> EditDoctor(EditDoctorVM editDoctorVM)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(editDoctorVM.Id);
            if (doctor == null)
                return NotFound();

            var departments = await _departmentService.GetAllDepartmentsAsync();
            if (departments == null || !departments.Any())
            {
                return View("Error"); 
            }

            var departmentList = departments.Select(d => new SelectListItem
            {
                Value = d.DepartmentID.ToString(),
                Text = d.Name,
                Selected = d.DepartmentID == doctor.DepartmentID  
            }).ToList();

            var doctorVm = new EditDoctorVM()
            {
                Id = doctor.DoctorID,
                Name = doctor.Name,
                Specialization = doctor.Specialization,
                Status = doctor.Status,
                ImageURL = doctor.ImageURL,
                Phone = doctor.Phone,
                DepartmentId = doctor.DepartmentID,
                SpecialityLevel = doctor.SpecialtyLevel
            };

           
            return View(doctorVm);
        }

        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor != null)
            {
                await _doctorService.DeleteDoctorAsync(id);
            }
            return RedirectToAction(nameof(AllDoctors));
        }

    }
}
