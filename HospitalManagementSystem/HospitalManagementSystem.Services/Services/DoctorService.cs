using HospitalManagementSystem.Data;
using HospitalManagementSystem.Data.Repositories;
using HospitalManagementSystem.Data.Repositories.Interfaces;
using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Models.Patients;
using HospitalManagementSystem.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Services
{
    public class DoctorService : GenericRepository<Doctor>,IDoctorService
    {

        public DoctorService(ApplicationDbContext context ):base(context)
        {
        }
     

     

        
    }
}
