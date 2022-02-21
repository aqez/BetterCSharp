using System.Threading.Tasks;
using Vehicles.DataAccess;
using Vehicles.Transfer.Console.FileSystems;

namespace Vehicles.Transfer.Console.Processors;

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
