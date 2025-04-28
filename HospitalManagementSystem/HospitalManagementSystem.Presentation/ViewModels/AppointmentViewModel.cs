using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Presentation.ViewModels
{
    public class AppointmentViewModel
    {
        public string DoctorName { get; set; }
        public string Specialization { get; set; }

        [Required]
        public string PatientTitle { get; set; }

        [Required]
        public string PatientName { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }
    }
}