using HospitalManagementSystem.Data.Repositories.Interfaces;
using HospitalManagementSystem.Models.Contacts;
using HospitalManagementSystem.Services.Services.Interfaces;

namespace HospitalManagementSystem.Services.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly IGenericRepository<ContactUs> _hospitalInfoRepository;

        public ContactUsService(IGenericRepository<ContactUs> doctorRepository)
        {
            _hospitalInfoRepository = doctorRepository;
        }
        public async Task<IEnumerable<ContactUs>> GetAllHospitalsAsync()
        {
            return await _hospitalInfoRepository.GetAllAsync();
        }
        public async Task<ContactUs> GetHospitalInfoByIdAsync(int id)
        {
            return await _hospitalInfoRepository.GetByIdAsync(id);
        }

        public async Task AddHospitalInfoAsync(ContactUs hospitalInfo)
        {
            await _hospitalInfoRepository.AddAsync(hospitalInfo);

        }

        public void UpdateHospitalInfoAsync(ContactUs hospitalInfo)
        {
            _hospitalInfoRepository.Update(hospitalInfo);
        }

        public async Task DeleteHospitalInfoAsync(int id)
        {
            var hospitalInfo = await _hospitalInfoRepository.GetByIdAsync(id);
            if (hospitalInfo != null)
                _hospitalInfoRepository.Delete(hospitalInfo);
        }
    }
}
