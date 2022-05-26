using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReservationService.Data;
using ReservationService.Dtos;
using ReservationService.Models;

namespace ReservationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservataionsController : ControllerBase
    {
        private IReservationRepo repository;
        private IMapper mapper;

        public ReservataionsController(
            IReservationRepo repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReservationReadDto>> GetReservations()
        {
            Console.WriteLine("--> Getting Reservations....");

            var allReservations = this.repository.GetAllReservations();
            return Ok(this.mapper.Map<IEnumerable<ReservationReadDto>>(allReservations));
        }

        [HttpGet]
        public ActionResult<ReservationReadDto> GetReservationById(int id)
        {
            Console.WriteLine("HUIIII");
            var singleReservation = this.repository.GetReservationById(id);
            {
                return Ok(this.mapper.Map<IEnumerable<ReservationReadDto>>(singleReservation));
            }
        }

        [HttpPost]
        public async Task<ActionResult<ReservationReadDto>> CreateReservation(
            ReservationCreateDto reservationCreateDto)
        {

            // If it is not null store it in the database
            // TODO viknay: check what additional verification is needed
            if (reservationCreateDto == null)
            {
                throw new ArgumentNullException("Please provide valid input!");
            }


            var reservationModel = this.mapper.Map<Reservation>(reservationCreateDto);
            this.repository.CreateReservation(reservationModel);

            var reservationReadDto = this.mapper.Map<ReservationReadDto>(reservationModel);

            // TODO viknay: publish to event bus

            return CreatedAtRoute(nameof(GetReservationById), new { reservationReadDto.Id }, reservationReadDto);
        }

        [HttpDelete]
        public void DeleteSingleReservation(int id)
        {
            if (id < 0)
            {
                throw new Exception("Ids cannot be negative!");
            }

            try
            {
                this.repository.DeleteReservationById(id);
                this.repository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid reservation Id.", ex);
            }
        }

    }
}