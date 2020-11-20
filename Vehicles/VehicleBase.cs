namespace Vehicles
{
    public abstract class VehicleBase : IVehicle
    {
        public abstract decimal CostMultiplier { get; }
        public int DoorCount { get; set; }
        public int SeatCount { get; set; }
        public int Weight { get; set; }
    }
}
