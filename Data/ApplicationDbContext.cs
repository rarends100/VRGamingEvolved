using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VRGamingEvolved.Models;

namespace VRGamingEvolved.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        /// <summary>
        /// https://learn.microsoft.com/en-us/ef/core/modeling/inheritance
        /// </summary>
        public DbSet<Product> products { get; set; }
        public DbSet<Game>? games { get; set; }
        public DbSet<Users>? users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Game>().HasData(

                new Game
                {
                    ProductId = 1,
                    ProductName = "Gorrilla Tag",
                    Cost = 2.00m,
                    Sell = 5.00m,
                    FileName = "", //May implement file names and therefor images if time permits
                    GameVersion = "2.0",
                    GameDescription = "Gorillas Playing Tag",
                    Review = "This game is awesome!"
                }

                );
        }

    }
}