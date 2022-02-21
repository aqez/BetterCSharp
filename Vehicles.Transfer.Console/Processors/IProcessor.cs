using System.Threading.Tasks;

namespace Vehicles.Transfer.Console.Processors;

public interface IProcessor
{
    Task ProcessAsync();
}
