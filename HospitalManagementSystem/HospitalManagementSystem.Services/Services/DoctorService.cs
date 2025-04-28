using HospitalManagementSystem.Data.Repositories.Interfaces;
using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Models.Patients;
using HospitalManagementSystem.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IGenericRepository<Doctor> _doctorRepository;

        public DoctorService(IGenericRepository<Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task AddDoctorAsync(Doctor doctor)
        {
           await _doctorRepository.AddAsync(doctor);

        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor != null)
                _doctorRepository.Delete(doctor);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _doctorRepository.GetByIdAsync(id);
        }

        public async Task<Doctor> GetDoctorByNameAsync(string name, string? departmentName = null)
        {
            return await _doctorRepository.GetByNameAsync(name, departmentName);
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
             _doctorRepository.Update(doctor);
        }
    }
}
