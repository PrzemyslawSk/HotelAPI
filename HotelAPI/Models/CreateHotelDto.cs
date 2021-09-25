﻿using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class CreateHotelDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Stars { get; set; }
        public bool IsFoodIncluded { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        [Required]
        [MaxLength(25)]
        public string City { get; set; }
        [Required]
        [MaxLength(25)]
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
