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
        public async Task AddDepartmentAsync(Department department)
        {
            await _departRepository.AddAsync(department);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _departRepository.GetByIdAsync(id);
            if (department != null)
            {
                _departRepository.Delete(department);
            }
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _departRepository.GetAllAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _departRepository.GetByIdAsync(id);
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
             _departRepository.Update(department);
        }
    }
}
