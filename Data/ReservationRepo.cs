using System;
using System.Collections.Generic;
using System.Linq;
using ReservationService.Models;

namespace ReservationService.Data
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly AppDbContext context;

        public ReservationRepo(AppDbContext context)
        {
            this.context = context;
        }

        public ReservationRepo()
        {

        }
        // Reservations
        public void CreateReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            else
            {
                this.context.Reservations.Add(reservation);
                this.context.SaveChanges();
            }
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return this.context.Reservations.ToList();
        }

        public Reservation GetReservationById(int Id)
        {
            return this.context.Reservations.FirstOrDefault(r => r.Id == Id);
        }

        public void DeleteReservationById(int Id)
        {
            var reservation = this.context.Reservations.FirstOrDefault(r => r.Id == Id);
            if (reservation != null)
            {
                this.context.Reservations.Remove(reservation);
                this.context.SaveChanges();
            }
            else
            {
                throw new Exception("There is no existing reservation with that id.");
            }

        }

        public IEnumerable<Reservation> GetReservationsByCarId(int carId)
        {
            return this.context.Reservations.Where(r => r.CarId == carId);
        }

        public bool ReservationExists(int reservationId)
        {
            return this.context.Reservations.Any(r => r.Id == reservationId);
        }

        public bool SaveChanges()
        {
            return (this.context.SaveChanges() >= 0);
        }

        // Cars

        public Car GetCarById(int carId)
        {
            return this.context.Cars.FirstOrDefault(r => r.Id == carId);
        }

        public bool CarExists(int carId)
        {
            return this.context.Cars.Any(c => c.Id == carId);
        }

        public bool ExternalCarExists(int externalCarId)
        {
            return this.context.Cars.Any(c => c.ExternalId == externalCarId);
        }

        public void CreateCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            this.context.Cars.Add(car);
        }

        public List<Car> GetAllCars()
        {
            return this.context.Cars.ToList();
        }
    }
}