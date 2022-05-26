using System.Collections.Generic;
using ReservationService.Models;

namespace ReservationService.Data
{
    public interface IReservationRepo
    {
        bool SaveChanges();

        IEnumerable<Reservation> GetAllReservations();

        Reservation GetReservationById(int Id);

        void CreateReservation(Reservation reservation);

        void DeleteReservationById(int Id);
    }
}