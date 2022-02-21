namespace Vehicles;

public interface IVehicle
{
    decimal CostMultiplier { get; }
    int DoorCount { get; set; }
    int SeatCount { get; set; }
    int Weight { get; set; }
}
