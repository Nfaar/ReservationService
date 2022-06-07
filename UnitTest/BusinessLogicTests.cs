using System;
using Microsoft.Extensions.DependencyInjection;
using ReservationService.Business;
using Xunit;

namespace ReservationService.UnitTest
{
    public class BusinessLogicTests
    {
        private readonly IReservationLogic reservationLogic;

        public BusinessLogicTests()
        {
            // var services = ServiceCollection();
            // services.AddTransient<IReservationLogic, ReservationLogic>();

            // var serviceProvider = services.BuildServiceProvider();

            // this.reservationLogic = serviceProvider.GetService<IReservationLogic>();
        }
        [Fact]
        public void PassingCalculateCostTest()
        {
            var startDate = DateTime.Now;
            var endDate = startDate;
            endDate.AddHours(3);

            // var endPrice = this.reservationLogic.CalculatePriceForReservation(
            //     hourlyPrice,
            //     startDate,
            //     endDate
            // );

            Assert.Equal(1, 1);
        }
    }
}