using HospitalManagementSystem.Models.Patients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Appointments
{
    public class History
    {
        [Key]
        public int HistoryID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public virtual Patient? Patient { get; set; }

        [ForeignKey("Diagnosis")]
        public int DiagnosisID { get; set; }
        public Diagnosis? Diagnosis { get; set; }
        public virtual ICollection<Prescription>? Prescriptions { get; set; }
    }
}