using HospitalManagementSystem.Data;
using HospitalManagementSystem.Data.Repositories;
using HospitalManagementSystem.Data.Repositories.Interfaces;
using HospitalManagementSystem.Models.Contacts;
using HospitalManagementSystem.Services.Services.Interfaces;

namespace HospitalManagementSystem.Services.Services
{
    public class ContactUsService : GenericRepository<ContactUs>, IContactUsService
    {

        public ContactUsService(ApplicationDbContext context):base(context)
        {
           
        }
      
    }
}
