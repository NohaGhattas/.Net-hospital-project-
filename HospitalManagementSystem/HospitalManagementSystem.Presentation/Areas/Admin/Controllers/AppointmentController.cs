using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Presentation.Areas.Admin.Models;
using HospitalManagementSystem.Services.Services;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IScheduleService _scheduleService;

        public AppointmentController(IAppointmentService appointmentService,IPatientService patientService,IDoctorService doctorService,IScheduleService scheduleService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
            _scheduleService = scheduleService;
        }
        [HttpGet]
        public async Task<IActionResult> AllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            var appointmentList = new List<AppointmentVM>();
            foreach (var appointment in appointments)
            {
                var appointmentVM = new AppointmentVM()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = DateTime.Now.TimeOfDay,
                    DoctorID = appointment.AppointmentID,
                    PatientID = appointment.PatientID,
                    ScheduleID = appointment.ScheduleID,

                };
                appointmentList.Add(appointmentVM);
            }
            return View(appointmentList);
        }
        
        public async Task<IActionResult> AddAppointment()
        {
            var appointmentVM = new AppointmentVM()
            {
                Patients = (await _patientService.GetAllPatientsAsync()).Select(p => new SelectListItem
                {
                    Value = p.PatientID.ToString(),
                    Text = p.Name
                }).ToList(),
                Doctors = (await _doctorService.GetAllDoctorsAsync()).Select(p => new SelectListItem
                {
                    Value = p.DoctorID.ToString(),
                    Text = p.Name
                }).ToList(),
                Schedules = (await _scheduleService.GetAllSchedulesAsync()).Select(p => new SelectListItem
                {
                    Value = p.ScheduleID.ToString(),
                    Text = $"{p.StartDate}-{p.EndDate}"
                }).ToList()
            };

            
                return View(appointmentVM);
       

        }
        [HttpPost]
        public async Task<IActionResult> AddAppointment(AppointmentVM appointmentVM)
        {
            if (!ModelState.IsValid)
            {


                appointmentVM.Patients = (await _patientService.GetAllPatientsAsync()).Select(p => new SelectListItem
                {
                    Value = p.PatientID.ToString(),
                    Text = p.Name
                }).ToList();
                appointmentVM.Doctors = (await _doctorService.GetAllDoctorsAsync()).Select(d => new SelectListItem
                {
                    Value = d.DoctorID.ToString(),
                    Text = d.Name
                }).ToList();
                appointmentVM.Schedules = (await _scheduleService.GetAllSchedulesAsync()).Select(s => new SelectListItem
                {
                    Value = s.ScheduleID.ToString(),
                    Text = $"{s.StartDate} - {s.EndDate}"
                }).ToList();

                return View(appointmentVM);
            }

            var appointment = new Appointment()
            {
                AppointmentDate = appointmentVM.AppointmentDate,
                AppointmentTime = appointmentVM.AppointmentTime,
                Status = appointmentVM.Status,
                PatientID = appointmentVM.PatientID,
                DoctorID = appointmentVM.DoctorID,
                ScheduleID = appointmentVM.ScheduleID
            };

            await _appointmentService.AddAppointmentAsync(appointment);
            return RedirectToAction(nameof(AllAppointments));
        }
        [HttpGet]
             public async Task<IActionResult> EditAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            var appointmentVM = new AppointmentVM
            {
                AppointmentID = appointment.AppointmentID,
                AppointmentDate = appointment.AppointmentDate,
                AppointmentTime = appointment.AppointmentTime,
                Status = appointment.Status??"null",
                PatientID = appointment.PatientID,
                DoctorID = appointment.DoctorID,
                ScheduleID = appointment.ScheduleID,
                Patients = (await _patientService.GetAllPatientsAsync()).Select(p => new SelectListItem
                {
                    Value = p.PatientID.ToString(),
                    Text = p.Name
                }).ToList(),
                Doctors = (await _doctorService.GetAllDoctorsAsync()).Select(d => new SelectListItem
                {
                    Value = d.DoctorID.ToString(),
                    Text = d.Name
                }).ToList(),
                Schedules = (await _scheduleService.GetAllSchedulesAsync()).Select(s => new SelectListItem
                {
                    Value = s.ScheduleID.ToString(),
                    Text = $"{s.StartDate} - {s.EndDate}"
                }).ToList()
            };

            return View(appointmentVM);
        }
        [HttpPost]
        public async Task<IActionResult> EditAppointment(int id, AppointmentVM appointmentVM)
        {
            if (id != appointmentVM.AppointmentID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                appointmentVM.Patients = (await _patientService.GetAllPatientsAsync()).Select(p => new SelectListItem
                {
                    Value = p.PatientID.ToString(),
                    Text = p.Name
                }).ToList();
                appointmentVM.Doctors = (await _doctorService.GetAllDoctorsAsync()).Select(d => new SelectListItem
                {
                    Value = d.DoctorID.ToString(),
                    Text = d.Name
                }).ToList();
                appointmentVM.Schedules = (await _scheduleService.GetAllSchedulesAsync()).Select(s => new SelectListItem
                {
                    Value = s.ScheduleID.ToString(),
                    Text = $"{s.StartDate} - {s.EndDate}"
                }).ToList();

                return View(appointmentVM);
            }
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            appointment.AppointmentDate = appointmentVM.AppointmentDate;
            appointment.AppointmentTime = appointmentVM.AppointmentTime;
            appointment.Status = appointmentVM.Status;
            appointment.PatientID = appointmentVM.PatientID;
            appointment.DoctorID = appointmentVM.DoctorID;
            appointment.ScheduleID = appointmentVM.ScheduleID;

            await _appointmentService.UpdateAppointmentAsync(appointment);
            return RedirectToAction(nameof(AllAppointments));


        }
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            await _appointmentService.DeleteAppointmentAsync(id);

            return RedirectToAction(nameof(AllAppointments));
        }

    }
}
