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
        }
    }
}