namespace Vehicles
{
    public interface IVehicleSeller
    {
        bool ShouldSell(IVehicle vehicle, decimal offer);
    }

    public class ExactSeller : IVehicleSeller
    {
        private readonly IVehicleCostCalculator _calculator;

        public ExactSeller(IVehicleCostCalculator calculator)
        {
            _calculator = calculator;
        }

        public bool ShouldSell(IVehicle vehicle, decimal offer)
        {
            return offer == _calculator.CalculateCost(vehicle);
        }
    }
}
