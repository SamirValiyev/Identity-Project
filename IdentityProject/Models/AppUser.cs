using IdentityProject.Enums;
using Microsoft.AspNetCore.Identity;

namespace IdentityProject.Models
{
    public class AppUser:IdentityUser<int>
    {
        public string ImagePath { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Gender Gender {  get; set; }
    }
}
