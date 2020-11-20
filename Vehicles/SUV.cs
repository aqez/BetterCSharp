namespace Vehicles
{
    public class SUV : VehicleBase
    {
        public override decimal CostMultiplier => 1.75m;
    }

    public class Semi : VehicleBase
    {
        public override decimal CostMultiplier => 800.0m;
    }

}
