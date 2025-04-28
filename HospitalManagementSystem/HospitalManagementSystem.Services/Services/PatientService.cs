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
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }
      
        public async Task<int> GetNewPatientsTodayAsync()
        {
            var today = DateTime.Today;
            var newPatientsToday = await _context.Patients
                .Where(p => p.CreatedDate.Date == today) 
                .ToListAsync();

            return newPatientsToday.Count();
        }
        public async Task DeletePatient(int id)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.PatientID == id);
            if (patient != null)
            {
                patient.Status = "InActive";
                _context.SaveChanges();
            }
        }

    }
}
