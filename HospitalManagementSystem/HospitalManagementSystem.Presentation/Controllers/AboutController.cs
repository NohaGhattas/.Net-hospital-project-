using HospitalManagementSystem.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Presentation.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new AboutViewModel
            {
                Title = "Our History",
                Description = "Welcome to our Hospital Appointment Management System. Our hospital was established in 2025. It is designed with both patients and healthcare professionals in mind. Our mission is to simplify the process of booking medical appointments, making it easier and more efficient for you to receive the care you need. Whether you're looking to schedule a routine check-up or a specialized consultation, our system helps you connect with doctors quickly and easily.\r\n\r\nWith our system, patients can easily register, manage their profiles, and book appointments with the doctors of their choice. You can search for doctors by name or specialty, and choose an appointment time that fits your schedule. We ensure that every step, from booking to confirmation, is seamless and straightforward.\r\n\r\nOur system also sends you timely notifications, including booking confirmations via email or SMS, so you can stay informed every step of the way. We take security seriously, with strong protection measures in place to ensure your personal information is safe and secure.\r\n\r\nWe’re here to make your healthcare journey simpler, faster, and more accessible.",
                ImageUrl = "Images/img/about/hospital2.jpg"
            };

            return View(viewModel);
        }
    }
}
