using System.Threading.Tasks;

namespace Vehicles.Transfer.Console
{

    class Program
    {
        static async Task Main(string[] args)
        {
            IProcessor processor = new DataflowParallelProcessor("input", "testyo.json", new FileSystem());

            await processor.ProcessAsync();
        }
    }
}
