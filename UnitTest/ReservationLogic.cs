// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Web;
// using ReservationService.Data;
// using ReservationService.Models;

// namespace ReservationService.UnitTest
// {
//     public class ReservationLogic : IDisposable
//     {
//         private IReservationRepo reservationRepo;

//         public ReservationLogic()
//         {
//             this.reservationRepo = new ReservationRepo();
//         }

//         public ReservationLogic(IReservationRepo reservationRepo)
//         {
//             this.reservationRepo = reservationRepo;
//         }

//         public IEnumerable<Reservation> GetReservations()
//         {
//             return reservationRepo.GetAllReservations();
//         }

//         public void InsertReservation(Reservation reservation)
//         {
//             try
//             {
//                 reservationRepo.CreateReservation(reservation);
//             }
//             catch (Exception ex)
//             {
//                 //Include catch blocks for specific exceptions first,
//                 //and handle or log the error as appropriate in each.
//                 //Include a generic catch block like this one last.
//                 throw ex;
//             }
//         }

//         public void DeleteReservation(Reservation reservation)
//         {

//         }

//         public void UpdateReservation(Reservation reservation)
//         {

//         }

//         private bool disposedValue = false;

//         protected virtual void Dispose(bool disposing)
//         {

//         }

//         public void Dispose()
//         {
//             Dispose(true);
//             GC.SuppressFinalize(this);
//         }

//     }
// }