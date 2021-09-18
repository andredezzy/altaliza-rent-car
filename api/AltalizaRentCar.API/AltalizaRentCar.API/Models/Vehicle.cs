using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltalizaRentCar.API.Models
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public VehicleCategory Category { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public string Imagem { get; set; }

        public string Price_1Days { get; set; }

        public string Price_7Days { get; set; }

        public string Price_15Days { get; set; }

        public ICollection<CharacterVehicles> CharacterVehicles { get; set; }
    }
}
