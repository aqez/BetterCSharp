using System.Collections.Generic;

namespace Vehicles.DataAccess
{
    public interface IVehicleRepository
    {
        IEnumerable<IVehicle> GetVehicles();
    }
}
