using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Vehicles.DataAccess;

namespace Vehicles.Transfer.Console
{
    public class SemaphoreParallelProcessor : ProcessorBase
    {
        public SemaphoreParallelProcessor(string directory, string outputFile, IFileSystem fileSystem)
            : base(directory, outputFile, fileSystem)
        {

        }

        public override async Task ProcessAsync()
        {
            using (SemaphoreSlim semaphore = new SemaphoreSlim(4))
            {
                foreach (string fileName in _fileSystem.GetFileNames(_directory))
                {
                    System.Console.WriteLine($"Processing {fileName}...");
                    using (IVehicleProvider inputRepository = GetVehicleProvider(fileName))
                    {
                        List<Task> tasks = new List<Task>();
                        foreach (IVehicle vehicle in inputRepository.GetVehicles())
                        {
                            await semaphore.WaitAsync();
                            tasks.Add(Task.Run(async () =>
                            {
                                try
                                {
                                    Truck truck = await TransformAsync(vehicle);
                                    truck = await DoubleDoorsAsync(truck);

                                    await SaveTruckAsync(truck);
                                }
                                finally
                                {
                                    semaphore.Release();
                                }
                            }));
                        }
                        await Task.WhenAll(tasks);
                    }
                }
            }
        }
    }
}
