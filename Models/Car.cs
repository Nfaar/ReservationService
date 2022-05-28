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

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public double HourlyPrice { get; set; }

        [Required]
        public DateTime AvailableFrom { get; set; }

        [Required]
        public DateTime AvailableUntil { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}