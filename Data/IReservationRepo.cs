using System.Collections.Generic;
using ReservationService.Models;

namespace ReservationService.Data
{
    public interface IReservationRepo
    {
        bool SaveChanges();

        // Reservations

        IEnumerable<Reservation> GetAllReservations();

        Reservation GetReservationById(int Id);

        IEnumerable<Reservation> GetReservationsByCarId(int carId);

        void CreateReservation(Reservation reservation);

        void DeleteReservationById(int reservationId);

        bool ReservationExists(int reservationId);

        // Car

        Car GetCarById(int reservationId);

        void CreateCar(Car car);

        bool CarExists(int carId);

        bool ExternalCarExists(int externalCarId);
        List<Car> GetAllCars();
    }
}