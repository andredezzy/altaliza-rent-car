using AltalizaRentCar.API.Data;
using AltalizaRentCar.API.Models;
using AltalizaRentCar.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AltalizaRentCar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly ILogger<Vehicle> _logger;
        private readonly VehiclesService _service;


        public VehiclesController(AltalizaContext context, ILogger<Vehicle> logger)
        {
            this._logger = logger;

            this._service = new VehiclesService(context, logger);
        }

        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return _service.FindAll();
        }

        [HttpPost]
        public Vehicle Create(Vehicle vehicle)
        {
            return _service.Create(vehicle);
        }
    }
}
