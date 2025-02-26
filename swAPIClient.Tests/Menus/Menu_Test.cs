using Moq;
using swAPI_Client.Models;
using swAPI_Client.Services;
using Xunit;

namespace swAPI_Client.Menus
{
    public class MenuTests
    {
        private readonly Menu _menu;
        private readonly Mock<IShipService> _mockShipService;
        private readonly Mock<IConsoleOutput> _mockConsoleOutput;
        private readonly Mock<IConsoleInput> _mockConsoleInput;

        public MenuTests()
        {
            _mockShipService = new Mock<IShipService>();
            _mockConsoleOutput = new Mock<IConsoleOutput>();
            _mockConsoleInput = new Mock<IConsoleInput>();
            _menu = new Menu(_mockShipService.Object, _mockConsoleOutput.Object, _mockConsoleInput.Object);
        }

        [Fact]
        public void Show_ShouldDisplayMenuOptions()
        {
            // Arrange
            var mockShipService = new Mock<IShipService>();
            var mockConsoleOutput = new MockConsoleOutput();
            var mockConsoleInput = new MockConsoleInput(new List<string> { "Exit" });
            var menu = new Menu(mockShipService.Object, mockConsoleOutput, mockConsoleInput);

            // Act
            menu.Show();

            // Assert
            Assert.Contains("List All Ships", mockConsoleInput.prompts);
            Assert.Contains("Full Ship Data", mockConsoleInput.prompts);
            Assert.Contains("Calculate Pitstops", mockConsoleInput.prompts);
            Assert.Contains("Exit", mockConsoleInput.prompts);
        }

        [Fact]
        public void ShowPitstops_ShouldDisplayCorrectPitstops()
        {
            // Arrange
            var mockShipService = new Mock<IShipService>();
            mockShipService.Setup(x => x.CalculatePitstops(It.IsAny<decimal>())).Returns(new List<string> { "Pitstop 1\n", "Pitstop 2\n" });
            var mockConsoleOutput = new MockConsoleOutput();
            var mockConsoleInput = new MockConsoleInput(new List<string> { "1000000", "Calculate Pitstops" });
            var menu = new Menu(mockShipService.Object, mockConsoleOutput, mockConsoleInput);

            // Act
            menu.ShowPitstops();

            // Assert
            Assert.Contains("For a given distance of 1000000 Megalights, the following pitstops are needed:\n\n", mockConsoleOutput.Output);
            Assert.Contains("Pitstop 1\n", mockConsoleOutput.Output);
            Assert.Contains("Pitstop 2\n", mockConsoleOutput.Output);
        }

        [Fact]
        public void GetShipData_ShouldDisplayShipData()
        {
            // Arrange
            var mockShipService = new Mock<IShipService>();
            mockShipService.Setup(x => x.GetShipByName(It.IsAny<string>())).Returns( "Ship 1: test");
            var mockConsoleOutput = new MockConsoleOutput();
            var mockConsoleInput = new MockConsoleInput(new List<string> { "Full Ship Data" });
            var menu = new Menu(mockShipService.Object, mockConsoleOutput, mockConsoleInput);

            // Act
            menu.GetShipData();

            // Assert
            Assert.Contains("Ship 1: test", mockConsoleOutput.Output);
        }
    }
}