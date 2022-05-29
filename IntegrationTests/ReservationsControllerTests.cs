using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReservationService.Dtos;
using ReservationService.Models;
using Xunit;

namespace ReservationService.IntegrationTests
{
    public class ReservationsControllerTests : IntegrationTestsFixture
    {
        public ReservationsControllerTests(ReservationsControllerFactory fixture)
            : base(fixture) { }

        [Fact]
        public async Task GET_Reservations()
        {
            var reservations = await this.client.GetFromJsonAsync<IEnumerable<ReservationReadDto>>("/api/reservations/");

        }
    }
}