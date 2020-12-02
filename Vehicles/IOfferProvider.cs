using System.Collections.Generic;

namespace Vehicles
{
    public interface IOfferProvider : IEnumerable<decimal>
    {
        decimal GetOffer();
    }
}
