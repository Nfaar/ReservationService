using System.Net.Http;
using Xunit;

namespace ReservationService.IntegrationTests
{
    [Trait("Category", "Integration")]
    public abstract class IntegrationTestsFixture : IClassFixture<ReservationsControllerFactory>
    {
        protected readonly ReservationsControllerFactory factory;
        protected readonly HttpClient client;

        public IntegrationTestsFixture(ReservationsControllerFactory fixture)
        {
            this.factory = fixture;
            this.client = this.factory.CreateClient();
        }
    }
}