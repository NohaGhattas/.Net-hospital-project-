using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Models
{
    public class AppointmentVM
    {
        public int AppointmentID { get; set; }  

        [Required(ErrorMessage = "Appointment date is required.")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Appointment time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan AppointmentTime { get; set; }
        public string? Status { get; set; }

        [Required(ErrorMessage = "Patient is required.")]
        public int PatientID { get; set; }

        [Required(ErrorMessage = "Doctor is required.")]
        public int DoctorID { get; set; }

        [Required(ErrorMessage = "Schedule is required.")]
        public int ScheduleID { get; set; }
    }
}
