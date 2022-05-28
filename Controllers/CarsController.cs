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
    [Route("api/r/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private IReservationRepo repository;
        private IMapper mapper;

        public CarsController(
            IReservationRepo repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<CarReadDto> GetCarByReservationId(int reservationId)
        {
            System.Console.WriteLine($"--> Hit GetCarByReservationId: {reservationId}");

            if (!this.repository.ReservationExists(reservationId))
            {
                return NotFound();
            }

            var car = this.repository.GetCarByReservationId(reservationId);

            return Ok(this.mapper.Map<CarReadDto>(car));
        }

    }
}