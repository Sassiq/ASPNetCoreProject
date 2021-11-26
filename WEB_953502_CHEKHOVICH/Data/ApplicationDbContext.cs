using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEB_953502_CHEKHOVICH.Entities;

namespace WEB_953502_CHEKHOVICH.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Computer> Computers { get; set; }
        public DbSet<ComputerGroup> ComputerGroups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
