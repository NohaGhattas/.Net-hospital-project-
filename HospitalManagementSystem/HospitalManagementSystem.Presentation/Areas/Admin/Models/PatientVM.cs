using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Models
{
    public class PatientVM
    {
        public int Id { get; set; }
       
        public string? Address { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gender is required.")]

        public Gender GenderType { get; set; }
        public string? Status { get; set; }
        [Required(ErrorMessage = "BirthDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid birthdate format.")]
        public DateTime BirthDate { get; set; }
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }
        public decimal? Age { get; set; }
        
    }
}
