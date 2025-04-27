using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult AllAppointments()
        {
            return View();
        }
    }
}
