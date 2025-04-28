
using HospitalManagementSystem.DTOs;
using HospitalManagementSystem.Models.Dtos;
using HospitalManagementSystem.Models.Users;

public interface IAuthService
{
    Task<AuthResponseDto> Login(LoginDto loginDto);
    Task<AuthResponseDto> Register(RegisterDto registerDto);
    Task<string> GenerateJwtToken(UsersDto user);
    Task<UsersDto> GetUserByUsername(string username);
    Task<bool> ValidateUser(LoginDto loginDto);
    Task<bool> UserExists(string username);
}