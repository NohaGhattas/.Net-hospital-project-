using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.Doctors
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [MaxLength(600)]
        public string? Description { get; set; }

        public virtual ICollection<Doctor>? Doctors { get; set; }
    }
}