using HospitalManagementSystem.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<IEnumerable<Schedule>> GetAllSchedulesAsync();
        Task<Schedule> GetScheduleByIdAsync(int id);
        Task AddScheduleAsync(Schedule schedule);
        Task UpdateScheduleAsync(Schedule schedule);
        Task DeleteScheduleAsync(int id);

    }
}
