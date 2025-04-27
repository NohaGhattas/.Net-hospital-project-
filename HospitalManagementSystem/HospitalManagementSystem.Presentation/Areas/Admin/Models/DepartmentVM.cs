using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Models
{
    public class DepartmentVM
    {
        public int DepartmentID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
