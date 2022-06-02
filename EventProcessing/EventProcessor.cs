using System;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ReservationService.Data;
using ReservationService.Dtos;
using ReservationService.Models;

namespace ReservationService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory scopeFactory;
        private readonly IMapper mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory,
        IMapper mapper)
        {
            this.scopeFactory = scopeFactory;
            this.mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.CarPublished:
                    addCar(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            System.Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch (eventType.Event)
            {
                case "Car_Published":
                    System.Console.WriteLine("Car Published Event Detected");
                    return EventType.CarPublished;
                default:
                    System.Console.WriteLine("Unrecognized event!");
                    return EventType.Undetermined;
            }
        }

        private void addCar(string carPublishedMessage)
        {
            using (var scope = this.scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IReservationRepo>();

                var carPublishedDto = JsonSerializer.Deserialize<CarPublishedDto>(carPublishedMessage);

                try
                {
                    var car = this.mapper.Map<Car>(carPublishedDto);
                    if (!repo.ExternalCarExists(car.ExternalId))
                    {
                        repo.CreateCar(car);
                        System.Console.WriteLine($"Car Id: {car.Id}, car make: {car.Make}");
                        repo.SaveChanges();
                        System.Console.WriteLine($"--> Car added!");
                    }
                    else
                    {
                        System.Console.WriteLine($"--> Car already exists...");
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"--> Could not add Car to DB {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        CarPublished,
        Undetermined
    }
}