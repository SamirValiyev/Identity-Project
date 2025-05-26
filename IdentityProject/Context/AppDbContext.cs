using IdentityProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }
}
