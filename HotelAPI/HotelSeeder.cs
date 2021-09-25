using HotelAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HotelAPI
{
    public class HotelSeeder
    {
        private readonly HotelDbContext _dbContext;
        public HotelSeeder(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Hotels.Any())
                {
                    var hotels = GetHotels();
                    _dbContext.Hotels.AddRange(hotels);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Hotel> GetHotels()
        {
            var hotels = new List<Hotel>()
            {
                new Hotel()
                {
                    Name = "ComfyHotel",
                    Description = "Very comfy hotel for whole family",
                    Stars = 3.2,
                    IsFoodIncluded = false,
                    ContactEmail = "comfy@hotel.com",
                    ContactNumber = "123456789",
                    Rooms = new List<Room>()
                    {
                        new Room()
                        {
                            Name = "3 person",
                            Price = "50$"
                        },
                        new Room()
                        {
                            Name = "4 person",
                            Price = "72$"
                        },
                        new Room()
                        {
                            Name = "5 person",
                            Price = "100$"
                        },
                    },
                    Address = new Address()
                    {
                        City = "Warszawa",
                        Street = "Bronowicka 15",
                        PostalCode = "27-100"
                    }
                },
                new Hotel()
                {
                    Name = "ChillHotel",
                    Description = "Hotel to chill with friends",
                    Stars = 2.5,
                    IsFoodIncluded = true,
                    ContactEmail = "chill@hotel.com",
                    ContactNumber = "987654321",
                    Rooms = new List<Room>()
                    {
                        new Room()
                        {
                            Name = "2 person",
                            Price = "20$"
                        },
                        new Room()
                        {
                            Name = "4 person",
                            Price = "33$"
                        },
                        new Room()
                        {
                            Name = "6 person",
                            Price = "45$"
                        },
                        new Room()
                        {
                            Name = "12 person",
                            Price = "150$"
                        },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Macieja 3",
                        PostalCode = "35-201"
                    }
                },
                new Hotel()
                {
                    Name = "RichyHotel",
                    Description = "Hotel for people who value comfort",
                    Stars = 4.7,
                    IsFoodIncluded = true,
                    ContactEmail = "richy@hotel.com",
                    ContactNumber = "555777222",
                    Rooms = new List<Room>()
                    {
                        new Room()
                        {
                            Name = "1 person",
                            Price = "100$"
                        },
                        new Room()
                        {
                            Name = "2 person",
                            Price = "230$"
                        },
                        new Room()
                        {
                            Name = "3 person",
                            Price = "300$"
                        },
                        new Room()
                        {
                            Name = "4 person",
                            Price = "410$"
                        },
                    },
                    Address = new Address()
                    {
                        City = "Poznań",
                        Street = "Kasztanowa 72",
                        PostalCode = "88-129"
                    }
                }
            };
            return hotels;
        }
    }
}
