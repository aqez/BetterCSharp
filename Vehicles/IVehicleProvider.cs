using System.Collections.Generic;

namespace Vehicles
{
    public interface IVehicleProvider
    {
        IEnumerable<IVehicle> GetVehicles();
    }
}
