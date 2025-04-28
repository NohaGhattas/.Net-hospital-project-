using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Models
{
    public class DepartmentVM
    {
        public int DepartmentID { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]

        public string? Description { get; set; }
    }
}
