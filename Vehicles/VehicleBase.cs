namespace Vehicles
{
    public abstract class VehicleBase : IVehicle
    {
        public abstract decimal CostMultiplier { get; }
        public int DoorCount { get; set; }
        public int SeatCount { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} - Doors: {DoorCount}, Seats: {SeatCount}, Weight: {Weight}";
        }
    }
}
