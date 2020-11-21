using Moq;
using Xunit;

namespace Vehicles.Tests
{
    public class MarginVehicleSellerTest
    {
        private readonly MarginVehicleSeller _seller;
        private readonly Mock<IVehicleCostCalculator> _calculatorMock;

        public MarginVehicleSellerTest()
        {
            _calculatorMock = new Mock<IVehicleCostCalculator>();
            _seller = new MarginVehicleSeller(_calculatorMock.Object, 0.10m);
        }


        [Fact]
        public void ShouldSell_WithTooLowOffer_ReturnsFalse()
        {
            //Arrange
            _calculatorMock.Setup(c => c.CalculateCost(It.IsAny<IVehicle>())).Returns(600.0m);

            //Act
            bool shouldSell = _seller.ShouldSell(new Tank(), 500.0m);

            //Assert
            Assert.False(shouldSell);
        }

        [Fact]
        public void ShouldSell_WithGreateroffer_ReturnsTrue()
        {
            //Arrange
            _calculatorMock.Setup(c => c.CalculateCost(It.IsAny<IVehicle>())).Returns(600.0m);

            //Act
            bool shouldSell = _seller.ShouldSell(new Tank(), 700.0m);

            //Assert
            Assert.True(shouldSell);
        }

        [Fact]
        public void ShouldSell_WithinMargin_ReturnsTrue()
        {
            //Arrange
            _calculatorMock.Setup(c => c.CalculateCost(It.IsAny<IVehicle>())).Returns(1000.0m);

            //Act
            bool shouldSell = _seller.ShouldSell(new Tank(), 900.0m);

            //Assert
            Assert.True(shouldSell);
        }

        [Fact]
        public void ShouldSell_JustOutsideMargin_ReturnsFalse()
        {
            //Arrange
            _calculatorMock.Setup(c => c.CalculateCost(It.IsAny<IVehicle>())).Returns(1000.0m);

            //Act
            bool shouldSell = _seller.ShouldSell(new Tank(), 899.0m);

            //Assert
            Assert.False(shouldSell);
        }

    }
}
