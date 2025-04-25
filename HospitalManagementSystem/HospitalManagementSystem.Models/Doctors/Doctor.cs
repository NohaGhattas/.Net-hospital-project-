using HospitalManagementSystem.Models.Appointments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models.Doctors
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        public string Name { get; set; }
        public string? Specialization { get; set; }
        public string? Status { get; set; }
        public string? ImageURL { get; set; }
        public string? SpecialtyLevel {  get; set; }
        public string Phone { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>();
        public virtual ICollection<Appointment> Appointments { get; set; }=new HashSet<Appointment>();
    }
}