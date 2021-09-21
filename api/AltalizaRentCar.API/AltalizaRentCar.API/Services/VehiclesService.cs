using AltalizaRentCar.API.Data;
using AltalizaRentCar.API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AltalizaRentCar.API.Services
{
    public class VehiclesService : IVehiclesService
    {
        private readonly AltalizaContext _context;
        private readonly ILogger<Vehicle> _logger;

        public VehiclesService(AltalizaContext context, ILogger<Vehicle> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public IEnumerable<Vehicle> FindAll()
        {
            return _context.Vehicles;
        }

        public Vehicle Create(Vehicle vehicle)
        {
            VehicleCategory category = _context.VehicleCategories.Where(category => category.Name == vehicle.Category.Name).FirstOrDefault();

            vehicle.Category = category;

            EntityEntry<Vehicle> entity = _context.Vehicles.Add(vehicle);

            _context.SaveChanges();

            return entity.Entity;
        }
    }

    public interface IVehiclesService
    {
        public IEnumerable<Vehicle> FindAll();

        public Vehicle Create(Vehicle vehicle);
    }
}
