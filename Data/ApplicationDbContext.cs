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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Game>().HasData(

                new Game {
                    ProductId = 1,
                    ProductType = "Game",
                    ProductName = "Gorrilla Tag",
                    GameVersion = "2.0",
                    GameDescription = "Gorillas Playing Tag" }

                );
        }

    }
}
