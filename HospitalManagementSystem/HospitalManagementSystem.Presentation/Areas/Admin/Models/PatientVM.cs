using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Models
{
    public class PatientVM
    {
        public int Id { get; set; }
        public string? Address { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public Gender GenderType { get; set; }
        public string? Status { get; set; }
        public DateTime BirthDate { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        
    }
}
