using AltalizaRentCar.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AltalizaRentCar.API.Data
{
    public class AltalizaContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleCategory> VehicleCategories { get; set; }

        public DbSet<VehicleCategory> CharacterVehicles { get; set; }
    }
}
