using System;
using System.ComponentModel.DataAnnotations;

namespace ReservationService.Models
{
    public class Reservation
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public double Cost { get; set; }

        public string DiscountCode { get; set; }

        [Required]
        public string ReservationNumber { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public User User { get; set; }
    }
}