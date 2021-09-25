using AutoMapper;
using HotelAPI.Entities;
using HotelAPI.Exceptions;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HotelAPI.Services
{
    public interface IHotelService
    {
        HotelDto GetById(int id);
        IEnumerable<HotelDto> GetAll();
        int Create(CreateHotelDto dto);
        void Delete(int id);
        void Update(int id, UpdateHotelDto dto);
    }

    public class HotelService : IHotelService
    {
        private readonly HotelDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<HotelService> _logger;
        public HotelService(HotelDbContext dbContext, IMapper mapper, ILogger<HotelService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public void Update(int id, UpdateHotelDto dto)
        {
            var hotel = _dbContext
                .Hotels
                .FirstOrDefault(h => h.Id == id);

            if (hotel is null)
                throw new NotFoundException("Hotel not found");

            hotel.Name = dto.Name;
            hotel.Description = dto.Description;
            hotel.IsFoodIncluded = dto.IsFoodIncluded;

            _dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            _logger.LogError($"Hotel with id: {id} DELETE action invoked");

            var hotel = _dbContext
                .Hotels
                .FirstOrDefault(h => h.Id == id);

            if (hotel is null)
                throw new NotFoundException("Restaurant not found");

            _dbContext.Hotels.Remove(hotel);
            _dbContext.SaveChanges();
        }

        public HotelDto GetById(int id)
        {
            var hotel = _dbContext
            .Hotels
            .Include(r => r.Address)
            .Include(r => r.Rooms)
            .FirstOrDefault(h => h.Id == id);

            if (hotel is null)
                throw new NotFoundException("Restaurant not found");

            var result = _mapper.Map<HotelDto>(hotel);
            return result;
        }

        public IEnumerable<HotelDto> GetAll()
        {
            var hotels = _dbContext
            .Hotels
            .Include(r => r.Address)
            .Include(r => r.Rooms)
            .ToList();

            var hotelsDtos = _mapper.Map<List<HotelDto>>(hotels);

            return hotelsDtos;
        }

        public int Create(CreateHotelDto dto)
        {
            var hotel = _mapper.Map<Hotel>(dto);
            _dbContext.Hotels.Add(hotel);
            _dbContext.SaveChanges();

            return hotel.Id;
        }
    }
}
