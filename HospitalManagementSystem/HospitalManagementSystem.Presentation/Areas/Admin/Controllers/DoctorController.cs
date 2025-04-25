using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Presentation.Areas.Admin.Models;
using HospitalManagementSystem.Presentation.ViewModels;
using HospitalManagementSystem.Services.Helpers;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
       
        [HttpGet]
        public async Task<IActionResult> AllDoctors() {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            var doctorsList = new List<DoctorVM>();
            foreach (var doctor in doctors)
            {
                var doctorVM = new DoctorVM()
                {
                    Name = doctor.Name,
                    Phone = doctor.Phone,
                    ImageURL = doctor.ImageURL,
                    Status = doctor.Status,
                    Specialization = doctor.Specialization,

                };
                doctorsList.Add(doctorVM);
            }
            return View(doctorsList);
        }
        [HttpGet]
        public IActionResult AddDoctor()
        {
            return View(new DoctorVM());
        }
        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorVM doctorVm)
        {
            if (!ModelState.IsValid)
                return View(doctorVm);

            doctorVm.ImageURL = DocumentHelper.UploadFile(doctorVm.Image, "images");

            var doctor = new Doctor()
                {
                    Name = doctorVm.Name,
                    Specialization = doctorVm.Specialization,
                    Status = doctorVm.Status,
                    ImageURL = doctorVm.ImageURL,
                    Phone = doctorVm.Phone,
                };
                await _doctorService.AddDoctorAsync(doctor);

            await _doctorService.AddDoctorAsync(doctor);
            return RedirectToAction(nameof(AllDoctors));
        }

        [HttpGet]
        public async Task<IActionResult> EditDoctor(int id)
        {

            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
                return NotFound();

            var doctorVm = new DoctorVM
            {
                Name = doctor.Name,
                Specialization = doctor.Specialization,
                Status = doctor.Status,
                ImageURL = doctor.ImageURL,
                Phone = doctor.Phone,
            };
            return View(doctorVm);
        }
        [HttpPost]
        public  async Task<IActionResult> EditDoctor(DoctorVM doctorVm)
        {
            if (!ModelState.IsValid)
                return View(doctorVm);

            var oldDoctor = await _doctorService.GetDoctorByIdAsync(doctorVm.Id);
            if (oldDoctor == null)
                return NotFound();

            oldDoctor.Name = doctorVm.Name;
            oldDoctor.Specialization = doctorVm.Specialization;
            oldDoctor.Status = doctorVm.Status;
            oldDoctor.ImageURL = doctorVm.ImageURL;
            oldDoctor.Phone = doctorVm.Phone;

            await _doctorService.UpdateDoctorAsync(oldDoctor);
            return RedirectToAction(nameof(AllDoctors));
        }
        [HttpPost]
        public async Task DeleteDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor != null)
            {
                await _doctorService.DeleteDoctorAsync(id);
            }

        }

    }
}
