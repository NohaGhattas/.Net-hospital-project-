using HospitalManagementSystem.Data.Repositories.Interfaces;
using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Services
{
    public class AppointmentService : IAppointmentService

    {
        private readonly IGenericRepository<Appointment> _appointmentRepository;

        public AppointmentService(IGenericRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task AddAppointmentAsync(Appointment appointment)
        {
            await _appointmentRepository.AddAsync(appointment);
        }

        public async Task DeleteAppointmentAsync(int id)
        {
           var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment != null)
            {
                _appointmentRepository.Delete(appointment);
            }
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
           return await _appointmentRepository.GetAllAsync();
        }
        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _appointmentRepository.GetByIdAsync(id);
        }
        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            _appointmentRepository.Update(appointment);
        }
       
    }
}
