using AltalizaRentCar.API.Data;
using AltalizaRentCar.API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
            return _context.Characters;
        }

        public Character Create(Character character)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(character.Password);

            character.Password = hashedPassword;

            EntityEntry<Character> entity = _context.Characters.Add(character);

            _context.SaveChanges();

            return entity.Entity;
        }
    }

    public interface ICharactersService
    {
        public IEnumerable<Character> FindAll();

        public Character Create(Character character);
    }
}
