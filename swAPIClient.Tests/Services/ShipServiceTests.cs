using Moq;
using swAPI_Client.Models;
using swAPI_Client.Repos;
using Xunit;

namespace swAPI_Client.Services
{
    public class ShipServiceTests
    {
        private readonly ShipService _shipService;
        private readonly Mock<IShipRepo> _mockShipRepo;

        public ShipServiceTests()
        {
            _mockShipRepo = new Mock<IShipRepo>();
            _shipService = new ShipService(_mockShipRepo.Object);
        }

        [Fact]
        public async Task PopulateList_ShouldPopulateShips()
        {
            // Arrange
            var ships = new List<Ship> { new Ship { name = "X-Wing" }, new Ship { name = "TIE Fighter" } };
            _mockShipRepo.Setup(repo => repo.GetShipsAsync()).ReturnsAsync(ships);

            // Act
            await _shipService.PopulateList();
            var result = _shipService.ListShips();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, s => s.Contains("X-Wing"));
            Assert.Contains(result, s => s.Contains("TIE Fighter"));
        }

        [Fact]
        public async Task ListShips_ShouldReturnShipDetails()
        {
            // Arrange
            var ships = new List<Ship> { new Ship { name = "X-Wing", model = "T-65", starship_class = "Starfighter", MGLT = "100", consumables = "1 week" } };
            _mockShipRepo.Setup(repo => repo.GetShipsAsync()).ReturnsAsync(ships);
            await _shipService.PopulateList();

            // Act
            var result = _shipService.ListShips();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, s => s.Contains("[bold yellow]Name:\t[/]X-Wing\n"));
            Assert.Contains(result, s => s.Contains("[bold yellow]Model:\t[/]T-65"));
            Assert.Contains(result, s => s.Contains("[bold yellow]Class:\t[/]Starfighter"));
            Assert.Contains(result, s => s.Contains("[bold yellow]Megalights:\t[/]100"));
        }

        [Fact]
        public async Task CalculatePitstops_ShouldReturnCorrectPitstops()
        {
            // Arrange
            var ships = new List<Ship> { new Ship { name = "X-wing", MGLT = "100", consumables = "1 week" } };
            _mockShipRepo.Setup(repo => repo.GetShipsAsync()).ReturnsAsync(ships);
            await _shipService.PopulateList();

            // Act
            var result = _shipService.CalculatePitstops(1000000);

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, s => s.Contains("[bold cyan]X-wing:[/] 59\n\n"));
        }

        [Fact]
        public async Task GetShipByName_ShouldReturnCorrectShip()
        {
            // Arrange
            var ships = new List<Ship> { new Ship { name = "X-wing", model = "T-65", starship_class = "Starfighter", MGLT = "100", consumables = "1 week" } };
            _mockShipRepo.Setup(repo => repo.GetShipsAsync()).ReturnsAsync(ships);
            await _shipService.PopulateList();

            // Act
            var result = _shipService.GetShipByName("X-wing");

            // Assert
            Assert.Contains("X-wing", result);
            Assert.Contains("T-65", result);
        }
    }
}