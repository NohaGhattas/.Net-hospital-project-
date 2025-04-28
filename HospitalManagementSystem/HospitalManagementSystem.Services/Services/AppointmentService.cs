using HospitalManagementSystem.Data;
using HospitalManagementSystem.Data.Repositories;
using HospitalManagementSystem.Data.Repositories.Interfaces;
using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Models.Users;
using HospitalManagementSystem.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Services
{
    public class AppointmentService : GenericRepository<Appointment>, IAppointmentService
    {
        public AppointmentService(ApplicationDbContext context):base(context)
        {
                
        }
    }
}
