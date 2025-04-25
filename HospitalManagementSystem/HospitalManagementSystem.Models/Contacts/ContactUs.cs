using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.Contacts
{
    public class ContactUs
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(600)]
        public string? Address { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Status { get; set; }
        public string? Location { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Linkedin { get; set; }

        [Phone]
        public string? Phone { get; set; }
    }
}