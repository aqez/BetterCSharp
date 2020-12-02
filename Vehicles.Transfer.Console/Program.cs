using System.Threading.Tasks;

namespace Vehicles.Transfer.Console
{

    class Program
    {
        static async Task Main(string[] args)
        {
            IFileSystem fileSystem = new FileSystem();
            IProcessor processor = new DataflowParallelProcessor(directory: "input", outputFile: "testyo.json", fileSystem);

            await processor.ProcessAsync();
        }
    }
}
