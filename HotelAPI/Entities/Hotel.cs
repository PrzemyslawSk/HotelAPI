using System.Collections.Generic;

namespace HotelAPI.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Stars { get; set; }
        public bool IsFoodIncluded { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual List<Room> Rooms { get; set; }
    }
}
