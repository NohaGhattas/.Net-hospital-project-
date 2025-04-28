using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Data.Repositories;
using HospitalManagementSystem.Models.Dtos;
using HospitalManagementSystem.Models.Users;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Services
{
    public class UserService : GenericRepository<User>, IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context , IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> GetUserRoles(int userId)
        {
            var roleNames = await (from ur in _context.UserRoles
                                   join r in _context.Roles on ur.RoleId equals r.Id
                                   where ur.UserId == userId.ToString()
                                   select r.Name).ToListAsync();

            return roleNames;
        }
        public async Task<UsersDto> GetUserByUserNameAsync(string username)
        {
            var user = await _context.CustomUsers.FirstOrDefaultAsync(x => x.UserName == username);
            var userdto = _mapper.Map<UsersDto>(user);
            return userdto;

        }
        public async Task<bool> IsExist(string username)
        {
           return await _context.CustomUsers.AnyAsync(u => u.UserName == username);
        }
        
    }
}
