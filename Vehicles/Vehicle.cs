namespace Vehicles
{
    public enum VehicleType { Car, Truck, SUV }

    public class Vehicle
    {
        public int DoorCount { get; set; }
        public int SeatCount { get; set; }
        public int Weight { get; set; }
    }
}
