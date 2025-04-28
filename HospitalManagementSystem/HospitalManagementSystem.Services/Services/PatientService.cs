using HospitalManagementSystem.Data;
using HospitalManagementSystem.Data.Repositories;
using HospitalManagementSystem.Data.Repositories.Interfaces;
using HospitalManagementSystem.Models.Patients;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Services
{
    public class PatientService : GenericRepository<Patient>,IPatientService
    {
        private readonly ApplicationDbContext _appContext;

        public PatientService(ApplicationDbContext appContext):base(appContext) 
        {
            _appContext = appContext;
        }
      
        public async Task<int> GetNewPatientsTodayAsync()
        {
            var today = DateTime.Today;
            var newPatientsToday = await _appContext.Patients
                .Where(p => p.CreatedDate.Date == today) 
                .ToListAsync();

            return newPatientsToday.Count();
        }
    }
}
