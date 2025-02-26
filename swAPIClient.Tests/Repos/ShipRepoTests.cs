using System.Net;
using System.Net.Http.Json;
using Moq;
using Moq.Protected;
using swAPI_Client.Models;
using Xunit;

namespace swAPI_Client.Repos
{
    public class ShipRepoTests
    {
        private readonly ShipRepo _shipRepo;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;

        public ShipRepoTests()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(_mockHttpMessageHandler.Object);
            _shipRepo = new ShipRepo(httpClient);
        }

        // this test is the most confusing one, I dont understand how C# handles HTTP requests and responses, only that the hierarchy is labrynthine
        [Fact]
        public async Task GetShipsAsync_ShouldReturnShips()
        {
            // Arrange
            var ships = new List<Ship>
            {
                new Ship { name = "X-Wing" },
                new Ship { name = "TIE Fighter" }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(new { results = ships, next = "" })
            };
            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(response);

            // Act
            var result = await _shipRepo.GetShipsAsync();

            // Assert
            Assert.Contains(result, s => s.name == "X-Wing");
            Assert.Contains(result, s => s.name == "TIE Fighter");
        }
    }
}
