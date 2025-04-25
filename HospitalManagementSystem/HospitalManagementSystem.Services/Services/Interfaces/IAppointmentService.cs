using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task AddAppointmentAsync(Appointment schedule);
        Task UpdateAppointmentAsync(Appointment schedule);
        Task DeleteAppointmentAsync(int id);
        Task<Appointment> GetAppointmentByDoctorIdAsync(int id);
        Task<Appointment> GetAppointmentByPatientIdAsync(int id);
        Task<Appointment> GetAppointmentByScheduleIdAsync(int id);
    }
}
