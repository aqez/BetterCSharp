namespace Vehicles
{
    public interface IVehicleSeller
    {
        bool ShouldSell(IVehicle vehicle, decimal offer);
    }
}
