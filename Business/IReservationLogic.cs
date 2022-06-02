using System;
using ReservationService.Models;

namespace ReservationService.Business
{
    public interface IReservationLogic
    {
        public double CalculatePriceForReservation(
            double hourlyPrice,
            DateTime startDate,
            DateTime endDate);
    }
}