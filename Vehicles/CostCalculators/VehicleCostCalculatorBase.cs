namespace Vehicles.CostCalculators;

public abstract class VehicleCostCalculatorBase : IVehicleCostCalculator
{
    public abstract decimal BaseCost { get; }

    public decimal CalculateCost(IVehicle vehicle)
    {
        return BaseCost * vehicle.CostMultiplier;
    }
}
