using HospitalManagementSystem.Presentation.Areas.Admin.Models;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    public class HomeController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public HomeController(IDepartmentService departmentService, IAppointmentService appointmentService, IDoctorService doctorService,IPatientService patientService)
        {
            _departmentService = departmentService;
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _patientService = patientService;
        }
        public async Task<IActionResult> Index()
        {
            var dashboard = new DashboardVM();
            dashboard.Appointments = (await _appointmentService.GetAllAsync()).Count();
            dashboard.Departments = (await _departmentService.GetAllAsync()).Count();
            dashboard.PatientCount =(await _patientService.GetAllAsync()).Count();
            dashboard.DoctorCount =(await _doctorService.GetAllAsync()).Count();
            dashboard.NewPatientCount = await _patientService.GetNewPatientsTodayAsync();
            return View(dashboard);
        }
        //[HttpGet]
        //public async Task<IActionResult> HomeContent()
        //{

        //}
        //[HttpPost]
        //public async Task<IActionResult> HomeContent()
        //{

        //}


    }
}
