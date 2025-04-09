using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.Appointments
{
    public class Diagnosis
    {
        [Key]
        public int DiagnosisID { get; set; }

        [Required]
        [MaxLength(600)]
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public virtual ICollection<History>? Histories { get; set; }

    }
}