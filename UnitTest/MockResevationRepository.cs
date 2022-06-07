// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.Extensions.DependencyInjection;
// using ReservationService.Business;
// using ReservationService.Data;
// using ReservationService.Models;
// using Xunit;

// namespace ReservationService.UnitTest
// {
//     public class MockReservationRepository : IReservationRepo, IDisposable
//     {
//         List<Reservation> reservations = new List<Reservation>();
//         public bool CarExists(int carId)
//         {
//             throw new NotImplementedException();
//         }

//         public void CreateCar(Car car)
//         {
//             throw new NotImplementedException();
//         }

//         public void CreateReservation(Reservation reservation)
//         {
//             reservations.Add(reservation);
//         }

//         public void DeleteReservationById(int reservationId)
//         {
//             reservations.RemoveAll(x => x.Id == reservationId);
//         }

//         public void Dispose()
//         {
//             throw new NotImplementedException();
//         }

//         public bool ExternalCarExists(int externalCarId)
//         {
//             throw new NotImplementedException();
//         }

//         public List<Car> GetAllCars()
//         {
//             throw new NotImplementedException();
//         }

//         public IEnumerable<Reservation> GetAllReservations()
//         {
//             return reservations;
//         }

//         public Car GetCarById(int reservationId)
//         {
//             throw new NotImplementedException();
//         }

//         public Reservation GetReservationById(int Id)
//         {
//             throw new NotImplementedException();
//         }

//         public IEnumerable<Reservation> GetReservationsByCarId(int carId)
//         {
//             throw new NotImplementedException();
//         }

//         public bool ReservationExists(int reservationId)
//         {
//             throw new NotImplementedException();
//         }

//         public bool SaveChanges()
//         {
//             throw new NotImplementedException();
//         }
//     }
// }