using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Users
{
    public class UserRole
    {
        [Key]
        public int UserRoleID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User? User { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public virtual Role? Role { get; set; }
    }
}