using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Presentation.ViewModels
{
    public class PatientViewModel
    {
        public string? Address { get; set; }
        public string Name { get; set; }
        public Gender GenderType { get; set; }
        public string? Status { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        
    }
}
