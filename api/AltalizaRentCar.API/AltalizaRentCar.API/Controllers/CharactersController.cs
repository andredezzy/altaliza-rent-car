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
    public class CharactersController : ControllerBase
    {
        private readonly ILogger<Character> _logger;
        private readonly CharactersService _service;


        public CharactersController(AltalizaContext context, ILogger<Character> logger)
        {
            this._logger = logger;

            this._service = new CharactersService(context, logger);
        }

        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return _service.FindAll();
        }

        [HttpPost]
        public Character Create(Character character)
        {
            return _service.Create(character);
        }
    }
}
