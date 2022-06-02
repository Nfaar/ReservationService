using System;
using ReservationService.Models;

namespace ReservationService.Dtos
{
    public class ReservationCreateDto
    {
        public double Cost { get; set; }

        public string DiscountCode { get; set; }

        public string ReservationNumber { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CarId { get; set; }

        public double HourlyPrice { get; set;}
    }
}