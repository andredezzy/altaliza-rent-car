using AltalizaRentCar.API.Data;
using AltalizaRentCar.API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AltalizaRentCar.API.Services
{
    public class CharactersService : ICharactersService
    {
        private readonly AltalizaContext _context;
        private readonly ILogger<Character> _logger;

        public CharactersService(AltalizaContext context, ILogger<Character> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public IEnumerable<Character> FindAll()
        {
            return _context.Characters
                .Include(character => character.CharacterVehicles)
                .ThenInclude(characterVehicle => characterVehicle.Vehicle);
        }

        public Character Create(Character character)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(character.Password);

            character.Password = hashedPassword;

            EntityEntry<Character> entity = _context.Characters.Add(character);

            _context.SaveChanges();

            return entity.Entity;
        }

        public Character RentVehicle(Guid characterId, Guid vehicleId)
        {
            Character character = _context.Characters.Find(characterId);

            if (character == null) {
                throw new Exception("Character not found");
            }

            Vehicle vehicle = _context.Vehicles.Find(vehicleId);

            if (vehicle == null)
            {
                throw new Exception("Vehicle not found");
            }

            CharacterVehicle characterVehicle = new CharacterVehicle {
                CharacterId = characterId,
                VehicleId = vehicleId
            };

            if (character.CharacterVehicles == null) {
                character.CharacterVehicles = new List<CharacterVehicle>();
            }

            character.CharacterVehicles.Add(characterVehicle);

            _context.SaveChanges();

            return character;
        }
    }

    public interface ICharactersService
    {
        public IEnumerable<Character> FindAll();

        public Character Create(Character character);
    }
}
