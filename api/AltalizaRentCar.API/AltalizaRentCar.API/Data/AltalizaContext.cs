using AltalizaRentCar.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace AltalizaRentCar.API.Data
{
    public class AltalizaContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public AltalizaContext(DbContextOptions<AltalizaContext> options, IConfiguration configuration)
          : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleCategory> VehicleCategories { get; set; }

        public DbSet<VehicleCategory> CharacterVehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            var connection = Configuration.GetConnectionString(nameof(AltalizaContext));

            optionsBuilder.UseMySql(
                connection,
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }
}
