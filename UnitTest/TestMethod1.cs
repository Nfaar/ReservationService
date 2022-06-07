// using System;
// using ReservationService.Models;
// using ReservationService.UnitTest;
// using BusinessLogic = ReservationService.Business;
// using TestLogic = ReservationService.UnitTest;

// TestLogic.ReservationLogic CreateReservationLogic()
// {
//     var reservationRepository = new MockReservationRepository();
//     var reservationLogic = new TestLogic.ReservationLogic(reservationRepository);
//     reservationLogic.InsertReservation(new Reservation() { ReservationNumber = "#001", Cost = 23.99, StartTime = DateTime.Now, CarId = 21 });
//     reservationLogic.InsertReservation(new Reservation() { ReservationNumber = "#001", Cost = 23.99, StartTime = DateTime.Now, CarId = 21 });
//     reservationLogic.InsertReservation(new Reservation() { ReservationNumber = "#001", Cost = 23.99, StartTime = DateTime.Now, CarId = 21 });
//     return reservationLogic;
// }