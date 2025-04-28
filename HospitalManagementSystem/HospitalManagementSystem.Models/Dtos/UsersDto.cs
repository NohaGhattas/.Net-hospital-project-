using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models.Dtos
{
    public class UsersDto
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

    }
}
