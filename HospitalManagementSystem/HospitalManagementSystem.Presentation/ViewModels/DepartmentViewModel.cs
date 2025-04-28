namespace HospitalManagementSystem.Presentation.ViewModels
{
    public class DepartmentViewModel
    {
        public string? Name { get; set; }
        public List<string>? Departments { get; set; }

        public List<string>? Doctors { get; set; }

        public string? SelectedDepartment { get; set; }

        public string? SelectedDoctor { get; set; }

        public DateTime? SelectedDate { get; set; }

        public List<DoctorViewModel>? DoctorCards { get; set; }
    }
}
