using Moq;
using Xunit;

namespace Vehicles.Tests
{
    public class ExactVehicleSellerTest
    {
        private readonly ExactSeller _seller;
        private readonly Mock<IVehicleCostCalculator> _calculatorMock;

        public ExactVehicleSellerTest()
        {
            _calculatorMock = new Mock<IVehicleCostCalculator>();
            _seller = new ExactSeller(_calculatorMock.Object);

        }

        [Fact]
        public void ShouldSell_WithExactOffer_ReturnsTrue()
        {
            //Arrange
            _calculatorMock.Setup(c => c.CalculateCost(It.IsAny<IVehicle>())).Returns(500.0m);
            //Act
            bool shouldSell = _seller.ShouldSell(new Car(), 500.0m);
            //Assert
            Assert.True(shouldSell);
        }

        [Fact]
        public void ShouldSell_WithWrongOffer_ReturnsFalse()
        {
            //Arrange
            _calculatorMock.Setup(c => c.CalculateCost(It.IsAny<IVehicle>())).Returns(500.0m);
            //Act
            bool shouldSell = _seller.ShouldSell(new Car(), 200.0m);
            //Assert
            Assert.False(shouldSell);
        }
    }
}
