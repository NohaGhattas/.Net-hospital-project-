using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Users
{
    public class UserDetails
    {
        [Key]
        public int UserDetailsID { get; set; }
        public string? NameAR { get; set; }
        public string? NameEN { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }

        [Phone]
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Nationality { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public virtual User? User { get; set; }
    }
}