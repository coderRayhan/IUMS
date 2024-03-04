using IUMS.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int EmpId { get; set; }
        public int StudentId { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsActive { get; set; } = false;
    }
}