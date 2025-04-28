using HospitalManagementSystem.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Models
{
    public class EditDoctorVM:DoctorViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; }
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Please select a department.")]

        public int? DepartmentId { get; set; }
        public string? SpecialityLevel { get; set; }


        public List<SelectListItem>? Departments { get; set; }
    }
}
