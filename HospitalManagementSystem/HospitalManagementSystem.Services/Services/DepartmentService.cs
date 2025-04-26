using HospitalManagementSystem.Data.Repositories.Interfaces;
using HospitalManagementSystem.Models.Doctors;
using HospitalManagementSystem.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepository<Department> _departRepository;

        public DepartmentService(IGenericRepository<Department> departRepository)
        {
            _departRepository = departRepository;
        }
        public Task AddDoctorAsync(Department department)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDepartmentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _departRepository.GetAllAsync();
        }

        public Task<Department> GetDepartmentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
