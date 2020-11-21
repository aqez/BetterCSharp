namespace Vehicles
{
    public class MarginVehicleSeller : IVehicleSeller
    {
        private readonly decimal _margin;
        private readonly IVehicleCostCalculator _calculator;

        public MarginVehicleSeller(IVehicleCostCalculator calculator, decimal margin)
        {
            _margin = margin;
            _calculator = calculator;
        }

        public bool ShouldSell(IVehicle vehicle, decimal offer)
        {
            return offer >= _calculator.CalculateCost(vehicle) * (1.0m - _margin);
        }
    }
}
