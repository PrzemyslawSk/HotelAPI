using AutoMapper;
using HotelAPI.Entities;
using HotelAPI.Models;

namespace HotelAPI
{
    public class HotelMappingProfile : Profile
    {
        public HotelMappingProfile()
        {
            CreateMap<Hotel, HotelDto>()
                .ForMember(m => m.City, c => c.MapFrom(d => d.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(d => d.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(d => d.Address.PostalCode));

            CreateMap<Room, RoomDto>();

            CreateMap<CreateHotelDto, Hotel>()
                .ForMember(a => a.Address, b => b.MapFrom(dto => new Address()
                { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));

        }
    }
}
