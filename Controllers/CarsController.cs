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
    [Route("api/r/cars")]
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
        public ActionResult<IEnumerable<CarReadDto>> GetCars()
        {
            var allCars = this.repository.GetAllCars();
            return Ok(this.mapper.Map<IEnumerable<CarReadDto>>(allCars));
        }

        [HttpGet("{carId}")]
        public ActionResult<CarReadDto> GetCarById(int carId)
        {
            System.Console.WriteLine($"--> Hit GetCarByReservationId: {carId}");

            if (!this.repository.ReservationExists(carId))
            {
                return NotFound();
            }

            var car = this.repository.GetCarById(carId);

            return Ok(this.mapper.Map<CarReadDto>(car));
        }

    }
}