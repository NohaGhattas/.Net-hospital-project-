using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Presentation.ViewModels
{
    public class DoctorViewModel
    {
        [Required(ErrorMessage = "Doctor name is required.")]
        [StringLength(100, ErrorMessage = "Doctor name cannot be longer than 100 characters.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Specialization is required.")]
        [StringLength(100, ErrorMessage = "Specialization cannot be longer than 100 characters.")]
        public string? Specialization { get; set; }
        public string? Status { get; set; }
        public string? ImageURL { get; set; }
        [Required(ErrorMessage = "Schedule is required.")]

        public List<DateTime>? Schedule { get; set; } = new List<DateTime>();

    }
}
