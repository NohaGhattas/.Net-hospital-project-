using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Services
{
    public class ScheduleService : IScheduleService
    {
        public Task AddScheduleAsync(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Task DeleteScheduleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> GetScheduleByDoctorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> GetScheduleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateScheduleAsync(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
