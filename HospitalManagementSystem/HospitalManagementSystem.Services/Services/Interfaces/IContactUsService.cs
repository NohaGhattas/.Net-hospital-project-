using HospitalManagementSystem.Models.Contacts;

namespace HospitalManagementSystem.Services.Services.Interfaces
{
    public interface IContactUsService
    {
        Task<IEnumerable<ContactUs>> GetAllHospitalsAsync();
        Task<ContactUs> GetHospitalInfoByIdAsync(int id);
        Task AddHospitalInfoAsync(ContactUs hospitalInfo);
        void UpdateHospitalInfoAsync(ContactUs hospitalInfo);
        Task DeleteHospitalInfoAsync(int id);
    }
}
