using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReservationService.Data;
using ReservationService.Dtos;
using ReservationService.Models;
using Microsoft.Extensions.Logging;
using ReservationService.Business;

namespace ReservationService.Controllers
{
    [Route("/api/r/reservations/")]
    [ApiController]
    public class ReservataionsController : ControllerBase
    {
        private IReservationRepo repository;
        private IMapper mapper;
        private readonly ILogger<ReservataionsController> logger;
        private readonly IReservationLogic reservationLogic;

        public ReservataionsController(
            IReservationRepo repository,
            IMapper mapper,
            ILogger<ReservataionsController> logger,
            IReservationLogic reservationLogic)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
            this.reservationLogic = reservationLogic;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReservationReadDto>> GetReservations()
        {
            this.logger.LogInformation("--> Getting Reservations....");

            var allReservations = this.repository.GetAllReservations();
            return Ok(this.mapper.Map<IEnumerable<ReservationReadDto>>(allReservations));
        }

        [HttpGet("{reservationId}")]
        public ActionResult<ReservationReadDto> GetReservationById(int reservationId)
        {
            this.logger.LogInformation($"--> Hit GetReservationById: {reservationId}");
            var singleReservation = this.repository.GetReservationById(reservationId);
            {
                return Ok(this.mapper.Map<ReservationReadDto>(singleReservation));
            }
        }

        [HttpGet("{carId}/reservations", Name = "GetReservationsForCar")]
        public ActionResult<IEnumerable<ReservationReadDto>> GetReservationsForCar(int carId)
        {
            this.logger.LogInformation($"--> Hit GetReservationsForCar:{carId}");

            if (!this.repository.CarExists(carId))
            {
                return NotFound();
            }

            var reservations = this.repository.GetReservationsByCarId(carId);

            if (reservations == null)
            {
                return NotFound();
            }

            return Ok(this.mapper.Map<IEnumerable<ReservationReadDto>>(reservations));
        }


        [HttpPost]
        public ActionResult<ReservationReadDto> CreateReservation(
            ReservationCreateDto reservationCreateDto)
        {

            // If it is not null store it in the database
            // TODO viknay: check what additional verification is needed
            System.Console.WriteLine("Hitting reseration post.");
            if (reservationCreateDto == null)
            {
                var exception = new ArgumentNullException("Please provide valid input!");
                this.logger.LogError(exception.Message);
                throw exception;
            }


            var reservationModel = this.mapper.Map<Reservation>(reservationCreateDto);

            System.Console.WriteLine($"HP: {reservationModel.HourlyPrice}");

            System.Console.WriteLine($"ST: {reservationModel.StartTime}");

            System.Console.WriteLine($"ET: {reservationModel.EndTime}");

            if (reservationModel.HourlyPrice! > 0 ||
            reservationModel.StartTime != new DateTime() ||
            reservationModel.EndTime != new DateTime())
            {
                reservationModel.Cost = this.reservationLogic.CalculatePriceForReservation(
                    reservationModel.HourlyPrice,
                    reservationModel.StartTime,
                    reservationModel.EndTime
                );
            }
            this.repository.CreateReservation(reservationModel);

            var reservationReadDto = this.mapper.Map<ReservationReadDto>(reservationModel);

            // TODO viknay: publish to event bus

            return Ok(reservationReadDto);
        }

        [HttpDelete]
        public void DeleteSingleReservation(int id)
        {
            if (id < 0)
            {
                var exception = new Exception("Ids cannot be negative!");
                this.logger.LogError(exception.Message);
                throw exception;
            }

            try
            {
                this.repository.DeleteReservationById(id);
                this.repository.SaveChanges();
            }
            catch (Exception ex)
            {
                var exception = new Exception("Invalid reservation Id.", ex);
                this.logger.LogError(exception.Message);
                throw exception;
            }
        }

    }
}