using System.Linq;
using Vehicles.OfferProviders;

namespace Vehicles.NetWorthCalculator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomOfferProvider offerProvider = new RandomOfferProvider(minimum: 1000, maximum: 30000);

            decimal max = offerProvider.Max();

            var offers = offerProvider.Where(o => o < 20000).ToList();

            System.Console.WriteLine($"Number of offers under 20000: {offers.Count()}");
        }
    }
}
