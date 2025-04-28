using HospitalManagementSystem.Data.Repositories.Interfaces;
using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Services.Interfaces
{
    public interface IAppointmentService:IGenericRepository<Appointment>
    {
        
    }
}
