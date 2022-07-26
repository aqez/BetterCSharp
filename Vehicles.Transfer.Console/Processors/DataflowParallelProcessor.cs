using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Newtonsoft.Json;
using Vehicles.DataAccess;
using Vehicles.Transfer.Console.FileSystems;

namespace Vehicles.Transfer.Console.Processors;

public class DataflowParallelProcessor : ProcessorBase
{
    private object _outputLock = new object();

    public DataflowParallelProcessor(string directory, string outputFile, IFileSystem fileSystem)
        : base(directory, outputFile, fileSystem)
    {
    }

    public override async Task ProcessAsync()
    {
        var settings = new ExecutionDataflowBlockOptions()
        {
            MaxDegreeOfParallelism = 10,
        };

        var listFilesBlock = new TransformManyBlock<string, string>(_fileSystem.GetFileNames, settings);
        var getVehiclesBlock = new TransformManyBlock<string, IVehicle>(GetVehicles, settings);
        var transformBlock = new TransformBlock<IVehicle, Truck>(TransformAsync, settings);
        var doubleBlock = new TransformBlock<Truck, Truck>(DoubleDoorsAsync, settings);
        var batchBlock = new BatchBlock<Truck>(10);
        var saveBlock = new ActionBlock<IEnumerable<Truck>>(SaveTrucksAsync, settings);

        DataflowLinkOptions linkOptions = new DataflowLinkOptions() { PropagateCompletion = true };

        listFilesBlock.LinkTo(getVehiclesBlock, linkOptions);
        getVehiclesBlock.LinkTo(transformBlock, linkOptions);
        transformBlock.LinkTo(doubleBlock, linkOptions);
        doubleBlock.LinkTo(batchBlock, linkOptions);
        batchBlock.LinkTo(saveBlock, linkOptions);

        await listFilesBlock.SendAsync(_directory);
        listFilesBlock.Complete();

        await saveBlock.Completion;
    }

    private async Task SaveTrucksAsync(IEnumerable<Truck> trucks)
    {
        System.Console.WriteLine($"Saving {trucks.Count()} trucks");
        await Task.Delay(500);

        lock (_outputLock)
        {
            using (Stream stream = _fileSystem.GetFileStream(_outputFile, FileMode.OpenOrCreate))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                stream.Seek(0, SeekOrigin.End);
                foreach (var truck in trucks)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(truck));
                }
            }
        }
    }

    private IEnumerable<IVehicle> GetVehicles(string fileName)
    {
        System.Console.WriteLine($"Processing {fileName}...");
        using (IVehicleProvider repository = GetVehicleProvider(fileName))
        {
            foreach (var vehicle in repository.GetVehicles())
            {
                yield return vehicle;
            }
        }
    }
}
