using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AltalizaRentCar.API.Models
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        [Required]
        public VehicleCategory Category { get; set; }

        [Required]
        public string Name { get; set; }

        [DefaultValue(0)]
        public int Stock { get; set; }

        [Required]
        public string Imagem { get; set; }

        [Required]
        public double Price_1Days { get; set; }

        [Required]
        public double Price_7Days { get; set; }

        [Required]
        public double Price_15Days { get; set; }

        [JsonIgnore]
        public ICollection<CharacterVehicle> CharacterVehicles { get; set; }
    }
}
