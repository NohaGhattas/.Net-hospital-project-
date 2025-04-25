using HospitalManagementSystem.Models.Contacts;
using HospitalManagementSystem.Presentation.ViewModels;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Presentation.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public async Task<IActionResult> Index()
        {
            var hospitals = await _contactUsService.GetAllHospitalsAsync();
            var hospitalInfo = hospitals.FirstOrDefault();

            if (hospitalInfo == null)
            {
                //var errorViewModel = new ErrorViewModel
                //{
                //    ErrorType = "404",
                //    ErrorMessage = "Unfound Information"
                //};

                //return View("Error", errorViewModel);

                hospitalInfo = new ContactUs()
                {
                    Name = "HMS",
                    Address = "Youssef Abbas, Nasr City, Cairo Governorate 11765",
                    Phone = "+2123456789",
                    Status = "Open",
                    Location = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3452.9886850390953!2d31.317030875418062!3d30.065858817556006!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14583fb09c8bc065%3A0x67c232c16efa06f7!2sDar%20Al%20Fouad%20Hospital!5e0!3m2!1sen!2seg!4v1745616406851!5m2!1sen!2seg",
                    Facebook = "https://www.facebook.com/",
                    Twitter = "https://www.twitter.com/",
                    Linkedin = "https://www.instagram.com/",
                };
            }

            var viewModel = new ContactUsViewModel
            {
                Name = hospitalInfo.Name,
                Address = hospitalInfo.Address,
                Phone = hospitalInfo.Phone,
                Status = hospitalInfo.Status,
                Location = hospitalInfo.Location,
                Facebook = hospitalInfo.Facebook,
                Twitter = hospitalInfo.Twitter,
                LinkedIn = hospitalInfo.Linkedin
            };

            return View(viewModel);
        }
    }
}
