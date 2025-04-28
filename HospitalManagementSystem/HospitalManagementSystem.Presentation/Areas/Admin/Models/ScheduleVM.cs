using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Models.Doctors;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Models
{
    public class ScheduleVM
    {
        public int ScheduleID { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Availability status is required.")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Doctor is required.")]
        public int DoctorID { get; set; }

        public virtual Doctor? Doctor { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }

        public List<SelectListItem> Doctors { get; set; }
    }
}
