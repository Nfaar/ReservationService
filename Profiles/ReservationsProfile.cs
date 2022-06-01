using AutoMapper;
using ReservationService.Dtos;
using ReservationService.Models;

namespace ReservationService.Profiles
{
    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {
            CreateMap<Reservation, ReservationReadDto>();
            CreateMap<ReservationCreateDto, Reservation>();
            CreateMap<Car, CarReadDto>();
            CreateMap<CarCreateDto, Car>();

            CreateMap<CarPublishedDto, Car>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));
        }
    }
}