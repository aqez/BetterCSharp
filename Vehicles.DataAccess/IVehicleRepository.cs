using System;
using System.Collections.Generic;

namespace Vehicles.DataAccess
{
    public interface IVehicleRepository : IDisposable
    {
        IEnumerable<IVehicle> GetVehicles();
    }
}
