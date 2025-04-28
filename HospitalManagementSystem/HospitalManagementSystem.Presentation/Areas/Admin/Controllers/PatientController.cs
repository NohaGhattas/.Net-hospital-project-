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
            var patients = await _patientService.GetAllAsync();
            var patientsList = new List<PatientVM>();
            foreach (var patient in patients)
            {
                var patientVM = new PatientVM()
                {
                    Name = patient.Name,
                    Address = patient.Address,
                    BirthDate = patient.BirthDate,
                    GenderType = patient.GenderType,
                    PhoneNumber= patient.PhoneNumber,
                    Status = patient.Status,
                    Age = DateTime.Now.Year - patient.BirthDate.Year

            };
                if (DateTime.Now.DayOfYear < patient.BirthDate.DayOfYear)
                {
                    patientVM.Age--;
                }
                patientsList.Add(patientVM);
            }
            return View(patientsList);
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
                Status = "Active",
                PhoneNumber = patientVM.PhoneNumber,
                Address = patientVM.Address,
                BirthDate = patientVM.BirthDate,
                GenderType = patientVM.GenderType,
            };
            await _patientService.AddAsync(patient);

            return RedirectToAction(nameof(AllPatients));
        }

        [HttpGet]
        public async Task<IActionResult> EditPatient(int id)
        {

            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null)
                return NotFound();

            var patientVm = new PatientVM
            {
                Name = patient.Name,
                Address = patient.Address,
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

            var oldPatient = await _patientService.GetByIdAsync(patientVM.Id);
            if (oldPatient == null)
                return NotFound();

            oldPatient.Name = patientVM.Name;
            oldPatient.Address = patientVM.Address;
            oldPatient.BirthDate = patientVM.BirthDate;
            oldPatient.PhoneNumber = patientVM.PhoneNumber;
            oldPatient.GenderType = patientVM.GenderType;

            _patientService.Update(oldPatient);
            return RedirectToAction(nameof(AllPatients));
        }
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            if (patient != null)
            {
                 patient.Status = "InActive";
            }
            return RedirectToAction(nameof(AllPatients));

        }
    }
}
