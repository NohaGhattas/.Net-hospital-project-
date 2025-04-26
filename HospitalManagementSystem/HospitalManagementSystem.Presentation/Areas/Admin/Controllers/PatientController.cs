using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Models.Patients;
using HospitalManagementSystem.Presentation.Areas.Admin.Models;
using HospitalManagementSystem.Services.Services;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet]
        public async Task<IActionResult> AllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return View(patients);
        }
        [HttpGet]
        public IActionResult AddPatient()
        {
            return View(new PatientVM());
        }
        [HttpPost]
        public async Task<IActionResult> AddPatient(PatientVM patientVM)
        {
            if (!ModelState.IsValid)
                return View(patientVM);

            var patient = new Patient()
            {
                Name = patientVM.Name,
                Status = patientVM.Status,
                PhoneNumber = patientVM.PhoneNumber,
                Address = patientVM.Address,
                BirthDate = patientVM.BirthDate,
                GenderType = patientVM.GenderType,
            };
            await _patientService.AddPatientAsync(patient);

            await _patientService.AddPatientAsync(patient);
            return RedirectToAction(nameof(AllPatients));
        }

        [HttpGet]
        public async Task<IActionResult> EditPatient(int id)
        {

            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
                return NotFound();

            var patientVm = new PatientVM
            {
                Name = patient.Name,
                Address = patient.Address,
                Status = patient.Status,
                BirthDate = patient.BirthDate,
                PhoneNumber = patient.PhoneNumber,
                GenderType = patient.GenderType
            };
            return View(patientVm);
        }
        [HttpPost]
        public async Task<IActionResult> EditPatient(PatientVM patientVM)
        {
            if (!ModelState.IsValid)
                return View(patientVM);

            var oldPatient = await _patientService.GetPatientByIdAsync(patientVM.Id);
            if (oldPatient == null)
                return NotFound();

            oldPatient.Name = patientVM.Name;
            oldPatient.Address = patientVM.Address;
            oldPatient.Status = patientVM.Status;
            oldPatient.BirthDate = patientVM.BirthDate;
            oldPatient.PhoneNumber = patientVM.PhoneNumber;
            oldPatient.GenderType = patientVM.GenderType;

            await _patientService.UpdatePatientAsync(oldPatient);
            return RedirectToAction(nameof(AllPatients));
        }
        [HttpPost]
        public async Task DeletePatient(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient != null)
            {
                await _patientService.DeletePatientAsync(id);
            }

        }
    }
}
