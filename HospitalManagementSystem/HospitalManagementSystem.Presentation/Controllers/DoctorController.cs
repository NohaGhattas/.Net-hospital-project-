using HospitalManagementSystem.Presentation.ViewModels;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Presentation.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
           _doctorService = doctorService;
        }
        public async Task<IActionResult> Index()
        {
            var doctorsVM = new List<DoctorViewModel>();

            var doctors = await _doctorService.GetAllDoctorsAsync();
            foreach(var I in doctors)
            {
                var doctorModel = new DoctorViewModel()
                {
                    ImageURL = I.ImageURL,
                    Name = I.Name,
                    Status= I.Status,
                    Specialization = I.Specialization,

                };
                doctorsVM.Add(doctorModel);
            }
         
            if (doctors.Any()) return View(doctorsVM);
            return View();
        }
    }
}
