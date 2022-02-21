using System;
using System.Collections.Generic;

namespace Vehicles.DataAccess;

public interface IVehicleProvider : IDisposable
{
    IEnumerable<IVehicle> GetVehicles();
}
