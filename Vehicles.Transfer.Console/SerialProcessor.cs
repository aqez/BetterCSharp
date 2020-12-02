using System.Threading.Tasks;
using Vehicles.DataAccess;

namespace Vehicles.Transfer.Console
{
    public class SerialProcessor : ProcessorBase
    {
        public SerialProcessor(string directory, string outputFile, IFileSystem fileSystem)
            : base(directory, outputFile, fileSystem)
        {

        }

        public override async Task ProcessAsync()
        {
            foreach (string fileName in _fileSystem.GetFileNames(_directory))
            {
                System.Console.WriteLine($"Processing {fileName}...");
                using (IVehicleProvider inputRepository = GetVehicleProvider(fileName))
                {
                    foreach (IVehicle vehicle in inputRepository.GetVehicles())
                    {
                        Truck truck = await TransformAsync(vehicle);
                        truck = await DoubleDoorsAsync(truck);

                        await SaveTruckAsync(truck);
                    }
                }
            }
        }

    }
}
