using System;

namespace Vehicles
{
    public class RandomOfferProvider : IOfferProvider
    {
        private readonly int _minimum;
        private readonly int _maximum;
        private readonly Random _random;

        public RandomOfferProvider(int maximum, int minimum)
        {
            _maximum = maximum;
            _minimum = minimum;
            _random = new Random();
        }

        public decimal GetOffer()
        {
            return (decimal)_random.Next(_minimum, _maximum);
        }
    }
}
