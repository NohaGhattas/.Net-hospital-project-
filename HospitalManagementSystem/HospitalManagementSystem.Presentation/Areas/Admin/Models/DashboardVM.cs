namespace HospitalManagementSystem.Presentation.Areas.Admin.Models
{
    public class DashboardVM
    {
        public int DoctorCount { get; set; }
        public int PatientCount { get; set; }
        public int NewPatientCount { get; set; }
        public int Appointments { get; set; }
        public int Departments { get; set; }

    }
}
