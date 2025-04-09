using HospitalManagementSystem.Models.Appointments;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.Patients
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        public string? Address { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Status { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<History>? Histories { get; set; }
    }
}