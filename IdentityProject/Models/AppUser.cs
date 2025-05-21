using Microsoft.AspNetCore.Identity;

namespace IdentityProject.Models
{
    public class AppUser:IdentityUser<int>
    {
        public string ImagePath { get; set; }
        public string Email { get; set; }
    }
}
