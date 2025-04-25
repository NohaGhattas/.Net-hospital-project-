using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        [HttpGet]
        public IActionResult AddDoctor()
        {
            return View();
        }
    }
}
