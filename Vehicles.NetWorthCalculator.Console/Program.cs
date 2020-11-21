namespace Vehicles.NetWorthCalculator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Get some collection of cars
            // 2. Get some offer on each of the cars
            // 3. Use a calculator to determine which ones to sell

            IVehicle[] vehicles = new IVehicle[]
            {
                 new Car(),
                 new Truck(),
                 new SUV()
            };

            IVehicleProvider vehicleProvider = new ArrayVehicleProvider(vehicles);
            IOfferProvider offerProvider = new RandomOfferProvider(minimum: 1000, maximum: 30000);
            IVehicleCostCalculator costCalculator = new PrivatePartyVehicleCostCalculator();
            IVehicleSeller vehicleSeller = new MarginVehicleSeller(costCalculator, margin: .10m);

            foreach (var vehicle in vehicleProvider.GetVehicles())
            {
                decimal offer = offerProvider.GetOffer();
                bool shouldSell = vehicleSeller.ShouldSell(vehicle, offer);

                System.Console.WriteLine($"{vehicle.GetType().Name} sold? {shouldSell}");
            }
        }
    }
}
