using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReservationService.Models;

namespace ReservationService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }


        private static void SeedData(AppDbContext context, bool isProd)
        {   
            if(isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }

            if(!context.Reservations.Any())
            {
                Console.WriteLine("Seeding data");

                context.Reservations.AddRange(
                    new Reservation() {ReservationNumber = "#001", Cost = 23.99},
                    new Reservation() {ReservationNumber = "#002", Cost = 25.99},
                    new Reservation() {ReservationNumber = "#003", Cost = 28.99}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Already have data.");
            }
        }
    }
}