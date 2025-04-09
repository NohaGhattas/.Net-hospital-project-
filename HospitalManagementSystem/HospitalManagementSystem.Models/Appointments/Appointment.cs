using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Models.Patients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Appointments
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public TimeSpan AppointmentTime { get; set; }
        public string? Status { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public virtual Patient? Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleID { get; set; }
        public virtual Schedule? Schedule { get; set; }

        public virtual ICollection<Prescription>? Prescriptions { get; set; }

    }
}