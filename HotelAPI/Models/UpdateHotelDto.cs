using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class UpdateHotelDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFoodIncluded { get; set; }
    }
}
