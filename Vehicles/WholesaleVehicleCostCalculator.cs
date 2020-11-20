namespace Vehicles
{
    public class WholesaleVehicleCostCalculator : VehicleCostCalculatorBase
    {
        public override decimal BaseCost => 5000;
    }


    public class AnotherOne : IVehicleCostCalculator
    {
       public decimal BaseCost => throw new System.NotImplementedException();

        public decimal CalculateCost(IVehicle vehicle)
        {
            throw new System.NotImplementedException();
        }
    }
}
