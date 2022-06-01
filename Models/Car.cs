using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservationService.Models
{
    public class Car
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int ExternalId { get; set; }

        [Required]
        public string Make { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        [Required]
        public int Mileage { get; set; }

        public double HourlyPrice { get; set; }

        public DateTime AvailableFrom { get; set; }

        public DateTime AvailableUntil { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}