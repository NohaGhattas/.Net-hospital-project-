using HospitalManagementSystem.Presentation.ViewModels;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IDoctorService _doctorService;

        public DepartmentController(IDepartmentService departmentService, IDoctorService doctorService)
        {
            _departmentService = departmentService;
            _doctorService = doctorService;
        }

        private static List<DoctorViewModel> AllDoctors = new()
        {
            new DoctorViewModel { Name = "Dr. Lobna", Specialization = "Cardiology", ImageURL = "Images/img/department/doctor.jpg", Schedule = new List<DateTime>{ new DateTime(2025, 04, 27) } },
            new DoctorViewModel { Name = "Dr. Noha", Specialization = "Neurology", ImageURL = "Images/img/department/doctor.jpg", Schedule = new List<DateTime>{ new DateTime(2025, 04, 27) } },
            new DoctorViewModel { Name = "Dr. Hadeer", Specialization = "Dermatology", ImageURL = "Images/img/department/doctor.jpg", Schedule = new List<DateTime>{ new DateTime(2025, 04, 28) }},
            new DoctorViewModel { Name = "Dr. Yasmin", Specialization = "Cardiology", ImageURL = "Images/img/department/doctor.jpg", Schedule = new List<DateTime>{ new DateTime(2025, 04, 29) }},
        };

        public async Task<IActionResult> Index(string department = null, string doctorName = null, DateTime? date = null)
        {

            var departments = await _departmentService.GetAllAsync();
            var doctors = await _doctorService.GetAllAsync();
            if (departments == null || !departments.Any())
            {
                //var errorViewModel = new ErrorViewModel
                //{
                //    ErrorType = "404",
                //    ErrorMessage = "Unfound Information"
                //};

                //return View("Error", errorViewModel);

                var viewModel = new DepartmentViewModel
                {
                    Departments = new List<string> { "Cardiology", "Neurology", "Dermatology", "Pediatrics" },
                    Doctors = AllDoctors.Select(d => d.Name).ToList(),
                    SelectedDepartment = department,
                    SelectedDoctor = doctorName,
                    SelectedDate = date,
                    DoctorCards = FilterDoctors(department, doctorName, date)
                };

                return View(viewModel);
            }

            AllDoctors = [];
            foreach (var d in doctors)
            {
                var doctorCard = new DoctorViewModel()
                {
                    Name = d.Name,
                    ImageURL = d.ImageURL,
                    Specialization = d.Department.Name
                };
                foreach(var s in d.Schedules)
                {
                    if (s.IsAvailable)
                        doctorCard.Schedule?.Add(s.Date);
                }
                AllDoctors.Add(doctorCard);
            }

            var departmentModel = new DepartmentViewModel()
            {
                Departments = departments.Select(d => d.Name).ToList(),
                Doctors = doctors.Select(d => d.Name).ToList(),
                SelectedDepartment = department,
                SelectedDoctor = doctorName,
                SelectedDate = date,
                DoctorCards = FilterDoctors(department, doctorName, date)
            };

            return View(departmentModel);
        }

        private List<DoctorViewModel> FilterDoctors(string department, string doctorName, DateTime? date)
        {
            var filteredDoctors = AllDoctors.AsQueryable();

            if (!string.IsNullOrEmpty(department))
            {
                filteredDoctors = filteredDoctors.Where(d => d.Specialization.Equals(department, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(doctorName))
            {
                filteredDoctors = filteredDoctors.Where(d => d.Name.Contains(doctorName, StringComparison.OrdinalIgnoreCase));
            }

            if (date.HasValue)
            {
                filteredDoctors = filteredDoctors.Where(d => d.Schedule != null && d.Schedule.Any(s => s.Date == date.Value.Date));
            }

            return filteredDoctors.ToList();
        }

    }
}