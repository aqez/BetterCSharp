using System.Threading.Tasks;

namespace Vehicles.Transfer.Console;

public interface IProcessor
{
    Task ProcessAsync();
}
