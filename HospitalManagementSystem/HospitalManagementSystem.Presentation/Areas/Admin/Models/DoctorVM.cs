using HospitalManagementSystem.Presentation.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Models
{
    public class DoctorVM:DoctorViewModel
    {
        public int Id { get; set; }
        [Phone]
        public string Phone { get; set; }
        public IFormFile Image { get; set; }

    }
}
