using HospitalManagementSystem.Data.Repositories.Interfaces;
using HospitalManagementSystem.Models.Dtos;
using HospitalManagementSystem.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Services.Interfaces
{
    public interface IUserService : IGenericRepository<User>
    {
        Task<IEnumerable<string>> GetUserRoles(int userId);
        Task<UsersDto> GetUserByUserNameAsync(string username);
        Task<bool> IsExist(string username);
    }
}
