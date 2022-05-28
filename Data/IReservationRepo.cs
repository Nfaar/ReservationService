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

        Car GetCarByReservationId(int reservationId);

        bool CarExists(int carId);

    }
}