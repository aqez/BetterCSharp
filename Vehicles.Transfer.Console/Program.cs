using System.Threading.Tasks;

namespace Vehicles.Transfer.Console;


// 1. Get a list of files in a directory
// 2. Get each 'IVehicle' out of those files
// 3. Transform those vehicles into a truck
// 4. Double the amount of doors on them
// 5. Write all of them to a single file

class Program
{
    static async Task Main(string[] args)
    {
        IFileSystem fileSystem = new FileSystem();
        IProcessor processor = new DataflowParallelProcessor(directory: "input", outputFile: "testyo.json", fileSystem);

        await processor.ProcessAsync();
    }
}
