using System.Collections.Generic;

namespace Vehicles
{
    public class ArrayVehicleProvider : IVehicleProvider
    {

        private readonly IVehicle[] _vehicles;

        public ArrayVehicleProvider(IVehicle[] vehicles)
        {
            _vehicles = vehicles;
        }

        public IEnumerable<IVehicle> GetVehicles()
        {
            return _vehicles;
        }
    }
}
