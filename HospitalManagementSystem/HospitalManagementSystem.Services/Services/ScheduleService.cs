using HospitalManagementSystem.Data.Repositories.Interfaces;
using HospitalManagementSystem.Models.Appointments;
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
        private readonly IGenericRepository<Schedule> _scheduleRepository;

        public ScheduleService(IGenericRepository<Schedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        public async Task AddScheduleAsync(Schedule schedule)
        {
            await _scheduleRepository.AddAsync(schedule);
        }
        

        public async Task DeleteScheduleAsync(int id)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id);
            if (schedule != null)
            {
                _scheduleRepository.Delete(schedule);
            }
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            return await _scheduleRepository.GetAllAsync();
        }


        public async Task<Schedule> GetScheduleByIdAsync(int id)
        {
            return await _scheduleRepository.GetByIdAsync(id);
        }

        public async Task UpdateScheduleAsync(Schedule schedule)
        {
            _scheduleRepository.Update(schedule);
        }
    }
}
