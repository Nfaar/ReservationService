using Microsoft.EntityFrameworkCore;
using ReservationService.Models;

namespace ReservationService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Reservation>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Reservations)
                .HasForeignKey(c => c.CarId);

            modelBuilder
                .Entity<Car>()
                .HasMany(c => c.Reservations)
                .WithOne(r => r.Car)
                .HasForeignKey(r => r.CarId);

            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Cars)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}