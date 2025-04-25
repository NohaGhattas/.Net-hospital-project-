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
        public Task AddAppointmentAsync(Appointment schedule)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAppointmentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetAppointmentByDoctorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetAppointmentByPatientIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetAppointmentByScheduleIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAppointmentAsync(Appointment schedule)
        {
            throw new NotImplementedException();
        }
    }
}
