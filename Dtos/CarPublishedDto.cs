using System;

namespace ReservationService.Dtos
{
    public class CarPublishedDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public double HourlyPrice { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableUntil { get; set; }
        public string ReservationNumber { get; set; }

        public string Event { get; set; }
    }
}