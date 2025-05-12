using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.Context
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext():base()
        {
            
        }
    }
}
