using HospitalManagementSystem.Models.Appointments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Doctors
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string? Status { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}