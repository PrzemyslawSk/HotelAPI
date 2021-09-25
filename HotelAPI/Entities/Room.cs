namespace HotelAPI.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
