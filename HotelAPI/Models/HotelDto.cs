using System.Collections.Generic;

namespace HotelAPI.Models
{
    //Dtos are same as Entities but without confidential information
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Stars { get; set; }
        public bool IsFoodIncluded { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public List<RoomDto> Rooms { get; set; }
    }
}
