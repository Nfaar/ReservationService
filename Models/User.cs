using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservationService.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

        [Required]
        public string DrivingLicenseNumber { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}