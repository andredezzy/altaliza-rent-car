using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AltalizaRentCar.API.Models
{
    public class CharacterVehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public Guid CharacterId { get; set; }

        [JsonIgnore]
        public Character Character { get; set; }

        public Guid VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
