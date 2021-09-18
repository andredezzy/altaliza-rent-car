using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltalizaRentCar.API.Models
{
    public class CharacterVehicles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public Guid CharacterId { get; set; }

        public Character Character { get; set; }

        public Guid VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
