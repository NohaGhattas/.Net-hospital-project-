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
            dashboard.Appointments = (await _appointmentService.GetAllAppointmentsAsync()).Count();
            dashboard.Departments = (await _departmentService.GetAllDepartmentsAsync()).Count();
            dashboard.PatientCount =(await _patientService.GetAllPatientsAsync()).Count();
            dashboard.DoctorCount =(await _doctorService.GetAllDoctorsAsync()).Count();
            dashboard.NewPatientCount = await _patientService.GetNewPatientsTodayAsync();
            return View(dashboard);
        }

    }
}
