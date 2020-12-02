using System;
using System.Collections.Generic;
using System.IO;

namespace Vehicles.DataAccess.Edi
{
    public class EdiVehicleProvider : IVehicleProvider
    {
        private readonly Stream _stream;
        private readonly StreamReader _reader;

        public EdiVehicleProvider(Stream stream)
        {
            _stream = stream;
            _reader = new StreamReader(_stream);
        }

        public IEnumerable<IVehicle> GetVehicles()
        {
            string line = null;
            while ((line = _reader.ReadLine()) != null)
            {
                string recordType = line.Substring(startIndex: 0, length: 3);
                string vehicleType = line.Substring(startIndex: 3, length: 5).Trim();
                string doorCountStr = line.Substring(startIndex: 8, length: 4);
                string seatCountStr = line.Substring(startIndex: 12, length: 4);
                string weightStr = line.Substring(startIndex: 16, length: 4);

                if (!line.StartsWith("VEH"))
                {
                    throw new Exception($"Invalid row type: {recordType}");
                }

                string dotNetType = char.ToUpper(vehicleType[0]) + vehicleType.ToLower().Substring(startIndex: 1);
                Type type = Type.GetType($"Vehicles.{dotNetType}, Vehicles");
                IVehicle vehicle = (IVehicle)Activator.CreateInstance(type);

                if (int.TryParse(doorCountStr, out int doorCount) &&
                        int.TryParse(seatCountStr, out int seatCount) &&
                        int.TryParse(weightStr, out int weight))
                {
                    vehicle.DoorCount = doorCount;
                    vehicle.SeatCount = seatCount;
                    vehicle.Weight = weight;
                }

                yield return vehicle;
            }
        }

        public void Dispose()
        {
            _reader.Dispose();
            _stream.Dispose();
        }
    }
}
