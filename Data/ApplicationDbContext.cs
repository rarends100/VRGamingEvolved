using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
        public DbSet<Headset> headsets { get; set; }

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
                },

                new Game
                {
                    ProductId = 2,
                    ProductName = "Vail VR",
                    Cost = 10.00m,
                    Sell = 30.00m,
                    FileName = "", //May implement file names and therefor images if time permits
                    GameVersion = "5.0",
                    GameDescription = "Action war shooter with realistic combat physics",
                    Review = "Vail VR is lit!"
                }

                );

            builder.Entity<Headset>().HasData(

                new Headset
                {
                    ProductId = 4,
                    ProductName = "Gaming Evolved Head rig 1",
                    Cost = 200.00m,
                    Sell = 350.00m,
                    FileName = "",
                    HeadsetModel = "1.0",
                    Review = "Whoa bruh, it was realer than reality bruh, rizz fizzbuzz bruh kitty fish fish brainrot0"
                }
                    );
        }

    }
}