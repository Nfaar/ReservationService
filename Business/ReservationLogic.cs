using System;
using ReservationService.Models;

namespace ReservationService.Business
{
    public class ReservationLogic : IReservationLogic
    {
        public double CalculatePriceForReservation(
            double hourlyPrice,
            DateTime startDate,
            DateTime endDate)
        {

            var startTime = startDate;
            var endTime = endDate;

            var pricePerHour = hourlyPrice;

            var hoursDifference = endTime.Subtract(startTime).Hours;

            var calculatePrice = hoursDifference * pricePerHour;

            return calculatePrice;
        }
    }
}