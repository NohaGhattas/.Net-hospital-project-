using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Presentation.Areas.Admin.Models;
using HospitalManagementSystem.Presentation.ViewModels;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Presentation.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult Index(string? doctorName, string? specialization)
        {
            var viewModel = new AppointmentViewModel
            {
                DoctorName = doctorName,
                Specialization = specialization
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var doctor = await _doctorService.GetByNameAsync(model.DoctorName, model.Specialization);

            if (doctor == null)
            {
                //ModelState.AddModelError("", "Doctor not found");
                //return View(model);
                doctor = new Models.Doctors.Doctor
                {
                    DoctorID = 1,
                    Name = model.DoctorName
                };
                return RedirectToAction("Confirmation", new { appointmentId = 1234 });
            }

            var appointment = new Appointment
            {
                DoctorID = doctor.DoctorID,
                Doctor = doctor,
                AppointmentDate = model.AppointmentDate,
                AppointmentTime = DateTime.Now.TimeOfDay
            };

            await _appointmentService.AddAsync(appointment);

            return RedirectToAction("Confirmation", new { appointmentId = appointment.AppointmentID });
        }

        [HttpGet]
        public async Task<IActionResult> Confirmation(int appointmentId)
        {
            var appointment = await _appointmentService.GetByIdAsync(appointmentId);

            if (appointment == null)
            {
                //return NotFound();
                var dummyModel = new AppointmentViewModel
                {
                    PatientName = "Ahmed",
                    DoctorName = "Dr. Lobna",
                    Specialization = "Cardiology",
                    AppointmentDate = DateTime.Now
                };

                return View(dummyModel);
            }

            return View(appointment);
        }
    }
}
