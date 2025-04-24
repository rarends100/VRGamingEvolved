using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VRGamingEvolved.Models;

namespace VRGamingEvolved.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}
        public DbSet<Game>? Game { get; set; }
        public DbSet<Users>? customers { get; set; }

    }
}
