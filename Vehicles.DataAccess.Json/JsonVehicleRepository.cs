using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Vehicles.DataAccess.Json
{
    public class JsonVehicleRepository : IVehicleRepository
    {
        private readonly Stream _stream;
        private readonly StreamReader _reader;

        public JsonVehicleRepository(Stream stream)
        {
            _stream = stream;
            _reader = new StreamReader(stream);
        }

        public void Dispose()
        {
            _stream.Dispose();
        }

        public IEnumerable<IVehicle> GetVehicles()
        {
            string text = _reader.ReadToEnd();

            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.DeserializeObject<IVehicle[]>(text, settings);
        }
    }
}
