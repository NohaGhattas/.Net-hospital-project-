using HospitalManagementSystem.Data.Repositories.Interfaces;
using HospitalManagementSystem.Models.Patients;
using HospitalManagementSystem.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly IGenericRepository<Patient> _patientRepository;

        public PatientService(IGenericRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task AddPatientAsync(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient != null)
                _patientRepository.Delete(patient);
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            _patientRepository.Update(patient);
        }
    }
}
