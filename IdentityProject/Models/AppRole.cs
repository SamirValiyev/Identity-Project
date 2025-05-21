using Microsoft.AspNetCore.Identity;

namespace IdentityProject.Models
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreatedDate { get; set; }
    }
}
