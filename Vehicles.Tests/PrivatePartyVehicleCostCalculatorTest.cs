using System.Collections.Generic;
using Vehicles.CostCalculators;
using Xunit;

namespace Vehicles.Tests
{
    public class PrivatePartyVehicleCostCalculatorTest
    {
        private readonly PrivatePartyVehicleCostCalculator _calculator;

        public PrivatePartyVehicleCostCalculatorTest()
        {
            _calculator = new PrivatePartyVehicleCostCalculator();
        }

        [Fact]
        public void CalculateCost_WithTank_GivesBackCorrectCost()
        {
            // Arrange
            Tank tank = new Tank();
            decimal expected = 40000000.0m;
            // Act
            decimal result = _calculator.CalculateCost(tank);
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateCost_WithCar_GivesBackCorrectCost()
        {
            // Arrange
            Car car = new Car();
            decimal expected = 8000.0m;
            // Act
            decimal result = _calculator.CalculateCost(car);
            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetCarsAndCosts))]
        public void CalculateCost_WithVehicle_GivesBackCorrectCost(IVehicle vehicle, decimal expected)
        {
            // Act
            decimal result = _calculator.CalculateCost(vehicle);
            // Assert
            Assert.Equal(expected, result);
        }


        public static IEnumerable<object[]> GetCarsAndCosts()
        {
            yield return new object[] { new SUV(), 14000.0m };
            yield return new object[] { new Semi(), 6400000.0m };
        }
    }
}
