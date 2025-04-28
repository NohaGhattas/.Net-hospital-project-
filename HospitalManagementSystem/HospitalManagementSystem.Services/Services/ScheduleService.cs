using HospitalManagementSystem.Data;
using HospitalManagementSystem.Data.Repositories;
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
    
    public class ScheduleService : GenericRepository<Schedule>,IScheduleService
    {

        public ScheduleService(ApplicationDbContext context):base(context)
        {
            
        }
       
    }
}
