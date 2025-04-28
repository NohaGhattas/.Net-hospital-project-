using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Models
{
    public class AppointmentVM
    {
        public int AppointmentID { get; set; }

        [Required(ErrorMessage = "Appointment Date is required.")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Appointment Time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan AppointmentTime { get; set; }

        [StringLength(50, ErrorMessage = "Status can't be longer than 50 characters.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Patient is required.")]
        public int PatientID { get; set; }

        [Required(ErrorMessage = "Doctor is required.")]
        public int DoctorID { get; set; }

        [Required(ErrorMessage = "Schedule is required.")]
        public int ScheduleID { get; set; }

        public List<SelectListItem> Patients { get; set; }
        public List<SelectListItem> Doctors { get; set; }
        public List<SelectListItem> Schedules { get; set; }
    }
}
