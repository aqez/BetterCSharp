using System;
using System.Collections;
using System.Collections.Generic;

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
            decimal offer = _random.Next(_minimum, _maximum * 2);
            return offer;
        }

        public IEnumerator<decimal> GetEnumerator()
        {
            for (var i = 0; i < 10; i++)
            {
                yield return GetOffer();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
