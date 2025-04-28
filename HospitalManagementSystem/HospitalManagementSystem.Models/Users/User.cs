using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Users
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? PasswordHash { get; set; }
        public byte[]? StoredSalt{ get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string? Status { get; set; }

        public virtual UserDetails? UserDetails { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}