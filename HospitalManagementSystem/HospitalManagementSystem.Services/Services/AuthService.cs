using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.DTOs;
using HospitalManagementSystem.Models.Dtos;
using HospitalManagementSystem.Models.Users;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagementSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthService(IConfiguration configuration,
            ApplicationDbContext context,
            IUserService userService,
            IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            if (!await ValidateUser(loginDto))
                return null;

            var user = await GetUserByUsername(loginDto.Username);
            var token = await GenerateJwtToken(user);

            var roles = _context.UserRoles
                                .Where(ur => ur.UserId == user.UserID.ToString())
                                .Join(_context.Roles,
                                      ur => ur.RoleId,
                                      r => r.Id,
                                      (ur, r) => r.Name)
                                .ToList();
            return new AuthResponseDto
            {
                Token = token,
                Expiration = DateTime.Now.AddMinutes(double.Parse(_configuration["JwtSettings:ExpiryInMinutes"])),
                Username = user.UserName,
                Email = user.Email,
                Roles = roles
            };
        }

        public async Task<AuthResponseDto> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username))
                return null;

            CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = Convert.ToBase64String(passwordHash),
                CreatedDate = DateTime.Now,
                Status = "Active"
            };
            var userDto = _mapper.Map<UsersDto>(user);
            
            if (user != null)
            {
                await _userService.AddAsync(user);
                await _context.SaveChangesAsync();
            }

            var token = await GenerateJwtToken(userDto);

            return new AuthResponseDto
            {
                Token = token,
                Expiration = DateTime.Now.AddMinutes(double.Parse(_configuration["JwtSettings:ExpiryInMinutes"])),
                Username = user.UserName,
                Email = user.Email,
                Roles = new List<string> { "User" }
            };
        }

        public async Task<string> GenerateJwtToken(UsersDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var roles = await _userService.GetUserRoles(user.UserID);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JwtSettings:ExpiryInMinutes"])),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<UsersDto> GetUserByUsername(string username)
        {
            return await _userService.GetUserByUserNameAsync(username);

        }

        public async Task<bool> ValidateUser(LoginDto loginDto)
        {
            var user = await GetUserByUsername(loginDto.Username);
            if (user == null)
                return false;

            return VerifyPasswordHash(loginDto.Password, Convert.FromBase64String(user.PasswordHash));
        }

        public async Task<bool> UserExists(string username)
        {
            return await _userService.IsExist(username);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt = null)
        {

            using (var hmac = new HMACSHA512(storedSalt ?? new byte[0]))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedHash);
            }
        }

    }
}