namespace Vehicles.Sellers;

public interface IVehicleSeller
{
    bool ShouldSell(IVehicle vehicle, decimal offer);
}
