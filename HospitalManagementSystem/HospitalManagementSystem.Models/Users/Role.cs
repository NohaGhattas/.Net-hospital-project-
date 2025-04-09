using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.Users
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }

        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}