using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vehicles.DataAccess;
using Vehicles.DataAccess.Edi;
using Vehicles.DataAccess.Json;

namespace Vehicles.Transfer.Console
{
    public abstract class ProcessorBase : IProcessor
    {
        protected readonly string _directory;
        protected readonly IFileSystem _fileSystem;
        protected readonly string _outputFile;

        public ProcessorBase(string directory, string outputFile, IFileSystem fileSystem)
        {
            _directory = directory;
            _fileSystem = fileSystem;
            _outputFile = outputFile;
        }

        public abstract Task ProcessAsync();



        protected async Task SaveTruckAsync(Truck truck)
        {
            System.Console.WriteLine($"Saving truck");
            await Task.Delay(500);

            lock (this)
            {
                using (Stream stream = _fileSystem.GetFileStream(_outputFile, FileMode.OpenOrCreate))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    stream.Seek(0, SeekOrigin.End);
                    writer.WriteLine(JsonConvert.SerializeObject(truck));
                }
            }
        }

        protected async Task<Truck> TransformAsync(IVehicle vehicle)
        {
            System.Console.WriteLine($"Transforming {vehicle.GetType().Name} into {nameof(Truck)}");
            await Task.Delay(200);
            return new Truck()
            {
                DoorCount = vehicle.DoorCount,
                SeatCount = vehicle.SeatCount,
                Weight = vehicle.Weight
            };
        }

        protected async Task<Truck> DoubleDoorsAsync(Truck truck)
        {
            System.Console.WriteLine($"Doubling doors from {truck.DoorCount} to {truck.DoorCount * 2}");
            await Task.Delay(truck.DoorCount * 500);
            return new Truck()
            {
                SeatCount = truck.SeatCount,
                DoorCount = truck.DoorCount *= 2,
                Weight = truck.Weight
            };
        }

        protected IVehicleProvider GetVehicleProvider(string fileName)
        {
            Stream stream = _fileSystem.GetFileStream(fileName, FileMode.Open);

            if (fileName.EndsWith(".edi"))
            {
                System.Console.WriteLine($"\tGot {nameof(EdiVehicleProvider)}");
                return new EdiVehicleProvider(stream);
            }
            else if (fileName.EndsWith(".json"))
            {
                System.Console.WriteLine($"\tGot {nameof(JsonVehicleProvider)}");
                return new JsonVehicleProvider(stream);
            }

            throw new NotSupportedException($"File type not supported: {fileName}");
        }
    }
}
