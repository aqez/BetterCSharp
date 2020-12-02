using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Vehicles.DataAccess.Json
{
    public class JsonVehicleProvider : IVehicleRepository
    {
        private readonly string _fileName;

        public JsonVehicleProvider(string fileName)
        {
            _fileName = fileName;
        }

        public IEnumerable<IVehicle> GetVehicles()
        {
            string text = File.ReadAllText(_fileName);

            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.DeserializeObject<IVehicle[]>(text, settings);
        }
    }
}
